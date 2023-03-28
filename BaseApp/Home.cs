using Sports_Accounting.BaseApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using api;

namespace Sports_Accounting
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TransactionDisplay transactionDisplay = new TransactionDisplay();
            transactionDisplay.Show();
        }

        [STAThread]
        private void buttonTransaction_Click(object sender, EventArgs e)
        {
            //need to run method on a seperate thread
            Thread t = new Thread((ThreadStart)(() => {
                OpenFileDialog dialog = new OpenFileDialog();
                //allowed file types
                dialog.Filter = "Text files | *.txt";
                dialog.Multiselect = true; // allow/deny user to upload more than one file at a time
                if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
                {
                    //MAKES SURE TO FIRST CHECK ALL FILES AND THEN UPLOAD TO MONGODB
                    JsonAPI jsonAPI = new JsonAPI();
                    Validator val = new Validator();
                    bool invalidFile = false;
                    foreach(var filePath in dialog.FileNames)
                    {
                        var bsonFile = jsonAPI.FileToBson(filePath);
                        //checks if its valid mt940 and valid json file format
                        if (!jsonAPI.checkMT940(bsonFile) && !val.validateJson(bsonFile))
                        {
                            invalidFile = true;
                            //if invalid file is found stop checking and report error
                            break;
                        }
                    }
                    if(invalidFile) 
                    {
                        MessageBox.Show("File is not valid mt940 document, No files have been uploaded to the database.", "ERROR");
                    } else
                    {
                        //upload documents to mongoDB
                        foreach (var filePath in dialog.FileNames)
                        {
                            jsonAPI.Post(jsonAPI.FileToBson(filePath));
                        }
                    }
                }
            }));

            // Run your code from a thread that joins the STA Thread
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
            
        }
    }
}

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

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            //if the user is a superuser allow them to view the users panel
=======
            //if the user is an admin allow them to view the users panel
>>>>>>> added proper login functionality and 80 percent of the user panel
=======
            //if the user is a superuser allow them to view the users panel
>>>>>>> can add transactions to database, fixed login, fixed parsing
=======
            //if the user is a superuser allow them to view the users panel
>>>>>>> 254ac816fdbac4fff73dff91f20d1dc36dfce5db
            if(User.Level == userLevel.SUPERUSER)
            {
                button1.Visible = true;
            }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

            //set welcome to display username
            welcomeText.Text += " " + User.UserName + "!";
=======
>>>>>>> added proper login functionality and 80 percent of the user panel
=======

            //set welcome to display username
            welcomeText.Text += " " + User.UserName + "!";
>>>>>>> can add transactions to database, fixed login, fixed parsing
=======

            //set welcome to display username
            welcomeText.Text += " " + User.UserName + "!";
>>>>>>> 254ac816fdbac4fff73dff91f20d1dc36dfce5db
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
                        try
                        {
                            if (!jsonAPI.checkMT940(bsonFile) && !val.validateJson(bsonFile))
                            {
                                invalidFile = true;
                                //if invalid file is found stop checking and report error
                                break;
                            }
                        } catch
                        {
                            invalidFile = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.Show();
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> can add transactions to database, fixed login, fixed parsing
=======
>>>>>>> 254ac816fdbac4fff73dff91f20d1dc36dfce5db
            this.Hide();
        }

        private void LogOutButton(object sender, EventArgs e)
        {
            //go back to log in page and reset the users data
            LogIn logIn = new LogIn();
            logIn.Show();
            User.UserName = string.Empty;
            User.Level = userLevel.GUEST;
            this.Hide();
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> added proper login functionality and 80 percent of the user panel
=======
>>>>>>> can add transactions to database, fixed login, fixed parsing
=======
>>>>>>> 254ac816fdbac4fff73dff91f20d1dc36dfce5db
        }
    }
}

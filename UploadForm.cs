using System;
using System.Windows.Forms;

namespace Sports_Accounting
{
    public partial class UploadForm : Form
    {
        public UploadForm()
        {
            InitializeComponent();
        }

        //Freaks out when OpenFileDialog.ShowDialog isn't run in single thread.
        private void Upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "mt940 files (*.mt940)|*mt940|All files (*.*)|*.*"; //Files types to be allowed
            dialog.Multiselect = true; //Allow more than 1 file to be uploaded
            if(dialog.ShowDialog() == DialogResult.OK)
            { 
                String path = dialog.FileName;
            }

        }
    }
}
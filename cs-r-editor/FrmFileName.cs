using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace cs_r_editor
{
    public partial class FrmFileName : Form
    {
        private string mWorkingDirectory = "";

        public string WorkingDirectory
        {
            get { return mWorkingDirectory; }
            set { mWorkingDirectory = value; }
        }

        public string FileName
        {
            get
            {
                return txtFileName.Text.Trim();
            }
        }

        public FrmFileName()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFileName.Text.Trim()))
            {
                MessageBox.Show(this, "File name cannot be null", "File creation failed", MessageBoxButtons.OK);
                DialogResult = DialogResult.None;
                return;
            }
            if (FileExists(txtFileName.Text))
            {
                MessageBox.Show(this, "File already exist, cannot overwrite", "File creation failed", MessageBoxButtons.OK);
                DialogResult = DialogResult.None;
                return;
            }

        }

        private bool FileExists(string filename)
        {
            string filepath = Path.Combine(mWorkingDirectory, filename);
            return File.Exists(filepath);
        }
    }
}

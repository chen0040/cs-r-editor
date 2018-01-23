using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs_r_editor
{
    public partial class FrmArgs : Form
    {
        public string Arg1 { get; set; }
        public string Arg2 { get; set; }

        public FrmArgs()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Arg1 = txtArg1.Text;
            Arg2 = txtArg2.Text;
        }

        private void FrmArgs_Load(object sender, EventArgs e)
        {
            txtArg1.Text = Arg1;
            txtArg2.Text = Arg2;
        }
    }
}

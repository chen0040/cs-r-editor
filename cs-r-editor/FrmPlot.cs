using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cs_r_editor
{
    public partial class FrmPlot : Form
    {
        public FrmPlot()
        {
            InitializeComponent();
        }

        public Image PlotImage
        {
            set
            {
                pBox.Image = value;
                pBox.Width = value.Width;
                pBox.Height = value.Height;
            }
        }

        private void pBox_Click(object sender, EventArgs e)
        {

        }

        private void FrmPlot_Resize(object sender, EventArgs e)
        {

        }

        private void FrmPlot_SizeChanged(object sender, EventArgs e)
        {
            pBox.Left = System.Math.Max(0, panel1.Width / 2 - pBox.Width / 2);
            pBox.Top = System.Math.Max(0, panel1.Height / 2 - pBox.Height / 2);


        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            pBox.Width = (int)(pBox.Width * 0.9);
            pBox.Height = (int)(pBox.Height * 0.9);

            pBox.Left = System.Math.Max(0, panel1.Width / 2 - pBox.Width / 2);
            pBox.Top = System.Math.Max(0, panel1.Height / 2 - pBox.Height / 2);
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            pBox.Width = (int)(pBox.Width * 1.1);
            pBox.Height = (int)(pBox.Height * 1.1);

            pBox.Left = System.Math.Max(0, panel1.Width / 2 - pBox.Width / 2);
            pBox.Top = System.Math.Max(0, panel1.Height / 2 - pBox.Height / 2);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "PNG File (*.png)|*.png|All Files (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filename = dlg.FileName;
                pBox.Image.Save(filename);
            }
        }
    }
}

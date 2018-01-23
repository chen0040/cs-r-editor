using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;

namespace cs_r_editor
{
    public partial class FrmR : Form
    {
        private List<string> Keywords1 = null;
        private List<string> Keywords2 = null;
        private string AutoCompleteKeywords = null;
        private RModel mModel = new RModel();

        private ScintillaNET.Scintilla txtScript;
        public FrmR()
        {
            InitializeComponent();
            this.txtScript = new ScintillaNET.Scintilla();
            this.txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScript.Location = new System.Drawing.Point(0, 0);
            this.txtScript.Name = "txtScript";
            this.txtScript.Size = new System.Drawing.Size(328, 115);
            this.txtScript.TabIndex = 1;
            this.txtScript.Text = "scintilla1";

            this.pnlScript.Controls.Add(this.txtScript);


            PrepareKeywords();

            ConfigureRScriptSyntaxHighlight();
            ConfigureRScriptAutoFolding();
            ConifugreRScriptAutoComplete();
        }

        private string GetKeyWordContent1()
        {
            string filepath = Path.Combine(Application.StartupPath, "keywords1.txt");
            if (File.Exists(filepath))
            {
                string content = "";
                using (StreamReader reader = new StreamReader(filepath))
                {
                    content = reader.ReadToEnd();
                }
                return content;
            }
            else
            {
                string content = @"commandArgs detach length dev.off stop lm library predict lmer 
            plot print display anova read.table read.csv complete.cases dim attach as.numeric seq max 
            min data.frame lines curve as.integer levels nlevels ceiling sqrt ranef order
            AIC summary str head png tryCatch par mfrow interaction.plot qqnorm qqline";
                using (StreamWriter writer = new StreamWriter(filepath))
                {
                    writer.WriteLine(content);
                }
                return content;
            }
        }

        private string GetKeywordContent2()
        {
            string filepath = Path.Combine(Application.StartupPath, "keywords2.txt");
            if (File.Exists(filepath))
            {
                string content = "";
                using (StreamReader reader = new StreamReader(filepath))
                {
                    content = reader.ReadToEnd();
                }
                return content;
            }
            else
            {
                string content = @"TRUE FALSE if else for while in break continue function";
                using (StreamWriter writer = new StreamWriter(filepath))
                {
                    writer.WriteLine(content);
                }
                return content;
            }
        }

        private void PrepareKeywords()
        {
            string keyWordContent1 = GetKeyWordContent1();
            Keywords1 = keyWordContent1.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string keyWordContent2 = GetKeywordContent2();
            Keywords2 = keyWordContent2.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> keywords = Keywords1.ToList();
            keywords.AddRange(Keywords2);
            keywords.Sort();

            AutoCompleteKeywords = string.Join(" ", keywords);
        }

        private void ConfigureRScriptSyntaxHighlight()
        {
            // Configuring the default style with properties
            // we have common to every lexer style saves time.
            txtScript.StyleResetDefault();
            txtScript.Styles[Style.Default].Font = "Consolas";
            txtScript.Styles[Style.Default].Size = 10;
            txtScript.StyleClearAll();

            // Configure the CPP (C#) lexer styles
            txtScript.Styles[Style.R.Default].ForeColor = Color.Brown;
            txtScript.Styles[Style.R.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            txtScript.Styles[Style.R.Number].ForeColor = Color.Olive;
            txtScript.Styles[Style.R.BaseKWord].ForeColor = Color.Purple;
            txtScript.Styles[Style.R.Identifier].ForeColor = Color.Black;
            txtScript.Styles[Style.R.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
            txtScript.Styles[Style.R.KWord].ForeColor = Color.Blue;
            txtScript.Styles[Style.R.OtherKWord].ForeColor = Color.Blue;
            txtScript.Styles[Style.R.String2].ForeColor = Color.OrangeRed;
            txtScript.Styles[Style.R.Operator].ForeColor = Color.Purple;


            txtScript.Lexer = Lexer.R;

            // Set the keywords
            txtScript.SetKeywords(0, string.Join(" ", Keywords1));
            txtScript.SetKeywords(1, string.Join(" ", Keywords2));
        }

        private void ConifugreRScriptAutoComplete()
        {
            txtScript.CharAdded += scintilla_CharAdded;
        }

        private void scintilla_CharAdded(object sender, CharAddedEventArgs e)
        {
            Scintilla scintilla = txtScript;

            // Find the word start
            var currentPos = scintilla.CurrentPosition;
            var wordStartPos = scintilla.WordStartPosition(currentPos, true);

            // Display the autocompletion list
            var lenEntered = currentPos - wordStartPos;
            if (lenEntered > 0)
            {
                scintilla.AutoCShow(lenEntered, AutoCompleteKeywords);
            }
        }

        private void ConfigureRScriptAutoFolding()
        {
            Scintilla scintilla = txtScript;

            // Instruct the lexer to calculate folding
            scintilla.SetProperty("fold", "1");
            scintilla.SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            scintilla.Margins[2].Type = MarginType.Symbol;
            scintilla.Margins[2].Mask = Marker.MaskFolders;
            scintilla.Margins[2].Sensitive = true;
            scintilla.Margins[2].Width = 20;

            scintilla.Margins[0].Width = 30;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                scintilla.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                scintilla.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            // Configure folding markers with respective symbols
            scintilla.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            scintilla.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            scintilla.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            scintilla.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scintilla.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            scintilla.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scintilla.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            scintilla.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
        }


        public void RefreshView()
        {
            txtWorkingDirectory.Text = mModel.WorkingDirectory;

            lvSource.Items.Clear();
            lvScript.Items.Clear();
            
            foreach(string value in mModel.Sources)
            {
                this.lvSource.Items.Add(value);
            }
            foreach (string value in mModel.Scripts)
            {
                this.lvScript.Items.Add(value);
            }
            txtWorkingDirectory.Text = mModel.WorkingDirectory;

        }

        public RModel DataModel
        {
            get
            {
                return mModel;
            }
            set
            {
                mModel = value;
            }
        }

        private void lvSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSource.SelectedIndices.Count == 0) return;

            string filename = lvSource.SelectedItems[0].Text;
            string filepath = mModel.GetFullPath(filename);
            DataTable table = mModel.LoadData(filepath);

            this.dgvData.DataSource = table;
            docData.Text = string.Format("Data: {0}", filename);
        }

        private void lvScript_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadScript();
        }

        private void LoadScript()
        {
            if (lvScript.SelectedIndices.Count == 0) return;

            string filename = lvScript.SelectedItems[0].Text;
            string filepath = mModel.GetFullPath(filename);

            this.txtScript.Text = mModel.LoadScript(filepath);
            docScript.Text = string.Format("R Script: {0}", filename);
        }

        private void SaveScript()
        {
            if (lvScript.SelectedItems.Count == 0) return;

            string filename = lvScript.SelectedItems[0].Text;
            string filepath = mModel.GetFullPath(filename);

            mModel.SaveScript(filepath, txtScript.Text);
        }

        private void btnRunScript_Click(object sender, EventArgs e)
        {
            string filename = lvSource.SelectedItems[0].Text;
            string filepath = mModel.GetFullPath(filename);

            string scriptName = lvScript.SelectedItems[0].Text;
            string scriptPath = mModel.GetFullPath(scriptName);

            string outputname = "output.png";
            string outputpath = mModel.GetFullPath(outputname);

            if (File.Exists(outputpath))
            {
                File.Delete(outputpath);
            }

            string arg1 = filepath;
            string arg2 = outputpath;

            FrmArgs frmArgs = new FrmArgs();
            frmArgs.Arg1 = arg1;
            frmArgs.Arg2 = arg2;

            if(frmArgs.ShowDialog() == DialogResult.OK)
            {
                arg1 = frmArgs.Arg1;
                arg2 = frmArgs.Arg2;
            }

            txtConsole.Text = "";
            btnRunScript.Enabled = false;
            RScriptRunner.RunFromCmd(scriptPath, mModel.ScriptEnginePath, string.Format("\"{0}\" \"{1}\" \"{2}\"", arg1, arg2, mModel.WorkingDirectory),
                (sender2, e2) =>
                {
                    int index = (int)e2.UserState;
                    txtConsole.Text = AsciiCow.Get(index);
                },
                (sender2, e2) =>
                {
                    btnRunScript.Enabled = true;

                    string result;
                    if (e2.Error != null)
                    {
                        result = string.Format("R Script failed: {0}", e2.Error);
                    }
                    else
                    {
                        result = e2.Result as string;
                    }
                    txtConsole.Text = result;

                    if (File.Exists(outputpath))
                    {
                        //Process.Start(outputpath);
                        FrmPlot frm = new FrmPlot();
                        using (FileStream stream = new FileStream(outputpath, FileMode.Open, FileAccess.Read))
                        {
                            frm.PlotImage = Image.FromStream(stream);
                        }
                        frm.Text = string.Format("Plot with {0} on {1}", scriptName, filename);

                        frm.Show();
                    }
                });
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string dirPath = dlg.SelectedPath;
                mModel.WorkingDirectory = dirPath;

                lvSource.Items.Clear();
                lvScript.Items.Clear();

                foreach(string value in mModel.Sources)
                {
                    lvSource.Items.Add(value);
                }
                foreach(string value in mModel.Scripts)
                {
                    lvScript.Items.Add(value);
                }
                
                txtWorkingDirectory.Text = mModel.WorkingDirectory;
            }
        }

        private void btnRefreshWorkingDirectory_Click(object sender, EventArgs e)
        {

            mModel.Update();
            RefreshView();
        }

        private void lblWorkingDirectory_Click(object sender, EventArgs e)
        {
            OpenWorkingDirectory();
        }

        private void OpenWorkingDirectory()
        {
            Process.Start("explorer.exe", string.Format("\"{0}\"", mModel.WorkingDirectory));
        }

        private void btnSaveScript_Click(object sender, EventArgs e)
        {
            SaveScript();
        }

        private void btnReloadScript_Click(object sender, EventArgs e)
        {
            LoadScript();
        }

        private void btnScriptZoomIn_Click(object sender, EventArgs e)
        {
            txtScript.ZoomIn();
        }

        private void btnScriptZoomOut_Click(object sender, EventArgs e)
        {
            txtScript.ZoomOut();
        }

        private void btnSaveOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filepath = dlg.FileName;
                using (StreamWriter writer = new StreamWriter(filepath))
                {
                    writer.WriteLine(txtConsole.Text);
                }
            }
        }

        private void btnCreateScript_Click(object sender, EventArgs e)
        {
            CreateScript();
        }

        private void btnDeleteScript_Click(object sender, EventArgs e)
        {
            DeleteScript();
        }

        private void CreateScript()
        {
            FrmFileName dlg = new FrmFileName();
            dlg.WorkingDirectory = mModel.WorkingDirectory;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filepath = mModel.GetFullPath(dlg.FileName);
                using (StreamWriter writer = new StreamWriter(filepath))
                {
                    writer.WriteLine();
                }

                mModel.Update();
                RefreshView();
            }
        }

        private void DeleteScript()
        {
            if (MessageBox.Show(this, "Do you want to permanently delete the file?", "File Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            if (lvScript.SelectedItems.Count == 0) return;

            string filename = lvScript.SelectedItems[0].Text;
            string filepath = mModel.GetFullPath(filename);

            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }

            this.txtScript.Text = "";

            mModel.Update();
            RefreshView();
        }

        private void btnOpenWorkingDirectory_Click(object sender, EventArgs e)
        {
            OpenWorkingDirectory();
        }

        private void FrmR_Load(object sender, EventArgs e)
        {
            txtScript.Text = "";
            RefreshView();
        }

        private void btnReloadRScripts_Click(object sender, EventArgs e)
        {
            mModel.Update();
            lvScript.Items.Clear();
            
            foreach (string value in mModel.Scripts)
            {
                this.lvScript.Items.Add(value);
            }
        }
    }
}

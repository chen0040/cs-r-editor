using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;

namespace cs_r_editor
{
    public partial class Form1 : Form
    {
        private List<string> Keywords1 = null;
        private List<string> Keywords2 = null;
        private string AutoCompleteKeywords = null;

        private ScintillaNET.Scintilla txtScript;
        public Form1()
        {
            InitializeComponent();
            this.txtScript = new ScintillaNET.Scintilla();
            this.txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScript.Location = new System.Drawing.Point(0, 0);
            this.txtScript.Name = "txtScript";
            this.txtScript.Size = new System.Drawing.Size(328, 115);
            this.txtScript.TabIndex = 1;
            this.txtScript.Text = "scintilla1";

            this.docScript.Controls.Add(this.txtScript);


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
    }
}

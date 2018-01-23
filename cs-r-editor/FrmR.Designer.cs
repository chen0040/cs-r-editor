namespace cs_r_editor
{
    partial class FrmR
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmR));
            this.pnlScript = new System.Windows.Forms.Panel();
            this.lvSource = new System.Windows.Forms.ListView();
            this.lvScript = new System.Windows.Forms.ListView();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblWorkingDirectory = new System.Windows.Forms.ToolStripLabel();
            this.txtWorkingDirectory = new System.Windows.Forms.ToolStripTextBox();
            this.btnBrowse = new System.Windows.Forms.ToolStripButton();
            this.btnRefreshWorkingDirectory = new System.Windows.Forms.ToolStripButton();
            this.btnSaveOutput = new System.Windows.Forms.ToolStripButton();
            this.btnOpenWorkingDirectory = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.docData = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.docScript = new System.Windows.Forms.GroupBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnRunScript = new System.Windows.Forms.ToolStripButton();
            this.btnReloadScript = new System.Windows.Forms.ToolStripButton();
            this.btnSaveScript = new System.Windows.Forms.ToolStripButton();
            this.btnScriptZoomIn = new System.Windows.Forms.ToolStripButton();
            this.btnScriptZoomOut = new System.Windows.Forms.ToolStripButton();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.btnCreateScript = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteScript = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReloadRScripts = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.docData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.docScript.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlScript
            // 
            this.pnlScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScript.Location = new System.Drawing.Point(3, 41);
            this.pnlScript.Name = "pnlScript";
            this.pnlScript.Size = new System.Drawing.Size(372, 356);
            this.pnlScript.TabIndex = 0;
            // 
            // lvSource
            // 
            this.lvSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSource.Location = new System.Drawing.Point(3, 16);
            this.lvSource.Name = "lvSource";
            this.lvSource.Size = new System.Drawing.Size(131, 381);
            this.lvSource.TabIndex = 1;
            this.lvSource.UseCompatibleStateImageBehavior = false;
            this.lvSource.View = System.Windows.Forms.View.List;
            this.lvSource.SelectedIndexChanged += new System.EventHandler(this.lvSource_SelectedIndexChanged);
            // 
            // lvScript
            // 
            this.lvScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvScript.Location = new System.Drawing.Point(3, 41);
            this.lvScript.Name = "lvScript";
            this.lvScript.Size = new System.Drawing.Size(201, 220);
            this.lvScript.TabIndex = 2;
            this.lvScript.UseCompatibleStateImageBehavior = false;
            this.lvScript.View = System.Windows.Forms.View.List;
            this.lvScript.SelectedIndexChanged += new System.EventHandler(this.lvScript_SelectedIndexChanged);
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 16);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(264, 381);
            this.dgvData.TabIndex = 4;
            // 
            // txtConsole
            // 
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsole.Location = new System.Drawing.Point(3, 16);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsole.Size = new System.Drawing.Size(201, 113);
            this.txtConsole.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblWorkingDirectory,
            this.txtWorkingDirectory,
            this.btnBrowse,
            this.btnRefreshWorkingDirectory,
            this.btnSaveOutput,
            this.btnOpenWorkingDirectory});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1004, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblWorkingDirectory
            // 
            this.lblWorkingDirectory.Name = "lblWorkingDirectory";
            this.lblWorkingDirectory.Size = new System.Drawing.Size(106, 22);
            this.lblWorkingDirectory.Text = "Working Directory:";
            this.lblWorkingDirectory.Click += new System.EventHandler(this.lblWorkingDirectory_Click);
            // 
            // txtWorkingDirectory
            // 
            this.txtWorkingDirectory.Name = "txtWorkingDirectory";
            this.txtWorkingDirectory.Size = new System.Drawing.Size(500, 25);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowse.Image")));
            this.btnBrowse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(65, 22);
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnRefreshWorkingDirectory
            // 
            this.btnRefreshWorkingDirectory.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshWorkingDirectory.Image")));
            this.btnRefreshWorkingDirectory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshWorkingDirectory.Name = "btnRefreshWorkingDirectory";
            this.btnRefreshWorkingDirectory.Size = new System.Drawing.Size(66, 22);
            this.btnRefreshWorkingDirectory.Text = "Refresh";
            this.btnRefreshWorkingDirectory.Click += new System.EventHandler(this.btnRefreshWorkingDirectory_Click);
            // 
            // btnSaveOutput
            // 
            this.btnSaveOutput.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveOutput.Image")));
            this.btnSaveOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveOutput.Name = "btnSaveOutput";
            this.btnSaveOutput.Size = new System.Drawing.Size(92, 22);
            this.btnSaveOutput.Text = "Save Output";
            this.btnSaveOutput.Click += new System.EventHandler(this.btnSaveOutput_Click);
            // 
            // btnOpenWorkingDirectory
            // 
            this.btnOpenWorkingDirectory.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenWorkingDirectory.Image")));
            this.btnOpenWorkingDirectory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenWorkingDirectory.Name = "btnOpenWorkingDirectory";
            this.btnOpenWorkingDirectory.Size = new System.Drawing.Size(69, 22);
            this.btnOpenWorkingDirectory.Text = "Explorer";
            this.btnOpenWorkingDirectory.Click += new System.EventHandler(this.btnOpenWorkingDirectory_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1004, 400);
            this.splitContainer1.SplitterDistance = 411;
            this.splitContainer1.TabIndex = 9;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.docData);
            this.splitContainer4.Size = new System.Drawing.Size(411, 400);
            this.splitContainer4.SplitterDistance = 137;
            this.splitContainer4.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lvSource);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(137, 400);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Data Files";
            // 
            // docData
            // 
            this.docData.Controls.Add(this.dgvData);
            this.docData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.docData.Location = new System.Drawing.Point(0, 0);
            this.docData.Name = "docData";
            this.docData.Size = new System.Drawing.Size(270, 400);
            this.docData.TabIndex = 0;
            this.docData.TabStop = false;
            this.docData.Text = "Data";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.docScript);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(589, 400);
            this.splitContainer2.SplitterDistance = 378;
            this.splitContainer2.TabIndex = 0;
            // 
            // docScript
            // 
            this.docScript.Controls.Add(this.pnlScript);
            this.docScript.Controls.Add(this.toolStrip2);
            this.docScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.docScript.Location = new System.Drawing.Point(0, 0);
            this.docScript.Name = "docScript";
            this.docScript.Size = new System.Drawing.Size(378, 400);
            this.docScript.TabIndex = 0;
            this.docScript.TabStop = false;
            this.docScript.Text = "R Script";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRunScript,
            this.btnReloadScript,
            this.btnSaveScript,
            this.btnScriptZoomIn,
            this.btnScriptZoomOut});
            this.toolStrip2.Location = new System.Drawing.Point(3, 16);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(372, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnRunScript
            // 
            this.btnRunScript.Image = ((System.Drawing.Image)(resources.GetObject("btnRunScript.Image")));
            this.btnRunScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRunScript.Name = "btnRunScript";
            this.btnRunScript.Size = new System.Drawing.Size(81, 22);
            this.btnRunScript.Text = "Run Script";
            this.btnRunScript.Click += new System.EventHandler(this.btnRunScript_Click);
            // 
            // btnReloadScript
            // 
            this.btnReloadScript.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadScript.Image")));
            this.btnReloadScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadScript.Name = "btnReloadScript";
            this.btnReloadScript.Size = new System.Drawing.Size(63, 22);
            this.btnReloadScript.Text = "Reload";
            this.btnReloadScript.Click += new System.EventHandler(this.btnReloadScript_Click);
            // 
            // btnSaveScript
            // 
            this.btnSaveScript.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveScript.Image")));
            this.btnSaveScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveScript.Name = "btnSaveScript";
            this.btnSaveScript.Size = new System.Drawing.Size(51, 22);
            this.btnSaveScript.Text = "Save";
            this.btnSaveScript.Click += new System.EventHandler(this.btnSaveScript_Click);
            // 
            // btnScriptZoomIn
            // 
            this.btnScriptZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btnScriptZoomIn.Image")));
            this.btnScriptZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnScriptZoomIn.Name = "btnScriptZoomIn";
            this.btnScriptZoomIn.Size = new System.Drawing.Size(72, 22);
            this.btnScriptZoomIn.Text = "Zoom In";
            this.btnScriptZoomIn.Click += new System.EventHandler(this.btnScriptZoomIn_Click);
            // 
            // btnScriptZoomOut
            // 
            this.btnScriptZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btnScriptZoomOut.Image")));
            this.btnScriptZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnScriptZoomOut.Name = "btnScriptZoomOut";
            this.btnScriptZoomOut.Size = new System.Drawing.Size(82, 22);
            this.btnScriptZoomOut.Text = "Zoom Out";
            this.btnScriptZoomOut.Click += new System.EventHandler(this.btnScriptZoomOut_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer3.Size = new System.Drawing.Size(207, 400);
            this.splitContainer3.SplitterDistance = 264;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvScript);
            this.groupBox1.Controls.Add(this.toolStrip3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 264);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "R Script Files";
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCreateScript,
            this.btnDeleteScript,
            this.btnReloadRScripts});
            this.toolStrip3.Location = new System.Drawing.Point(3, 16);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(201, 25);
            this.toolStrip3.TabIndex = 3;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // btnCreateScript
            // 
            this.btnCreateScript.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateScript.Image")));
            this.btnCreateScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateScript.Name = "btnCreateScript";
            this.btnCreateScript.Size = new System.Drawing.Size(51, 22);
            this.btnCreateScript.Text = "New";
            this.btnCreateScript.Click += new System.EventHandler(this.btnCreateScript_Click);
            // 
            // btnDeleteScript
            // 
            this.btnDeleteScript.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteScript.Image")));
            this.btnDeleteScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteScript.Name = "btnDeleteScript";
            this.btnDeleteScript.Size = new System.Drawing.Size(60, 22);
            this.btnDeleteScript.Text = "Delete";
            this.btnDeleteScript.Click += new System.EventHandler(this.btnDeleteScript_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtConsole);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(207, 132);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Console";
            // 
            // btnReloadRScripts
            // 
            this.btnReloadRScripts.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadRScripts.Image")));
            this.btnReloadRScripts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadRScripts.Name = "btnReloadRScripts";
            this.btnReloadRScripts.Size = new System.Drawing.Size(63, 22);
            this.btnReloadRScripts.Text = "Reload";
            this.btnReloadRScripts.Click += new System.EventHandler(this.btnReloadRScripts_Click);
            // 
            // FrmR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 425);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmR";
            this.Text = "R Editor";
            this.Load += new System.EventHandler(this.FrmR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.docData.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.docScript.ResumeLayout(false);
            this.docScript.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlScript;
        private System.Windows.Forms.ListView lvSource;
        private System.Windows.Forms.ListView lvScript;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lblWorkingDirectory;
        private System.Windows.Forms.ToolStripTextBox txtWorkingDirectory;
        private System.Windows.Forms.ToolStripButton btnBrowse;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox docData;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox docScript;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnRunScript;
        private System.Windows.Forms.ToolStripButton btnRefreshWorkingDirectory;
        private System.Windows.Forms.ToolStripButton btnSaveOutput;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton btnCreateScript;
        private System.Windows.Forms.ToolStripButton btnDeleteScript;
        private System.Windows.Forms.ToolStripButton btnReloadScript;
        private System.Windows.Forms.ToolStripButton btnSaveScript;
        private System.Windows.Forms.ToolStripButton btnScriptZoomIn;
        private System.Windows.Forms.ToolStripButton btnScriptZoomOut;
        private System.Windows.Forms.ToolStripButton btnOpenWorkingDirectory;
        private System.Windows.Forms.ToolStripButton btnReloadRScripts;
    }
}


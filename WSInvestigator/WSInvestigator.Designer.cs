///////////////////////////////////////////////////////////////////////////////////
/// Author:     Raymond Gao
/// Contact:    rgao@bea.com 
/// Date:       May 21, 2007
/// This mini app lists all "web services" installed in an ALUI app. 
/// This app is compiled with G6 MP1 server libraries.
/// This is an open-source project, no warranty or license available.
/// If you would like to participate in this project, 
/// please contact Ray Gao at mailto:rgao@bea.com or mailto:raygao2000@yahoo.com 
//////////////////////////////////////////////////////////////////////////////////

namespace wssearch
{
    partial class WSInvestigator
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.settingPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.separatorTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.serverL = new System.Windows.Forms.Label();
            this.uname = new System.Windows.Forms.TextBox();
            this.serverURL = new System.Windows.Forms.TextBox();
            this.pwd = new System.Windows.Forms.TextBox();
            this.searchTabControl = new System.Windows.Forms.TabControl();
            this.wsTabPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.activeCheckBox = new System.Windows.Forms.CheckBox();
            this.runWSButton = new System.Windows.Forms.Button();
            this.portletTabPage = new System.Windows.Forms.TabPage();
            this.runPortletButton = new System.Windows.Forms.Button();
            this.communityPageTabPage = new System.Windows.Forms.TabPage();
            this.runPageSearchButton = new System.Windows.Forms.Button();
            this.communityTabPage = new System.Windows.Forms.TabPage();
            this.runCommunityButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resultBox = new System.Windows.Forms.RichTextBox();
            this.resultDataGridView = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.wsSearchbackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.portletSearchBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.communitySearchBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.pageSearchBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.settingPanel.SuspendLayout();
            this.searchTabControl.SuspendLayout();
            this.wsTabPage.SuspendLayout();
            this.portletTabPage.SuspendLayout();
            this.communityPageTabPage.SuspendLayout();
            this.communityTabPage.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.settingPanel);
            this.splitContainer1.Panel1.Controls.Add(this.searchTabControl);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.splitContainer1.Panel2.Controls.Add(this.resultBox);
            this.splitContainer1.Panel2.Controls.Add(this.resultDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(1101, 597);
            this.splitContainer1.SplitterDistance = 257;
            this.splitContainer1.TabIndex = 11;
            // 
            // settingPanel
            // 
            this.settingPanel.Controls.Add(this.label2);
            this.settingPanel.Controls.Add(this.separatorTextBox);
            this.settingPanel.Controls.Add(this.usernameLabel);
            this.settingPanel.Controls.Add(this.passwordLabel);
            this.settingPanel.Controls.Add(this.serverL);
            this.settingPanel.Controls.Add(this.uname);
            this.settingPanel.Controls.Add(this.serverURL);
            this.settingPanel.Controls.Add(this.pwd);
            this.settingPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.settingPanel.Location = new System.Drawing.Point(0, 24);
            this.settingPanel.Name = "settingPanel";
            this.settingPanel.Size = new System.Drawing.Size(1101, 118);
            this.settingPanel.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(577, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "CSV File Field Separator Char:";
            // 
            // separatorTextBox
            // 
            this.separatorTextBox.Location = new System.Drawing.Point(732, 24);
            this.separatorTextBox.MaxLength = 1;
            this.separatorTextBox.Name = "separatorTextBox";
            this.separatorTextBox.Size = new System.Drawing.Size(24, 20);
            this.separatorTextBox.TabIndex = 21;
            this.separatorTextBox.Text = ";";
            this.separatorTextBox.TextChanged += new System.EventHandler(this.separatorTextBox_TextChanged);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(12, 54);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(95, 13);
            this.usernameLabel.TabIndex = 20;
            this.usernameLabel.Text = "Admin User Name:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(12, 84);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 19;
            this.passwordLabel.Text = "Password:";
            // 
            // serverL
            // 
            this.serverL.AutoSize = true;
            this.serverL.Location = new System.Drawing.Point(12, 27);
            this.serverL.Name = "serverL";
            this.serverL.Size = new System.Drawing.Size(391, 13);
            this.serverL.TabIndex = 10;
            this.serverL.Text = "API Server URL: (Server API DOES NOT support remote access. Localhost Only)";
            // 
            // uname
            // 
            this.uname.Location = new System.Drawing.Point(113, 54);
            this.uname.Name = "uname";
            this.uname.Size = new System.Drawing.Size(100, 20);
            this.uname.TabIndex = 14;
            this.uname.Text = "Administrator";
            // 
            // serverURL
            // 
            this.serverURL.Location = new System.Drawing.Point(352, 51);
            this.serverURL.Name = "serverURL";
            this.serverURL.Size = new System.Drawing.Size(285, 20);
            this.serverURL.TabIndex = 13;
            this.serverURL.Text = "http://localhost:11905/ptapi/services/QueryInterfaceAPI";
            this.serverURL.Visible = false;
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(113, 84);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(100, 20);
            this.pwd.TabIndex = 15;
            // 
            // searchTabControl
            // 
            this.searchTabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.searchTabControl.AllowDrop = true;
            this.searchTabControl.Controls.Add(this.wsTabPage);
            this.searchTabControl.Controls.Add(this.portletTabPage);
            this.searchTabControl.Controls.Add(this.communityPageTabPage);
            this.searchTabControl.Controls.Add(this.communityTabPage);
            this.searchTabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.searchTabControl.HotTrack = true;
            this.searchTabControl.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.searchTabControl.ItemSize = new System.Drawing.Size(77, 18);
            this.searchTabControl.Location = new System.Drawing.Point(0, 148);
            this.searchTabControl.Multiline = true;
            this.searchTabControl.Name = "searchTabControl";
            this.searchTabControl.SelectedIndex = 0;
            this.searchTabControl.ShowToolTips = true;
            this.searchTabControl.Size = new System.Drawing.Size(1101, 109);
            this.searchTabControl.TabIndex = 20;
            // 
            // wsTabPage
            // 
            this.wsTabPage.Controls.Add(this.label1);
            this.wsTabPage.Controls.Add(this.activeCheckBox);
            this.wsTabPage.Controls.Add(this.runWSButton);
            this.wsTabPage.Location = new System.Drawing.Point(4, 4);
            this.wsTabPage.Name = "wsTabPage";
            this.wsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.wsTabPage.Size = new System.Drawing.Size(1093, 83);
            this.wsTabPage.TabIndex = 0;
            this.wsTabPage.Text = "Web services";
            this.wsTabPage.ToolTipText = "Find Web Services Objects";
            this.wsTabPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Web Services Status:";
            // 
            // activeCheckBox
            // 
            this.activeCheckBox.AutoSize = true;
            this.activeCheckBox.Location = new System.Drawing.Point(136, 21);
            this.activeCheckBox.Name = "activeCheckBox";
            this.activeCheckBox.Size = new System.Drawing.Size(275, 17);
            this.activeCheckBox.TabIndex = 17;
            this.activeCheckBox.Text = "Show only active (Checked) / Show all (Unchecked)";
            this.activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // runWSButton
            // 
            this.runWSButton.Location = new System.Drawing.Point(103, 49);
            this.runWSButton.Name = "runWSButton";
            this.runWSButton.Size = new System.Drawing.Size(75, 23);
            this.runWSButton.TabIndex = 16;
            this.runWSButton.Text = "Run";
            this.runWSButton.UseVisualStyleBackColor = true;
            this.runWSButton.Click += new System.EventHandler(this.runWSButton_Click);
            // 
            // portletTabPage
            // 
            this.portletTabPage.Controls.Add(this.runPortletButton);
            this.portletTabPage.Location = new System.Drawing.Point(4, 4);
            this.portletTabPage.Name = "portletTabPage";
            this.portletTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.portletTabPage.Size = new System.Drawing.Size(1093, 83);
            this.portletTabPage.TabIndex = 1;
            this.portletTabPage.Text = "Portlets";
            this.portletTabPage.ToolTipText = "Find Portlet objects";
            this.portletTabPage.UseVisualStyleBackColor = true;
            // 
            // runPortletButton
            // 
            this.runPortletButton.Location = new System.Drawing.Point(53, 54);
            this.runPortletButton.Name = "runPortletButton";
            this.runPortletButton.Size = new System.Drawing.Size(75, 23);
            this.runPortletButton.TabIndex = 0;
            this.runPortletButton.Text = "Run";
            this.runPortletButton.UseVisualStyleBackColor = true;
            this.runPortletButton.Click += new System.EventHandler(this.runPortletButton_Click);
            // 
            // communityPageTabPage
            // 
            this.communityPageTabPage.Controls.Add(this.runPageSearchButton);
            this.communityPageTabPage.Location = new System.Drawing.Point(4, 4);
            this.communityPageTabPage.Name = "communityPageTabPage";
            this.communityPageTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.communityPageTabPage.Size = new System.Drawing.Size(1093, 83);
            this.communityPageTabPage.TabIndex = 2;
            this.communityPageTabPage.Text = "Pages";
            this.communityPageTabPage.ToolTipText = "Find Community Pages objects";
            this.communityPageTabPage.UseVisualStyleBackColor = true;
            // 
            // runPageSearchButton
            // 
            this.runPageSearchButton.Location = new System.Drawing.Point(93, 40);
            this.runPageSearchButton.Name = "runPageSearchButton";
            this.runPageSearchButton.Size = new System.Drawing.Size(75, 23);
            this.runPageSearchButton.TabIndex = 0;
            this.runPageSearchButton.Text = "Run";
            this.runPageSearchButton.UseVisualStyleBackColor = true;
            this.runPageSearchButton.Click += new System.EventHandler(this.runPageSearchButton_Click);
            // 
            // communityTabPage
            // 
            this.communityTabPage.Controls.Add(this.runCommunityButton);
            this.communityTabPage.Location = new System.Drawing.Point(4, 4);
            this.communityTabPage.Name = "communityTabPage";
            this.communityTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.communityTabPage.Size = new System.Drawing.Size(1093, 83);
            this.communityTabPage.TabIndex = 3;
            this.communityTabPage.Text = "Communities";
            this.communityTabPage.ToolTipText = "Find Community objects";
            this.communityTabPage.UseVisualStyleBackColor = true;
            // 
            // runCommunityButton
            // 
            this.runCommunityButton.Location = new System.Drawing.Point(91, 41);
            this.runCommunityButton.Name = "runCommunityButton";
            this.runCommunityButton.Size = new System.Drawing.Size(75, 23);
            this.runCommunityButton.TabIndex = 0;
            this.runCommunityButton.Text = "Run";
            this.runCommunityButton.UseVisualStyleBackColor = true;
            this.runCommunityButton.Click += new System.EventHandler(this.runCommunityButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1101, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // resultBox
            // 
            this.resultBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.resultBox.Location = new System.Drawing.Point(0, 255);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(1101, 81);
            this.resultBox.TabIndex = 7;
            this.resultBox.Text = "Status:";
            // 
            // resultDataGridView
            // 
            this.resultDataGridView.AllowUserToAddRows = false;
            this.resultDataGridView.AllowUserToDeleteRows = false;
            this.resultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultDataGridView.Location = new System.Drawing.Point(0, 0);
            this.resultDataGridView.Margin = new System.Windows.Forms.Padding(20);
            this.resultDataGridView.Name = "resultDataGridView";
            this.resultDataGridView.ReadOnly = true;
            this.resultDataGridView.Size = new System.Drawing.Size(1101, 336);
            this.resultDataGridView.TabIndex = 10;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.FileName = "ws_report.csv";
            this.saveFileDialog1.InitialDirectory = "c:\\csv";
            // 
            // wsSearchbackgroundWorker1
            // 
            this.wsSearchbackgroundWorker1.WorkerReportsProgress = true;
            this.wsSearchbackgroundWorker1.WorkerSupportsCancellation = true;
            this.wsSearchbackgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wsSearchBackgroundWorker);
            // 
            // portletSearchBackgroundWorker
            // 
            this.portletSearchBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.portletSearchBackgroundWorker_DoWork);
            // 
            // communitySearchBackgroundWorker
            // 
            this.communitySearchBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.communitySearchBackgroundWorker_DoWork);
            // 
            // pageSearchBackgroundWorker
            // 
            this.pageSearchBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.pageSearchBackgroundWorker_DoWork);
            // 
            // WSInvestigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 597);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "WSInvestigator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquid Ice (Web Services Investigator)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.settingPanel.ResumeLayout(false);
            this.settingPanel.PerformLayout();
            this.searchTabControl.ResumeLayout(false);
            this.wsTabPage.ResumeLayout(false);
            this.wsTabPage.PerformLayout();
            this.portletTabPage.ResumeLayout(false);
            this.communityPageTabPage.ResumeLayout(false);
            this.communityTabPage.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.RichTextBox resultBox;
        private System.Windows.Forms.DataGridView resultDataGridView;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.ComponentModel.BackgroundWorker wsSearchbackgroundWorker1;
        private System.Windows.Forms.TabControl searchTabControl;
        private System.Windows.Forms.TabPage wsTabPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox activeCheckBox;
        private System.Windows.Forms.Button runWSButton;
        private System.Windows.Forms.TabPage portletTabPage;
        private System.Windows.Forms.TabPage communityPageTabPage;
        private System.Windows.Forms.TabPage communityTabPage;
        private System.Windows.Forms.Panel settingPanel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label serverL;
        private System.Windows.Forms.TextBox uname;
        private System.Windows.Forms.TextBox serverURL;
        private System.Windows.Forms.TextBox pwd;
        private System.Windows.Forms.Button runPortletButton;
        private System.ComponentModel.BackgroundWorker portletSearchBackgroundWorker;
        private System.Windows.Forms.Button runCommunityButton;
        private System.ComponentModel.BackgroundWorker communitySearchBackgroundWorker;
        private System.Windows.Forms.Button runPageSearchButton;
        private System.ComponentModel.BackgroundWorker pageSearchBackgroundWorker;
        private System.Windows.Forms.TextBox separatorTextBox;
        private System.Windows.Forms.Label label2;

    }
}


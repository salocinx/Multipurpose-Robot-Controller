namespace RemoteCtrl {
    partial class RemoteGui {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteGui));
            this.mnuMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.itmQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.itmDetachControllerView = new System.Windows.Forms.ToolStripMenuItem();
            this.itmDetachCameraControllerViews = new System.Windows.Forms.ToolStripMenuItem();
            this.itmDetachServoControllerViews = new System.Windows.Forms.ToolStripMenuItem();
            this.itmDetachControllerViews = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSpeechSynthesizerTool = new System.Windows.Forms.ToolStripMenuItem();
            this.itmServoTimeLineTool = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxAgents = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxConnectAgent = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDisconnectAgent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxRestartAgent = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxShutdownAgent = new System.Windows.Forms.ToolStripMenuItem();
            this.boxAutoConnect = new System.Windows.Forms.CheckBox();
            this.grpAutoConnect = new System.Windows.Forms.GroupBox();
            this.pnlTabControl = new System.Windows.Forms.Panel();
            this.lstAgents = new System.Windows.Forms.BasicListView();
            this.mnuMenu.SuspendLayout();
            this.ctxAgents.SuspendLayout();
            this.grpAutoConnect.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMenu
            // 
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuView,
            this.mnuTools});
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(1126, 24);
            this.mnuMenu.TabIndex = 10;
            this.mnuMenu.Text = "Main Strip";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmQuit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // itmQuit
            // 
            this.itmQuit.Name = "itmQuit";
            this.itmQuit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Q)));
            this.itmQuit.Size = new System.Drawing.Size(136, 22);
            this.itmQuit.Text = "Quit";
            this.itmQuit.Click += new System.EventHandler(this.itmQuit_Click);
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmDetachControllerView,
            this.itmDetachControllerViews});
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(44, 20);
            this.mnuView.Text = "View";
            // 
            // itmDetachControllerView
            // 
            this.itmDetachControllerView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmDetachCameraControllerViews,
            this.itmDetachServoControllerViews});
            this.itmDetachControllerView.Name = "itmDetachControllerView";
            this.itmDetachControllerView.Size = new System.Drawing.Size(238, 22);
            this.itmDetachControllerView.Text = "Detach Controller View";
            // 
            // itmDetachCameraControllerViews
            // 
            this.itmDetachCameraControllerViews.Name = "itmDetachCameraControllerViews";
            this.itmDetachCameraControllerViews.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.itmDetachCameraControllerViews.Size = new System.Drawing.Size(282, 22);
            this.itmDetachCameraControllerViews.Text = "Detach Camera Controller Views";
            this.itmDetachCameraControllerViews.Click += new System.EventHandler(this.itmDetachCameraControllerViews_Click);
            // 
            // itmDetachServoControllerViews
            // 
            this.itmDetachServoControllerViews.Name = "itmDetachServoControllerViews";
            this.itmDetachServoControllerViews.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.itmDetachServoControllerViews.Size = new System.Drawing.Size(282, 22);
            this.itmDetachServoControllerViews.Text = "Detach Servo Controller Views";
            this.itmDetachServoControllerViews.Click += new System.EventHandler(this.itmDetachServoControllerViews_Click);
            // 
            // itmDetachControllerViews
            // 
            this.itmDetachControllerViews.Name = "itmDetachControllerViews";
            this.itmDetachControllerViews.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.itmDetachControllerViews.Size = new System.Drawing.Size(238, 22);
            this.itmDetachControllerViews.Text = "Detach Controller Views";
            this.itmDetachControllerViews.Click += new System.EventHandler(this.itmDetachControllerViews_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmSpeechSynthesizerTool,
            this.itmServoTimeLineTool});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(47, 20);
            this.mnuTools.Text = "Tools";
            // 
            // itmSpeechSynthesizerTool
            // 
            this.itmSpeechSynthesizerTool.Enabled = false;
            this.itmSpeechSynthesizerTool.Name = "itmSpeechSynthesizerTool";
            this.itmSpeechSynthesizerTool.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.itmSpeechSynthesizerTool.Size = new System.Drawing.Size(199, 22);
            this.itmSpeechSynthesizerTool.Text = "Speech Synthesizer";
            this.itmSpeechSynthesizerTool.Click += new System.EventHandler(this.itmSpeechSynthesizerTool_Click);
            // 
            // itmServoTimeLineTool
            // 
            this.itmServoTimeLineTool.Enabled = false;
            this.itmServoTimeLineTool.Name = "itmServoTimeLineTool";
            this.itmServoTimeLineTool.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.itmServoTimeLineTool.Size = new System.Drawing.Size(199, 22);
            this.itmServoTimeLineTool.Text = "Servo Action Library";
            this.itmServoTimeLineTool.Click += new System.EventHandler(this.itmServoTimeLineTool_Click);
            // 
            // ctxAgents
            // 
            this.ctxAgents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxConnectAgent,
            this.ctxDisconnectAgent,
            this.toolStripSeparator1,
            this.ctxRestartAgent,
            this.ctxShutdownAgent});
            this.ctxAgents.Name = "ctxAgents";
            this.ctxAgents.Size = new System.Drawing.Size(134, 98);
            // 
            // ctxConnectAgent
            // 
            this.ctxConnectAgent.Image = global::RemoteCtrl.Properties.Resources.connect_18;
            this.ctxConnectAgent.Name = "ctxConnectAgent";
            this.ctxConnectAgent.Size = new System.Drawing.Size(133, 22);
            this.ctxConnectAgent.Text = "Connect";
            this.ctxConnectAgent.Click += new System.EventHandler(this.ctxConnectAgent_Click);
            // 
            // ctxDisconnectAgent
            // 
            this.ctxDisconnectAgent.Enabled = false;
            this.ctxDisconnectAgent.Image = global::RemoteCtrl.Properties.Resources.disconnect_18;
            this.ctxDisconnectAgent.Name = "ctxDisconnectAgent";
            this.ctxDisconnectAgent.Size = new System.Drawing.Size(133, 22);
            this.ctxDisconnectAgent.Text = "Disconnect";
            this.ctxDisconnectAgent.Click += new System.EventHandler(this.ctxDisconnectAgent_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(130, 6);
            // 
            // ctxRestartAgent
            // 
            this.ctxRestartAgent.Enabled = false;
            this.ctxRestartAgent.Image = global::RemoteCtrl.Properties.Resources.restart_18;
            this.ctxRestartAgent.Name = "ctxRestartAgent";
            this.ctxRestartAgent.Size = new System.Drawing.Size(133, 22);
            this.ctxRestartAgent.Text = "Restart";
            this.ctxRestartAgent.Click += new System.EventHandler(this.ctxRestartAgent_Click);
            // 
            // ctxShutdownAgent
            // 
            this.ctxShutdownAgent.Enabled = false;
            this.ctxShutdownAgent.Image = global::RemoteCtrl.Properties.Resources.shutdown_18;
            this.ctxShutdownAgent.Name = "ctxShutdownAgent";
            this.ctxShutdownAgent.Size = new System.Drawing.Size(133, 22);
            this.ctxShutdownAgent.Text = "Shutdown";
            this.ctxShutdownAgent.Click += new System.EventHandler(this.ctxShutdownAgent_Click);
            // 
            // boxAutoConnect
            // 
            this.boxAutoConnect.AutoSize = true;
            this.boxAutoConnect.Checked = true;
            this.boxAutoConnect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxAutoConnect.Enabled = false;
            this.boxAutoConnect.Location = new System.Drawing.Point(8, 15);
            this.boxAutoConnect.Name = "boxAutoConnect";
            this.boxAutoConnect.Size = new System.Drawing.Size(173, 17);
            this.boxAutoConnect.TabIndex = 11;
            this.boxAutoConnect.Text = "Auto Connect Available Agents";
            this.boxAutoConnect.UseVisualStyleBackColor = true;
            // 
            // grpAutoConnect
            // 
            this.grpAutoConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpAutoConnect.Controls.Add(this.boxAutoConnect);
            this.grpAutoConnect.Location = new System.Drawing.Point(12, 521);
            this.grpAutoConnect.Name = "grpAutoConnect";
            this.grpAutoConnect.Size = new System.Drawing.Size(242, 40);
            this.grpAutoConnect.TabIndex = 12;
            this.grpAutoConnect.TabStop = false;
            // 
            // pnlTabControl
            // 
            this.pnlTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTabControl.Location = new System.Drawing.Point(260, 31);
            this.pnlTabControl.Name = "pnlTabControl";
            this.pnlTabControl.Size = new System.Drawing.Size(854, 530);
            this.pnlTabControl.TabIndex = 13;
            // 
            // lstAgents
            // 
            this.lstAgents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstAgents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstAgents.Location = new System.Drawing.Point(12, 31);
            this.lstAgents.MultiSelect = false;
            this.lstAgents.Name = "lstAgents";
            this.lstAgents.Size = new System.Drawing.Size(242, 489);
            this.lstAgents.TabIndex = 9;
            this.lstAgents.UseCompatibleStateImageBehavior = false;
            this.lstAgents.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstAgents_ItemSelectionChanged);
            this.lstAgents.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstAgents_MouseClick);
            // 
            // RemoteGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 573);
            this.Controls.Add(this.pnlTabControl);
            this.Controls.Add(this.grpAutoConnect);
            this.Controls.Add(this.lstAgents);
            this.Controls.Add(this.mnuMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMenu;
            this.MinimumSize = new System.Drawing.Size(1142, 612);
            this.Name = "RemoteGui";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remote Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_Closing);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.ctxAgents.ResumeLayout(false);
            this.grpAutoConnect.ResumeLayout(false);
            this.grpAutoConnect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion  
        private System.Windows.Forms.BasicListView lstAgents;
        private System.Windows.Forms.MenuStrip mnuMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem itmQuit;
        private System.Windows.Forms.ContextMenuStrip ctxAgents;
        private System.Windows.Forms.ToolStripMenuItem ctxConnectAgent;
        private System.Windows.Forms.ToolStripMenuItem ctxDisconnectAgent;
        private System.Windows.Forms.CheckBox boxAutoConnect;
        private System.Windows.Forms.GroupBox grpAutoConnect;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem itmDetachControllerViews;
        private System.Windows.Forms.ToolStripMenuItem itmDetachControllerView;
        private System.Windows.Forms.ToolStripMenuItem itmDetachCameraControllerViews;
        private System.Windows.Forms.ToolStripMenuItem itmDetachServoControllerViews;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem itmServoTimeLineTool;
        private System.Windows.Forms.ToolStripMenuItem itmSpeechSynthesizerTool;
        private System.Windows.Forms.ToolStripMenuItem ctxRestartAgent;
        private System.Windows.Forms.ToolStripMenuItem ctxShutdownAgent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel pnlTabControl;
    }
}


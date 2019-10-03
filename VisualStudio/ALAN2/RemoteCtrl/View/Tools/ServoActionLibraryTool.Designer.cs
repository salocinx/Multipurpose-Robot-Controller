namespace RemoteCtrl {
    partial class ServoActionLibraryTool {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
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
            this.lstServoActions = new System.Windows.Forms.ListView();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.itmQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.lblServo = new System.Windows.Forms.Label();
            this.cbxServo = new System.Windows.Forms.ComboBox();
            this.pnlServoLayers = new System.Windows.Forms.Panel();
            this.tlcServoLayers = new RemoteCtrl.TimeLineControl();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.trkSpeed = new System.Windows.Forms.TrackBar();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdPlay = new System.Windows.Forms.Button();
            this.lstServoLayers = new System.Windows.Forms.Panel();
            this.lblActionName = new System.Windows.Forms.Label();
            this.txtActionName = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblZoom = new System.Windows.Forms.Label();
            this.trkZoom = new System.Windows.Forms.TrackBar();
            this.ctxServoActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmNewAction = new System.Windows.Forms.ToolStripMenuItem();
            this.itmDuplicateAction = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itmDeleteAction = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxServoLayers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmNewLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.itmDuplicateLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.itmDeleteLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.layActionLayers = new System.Windows.Forms.TableLayoutPanel();
            this.mnuMain.SuspendLayout();
            this.pnlServoLayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkZoom)).BeginInit();
            this.ctxServoActions.SuspendLayout();
            this.ctxServoLayers.SuspendLayout();
            this.layActionLayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstServoActions
            // 
            this.lstServoActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstServoActions.Location = new System.Drawing.Point(3, 3);
            this.lstServoActions.MultiSelect = false;
            this.lstServoActions.Name = "lstServoActions";
            this.lstServoActions.Size = new System.Drawing.Size(313, 276);
            this.lstServoActions.TabIndex = 0;
            this.lstServoActions.UseCompatibleStateImageBehavior = false;
            this.lstServoActions.SelectedIndexChanged += new System.EventHandler(this.lstServoActions_SelectedIndexChanged);
            this.lstServoActions.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstServoActions_MouseUp);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1434, 24);
            this.mnuMain.TabIndex = 6;
            this.mnuMain.Text = "Menu";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmSave,
            this.itmQuit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // itmSave
            // 
            this.itmSave.Name = "itmSave";
            this.itmSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.itmSave.Size = new System.Drawing.Size(138, 22);
            this.itmSave.Text = "Save";
            this.itmSave.Click += new System.EventHandler(this.itmSave_Click);
            // 
            // itmQuit
            // 
            this.itmQuit.Name = "itmQuit";
            this.itmQuit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Q)));
            this.itmQuit.Size = new System.Drawing.Size(138, 22);
            this.itmQuit.Text = "Exit";
            this.itmQuit.Click += new System.EventHandler(this.itmExit_Click);
            // 
            // lblServo
            // 
            this.lblServo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblServo.AutoSize = true;
            this.lblServo.Location = new System.Drawing.Point(443, 574);
            this.lblServo.Name = "lblServo";
            this.lblServo.Size = new System.Drawing.Size(38, 13);
            this.lblServo.TabIndex = 19;
            this.lblServo.Text = "Servo:";
            // 
            // cbxServo
            // 
            this.cbxServo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxServo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServo.Enabled = false;
            this.cbxServo.FormattingEnabled = true;
            this.cbxServo.Location = new System.Drawing.Point(487, 571);
            this.cbxServo.Name = "cbxServo";
            this.cbxServo.Size = new System.Drawing.Size(179, 21);
            this.cbxServo.TabIndex = 18;
            this.cbxServo.SelectedIndexChanged += new System.EventHandler(this.cbxServo_SelectedIndexChanged);
            // 
            // pnlServoLayers
            // 
            this.pnlServoLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlServoLayers.AutoScroll = true;
            this.pnlServoLayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlServoLayers.Controls.Add(this.tlcServoLayers);
            this.pnlServoLayers.Location = new System.Drawing.Point(337, 27);
            this.pnlServoLayers.Name = "pnlServoLayers";
            this.pnlServoLayers.Size = new System.Drawing.Size(1087, 503);
            this.pnlServoLayers.TabIndex = 17;
            // 
            // tlcServoLayers
            // 
            this.tlcServoLayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tlcServoLayers.BackColor = System.Drawing.Color.White;
            this.tlcServoLayers.Location = new System.Drawing.Point(2, 3);
            this.tlcServoLayers.Name = "tlcServoLayers";
            this.tlcServoLayers.Size = new System.Drawing.Size(25000, 499);
            this.tlcServoLayers.TabIndex = 0;
            // 
            // lblSpeed
            // 
            this.lblSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(958, 548);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(76, 13);
            this.lblSpeed.TabIndex = 16;
            this.lblSpeed.Text = "Speed [100%]:";
            // 
            // trkSpeed
            // 
            this.trkSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trkSpeed.Enabled = false;
            this.trkSpeed.Location = new System.Drawing.Point(1040, 545);
            this.trkSpeed.Maximum = 100;
            this.trkSpeed.Minimum = 10;
            this.trkSpeed.Name = "trkSpeed";
            this.trkSpeed.Size = new System.Drawing.Size(160, 45);
            this.trkSpeed.TabIndex = 15;
            this.trkSpeed.TickFrequency = 5;
            this.trkSpeed.Value = 100;
            this.trkSpeed.ValueChanged += new System.EventHandler(this.trkSpeed_ValueChanged);
            // 
            // cmdReset
            // 
            this.cmdReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdReset.Enabled = false;
            this.cmdReset.Location = new System.Drawing.Point(1218, 545);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(100, 47);
            this.cmdReset.TabIndex = 14;
            this.cmdReset.Text = "Reset Servos";
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdPlay
            // 
            this.cmdPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPlay.Enabled = false;
            this.cmdPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPlay.Location = new System.Drawing.Point(1324, 545);
            this.cmdPlay.Name = "cmdPlay";
            this.cmdPlay.Size = new System.Drawing.Size(100, 47);
            this.cmdPlay.TabIndex = 13;
            this.cmdPlay.Text = "Play";
            this.cmdPlay.UseVisualStyleBackColor = true;
            this.cmdPlay.Click += new System.EventHandler(this.cmdPlay_Click);
            // 
            // lstServoLayers
            // 
            this.lstServoLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstServoLayers.AutoScroll = true;
            this.lstServoLayers.BackColor = System.Drawing.Color.White;
            this.lstServoLayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstServoLayers.Location = new System.Drawing.Point(3, 285);
            this.lstServoLayers.Name = "lstServoLayers";
            this.lstServoLayers.Size = new System.Drawing.Size(313, 277);
            this.lstServoLayers.TabIndex = 23;
            this.lstServoLayers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstServoLayers_MouseClick);
            // 
            // lblActionName
            // 
            this.lblActionName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblActionName.AutoSize = true;
            this.lblActionName.Location = new System.Drawing.Point(443, 548);
            this.lblActionName.Name = "lblActionName";
            this.lblActionName.Size = new System.Drawing.Size(38, 13);
            this.lblActionName.TabIndex = 24;
            this.lblActionName.Text = "Name:";
            // 
            // txtActionName
            // 
            this.txtActionName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtActionName.Location = new System.Drawing.Point(487, 545);
            this.txtActionName.Name = "txtActionName";
            this.txtActionName.Size = new System.Drawing.Size(179, 20);
            this.txtActionName.TabIndex = 25;
            this.txtActionName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtActionName_KeyUp);
            this.txtActionName.Leave += new System.EventHandler(this.txtActionName_Leave);
            // 
            // lblId
            // 
            this.lblId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(336, 548);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 13);
            this.lblId.TabIndex = 28;
            this.lblId.Text = "ID:";
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(363, 545);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(62, 20);
            this.txtId.TabIndex = 29;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblZoom
            // 
            this.lblZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblZoom.AutoSize = true;
            this.lblZoom.Location = new System.Drawing.Point(696, 548);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(72, 13);
            this.lblZoom.TabIndex = 31;
            this.lblZoom.Text = "Zoom [100%]:";
            // 
            // trkZoom
            // 
            this.trkZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trkZoom.Enabled = false;
            this.trkZoom.Location = new System.Drawing.Point(774, 545);
            this.trkZoom.Maximum = 200;
            this.trkZoom.Minimum = 25;
            this.trkZoom.Name = "trkZoom";
            this.trkZoom.Size = new System.Drawing.Size(160, 45);
            this.trkZoom.TabIndex = 30;
            this.trkZoom.TickFrequency = 5;
            this.trkZoom.Value = 100;
            this.trkZoom.ValueChanged += new System.EventHandler(this.trkZoom_ValueChanged);
            // 
            // ctxServoActions
            // 
            this.ctxServoActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmNewAction,
            this.itmDuplicateAction,
            this.toolStripSeparator1,
            this.itmDeleteAction});
            this.ctxServoActions.Name = "ctxServoActions";
            this.ctxServoActions.Size = new System.Drawing.Size(174, 76);
            // 
            // itmNewAction
            // 
            this.itmNewAction.Image = global::RemoteCtrl.Properties.Resources.create_18;
            this.itmNewAction.Name = "itmNewAction";
            this.itmNewAction.Size = new System.Drawing.Size(173, 22);
            this.itmNewAction.Text = "Create New Action";
            this.itmNewAction.Click += new System.EventHandler(this.itmNewAction_Click);
            // 
            // itmDuplicateAction
            // 
            this.itmDuplicateAction.Image = global::RemoteCtrl.Properties.Resources.duplicate_18;
            this.itmDuplicateAction.Name = "itmDuplicateAction";
            this.itmDuplicateAction.Size = new System.Drawing.Size(173, 22);
            this.itmDuplicateAction.Text = "Duplicate Action";
            this.itmDuplicateAction.Click += new System.EventHandler(this.itmDuplicateAction_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // itmDeleteAction
            // 
            this.itmDeleteAction.Image = global::RemoteCtrl.Properties.Resources.remove_18;
            this.itmDeleteAction.Name = "itmDeleteAction";
            this.itmDeleteAction.Size = new System.Drawing.Size(173, 22);
            this.itmDeleteAction.Text = "Delete Action";
            this.itmDeleteAction.Click += new System.EventHandler(this.itmDeleteAction_Click);
            // 
            // ctxServoLayers
            // 
            this.ctxServoLayers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmNewLayer,
            this.itmDuplicateLayer,
            this.toolStripSeparator2,
            this.itmDeleteLayer});
            this.ctxServoLayers.Name = "ctxServoLayers";
            this.ctxServoLayers.Size = new System.Drawing.Size(167, 76);
            // 
            // itmNewLayer
            // 
            this.itmNewLayer.Image = global::RemoteCtrl.Properties.Resources.create_18;
            this.itmNewLayer.Name = "itmNewLayer";
            this.itmNewLayer.Size = new System.Drawing.Size(166, 22);
            this.itmNewLayer.Text = "Create New Layer";
            this.itmNewLayer.Click += new System.EventHandler(this.itmNewLayer_Click);
            // 
            // itmDuplicateLayer
            // 
            this.itmDuplicateLayer.Image = global::RemoteCtrl.Properties.Resources.duplicate_18;
            this.itmDuplicateLayer.Name = "itmDuplicateLayer";
            this.itmDuplicateLayer.Size = new System.Drawing.Size(166, 22);
            this.itmDuplicateLayer.Text = "Duplicate Layer";
            this.itmDuplicateLayer.Click += new System.EventHandler(this.itmDuplicateLayer_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(163, 6);
            // 
            // itmDeleteLayer
            // 
            this.itmDeleteLayer.Image = global::RemoteCtrl.Properties.Resources.remove_18;
            this.itmDeleteLayer.Name = "itmDeleteLayer";
            this.itmDeleteLayer.Size = new System.Drawing.Size(166, 22);
            this.itmDeleteLayer.Text = "Delete Layer";
            this.itmDeleteLayer.Click += new System.EventHandler(this.itmDeleteLayer_Click);
            // 
            // layActionLayers
            // 
            this.layActionLayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.layActionLayers.ColumnCount = 1;
            this.layActionLayers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layActionLayers.Controls.Add(this.lstServoActions, 0, 0);
            this.layActionLayers.Controls.Add(this.lstServoLayers, 0, 1);
            this.layActionLayers.Location = new System.Drawing.Point(12, 27);
            this.layActionLayers.Name = "layActionLayers";
            this.layActionLayers.RowCount = 2;
            this.layActionLayers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layActionLayers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layActionLayers.Size = new System.Drawing.Size(319, 565);
            this.layActionLayers.TabIndex = 32;
            // 
            // ServoActionLibraryTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 601);
            this.Controls.Add(this.layActionLayers);
            this.Controls.Add(this.lblZoom);
            this.Controls.Add(this.trkZoom);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtActionName);
            this.Controls.Add(this.lblActionName);
            this.Controls.Add(this.lblServo);
            this.Controls.Add(this.cbxServo);
            this.Controls.Add(this.pnlServoLayers);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.trkSpeed);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.cmdPlay);
            this.Controls.Add(this.mnuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.mnuMain;
            this.MinimumSize = new System.Drawing.Size(1450, 640);
            this.Name = "ServoActionLibraryTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Servo Action Library";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServoTimeLineApplication_FormClosing);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.pnlServoLayers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trkSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkZoom)).EndInit();
            this.ctxServoActions.ResumeLayout(false);
            this.ctxServoLayers.ResumeLayout(false);
            this.layActionLayers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstServoActions;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem itmQuit;
        private System.Windows.Forms.ToolStripMenuItem itmSave;
        private System.Windows.Forms.Label lblServo;
        private System.Windows.Forms.ComboBox cbxServo;
        private System.Windows.Forms.Panel pnlServoLayers;
        private TimeLineControl tlcServoLayers;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.TrackBar trkSpeed;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdPlay;
        private System.Windows.Forms.Panel lstServoLayers;
        private System.Windows.Forms.Label lblActionName;
        private System.Windows.Forms.TextBox txtActionName;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.TrackBar trkZoom;
        private System.Windows.Forms.ContextMenuStrip ctxServoActions;
        private System.Windows.Forms.ToolStripMenuItem itmNewAction;
        private System.Windows.Forms.ToolStripMenuItem itmDuplicateAction;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem itmDeleteAction;
        private System.Windows.Forms.ContextMenuStrip ctxServoLayers;
        private System.Windows.Forms.ToolStripMenuItem itmNewLayer;
        private System.Windows.Forms.ToolStripMenuItem itmDuplicateLayer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem itmDeleteLayer;
        private System.Windows.Forms.TableLayoutPanel layActionLayers;
    }
}
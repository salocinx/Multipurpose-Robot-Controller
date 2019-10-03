namespace RemoteCtrl {
    partial class SpeechSynthesizerTool {
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
            this.lstSpeechActions = new System.Windows.Forms.ListView();
            this.grpSynthesizerProperties = new System.Windows.Forms.GroupBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.cmdSpeak = new System.Windows.Forms.Button();
            this.boxClear = new System.Windows.Forms.CheckBox();
            this.trkPitch = new System.Windows.Forms.TrackBar();
            this.lblText = new System.Windows.Forms.Label();
            this.txtPitch = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.trkSpeed = new System.Windows.Forms.TrackBar();
            this.txtWordGap = new System.Windows.Forms.Label();
            this.txtSpeed = new System.Windows.Forms.Label();
            this.trkWordGap = new System.Windows.Forms.TrackBar();
            this.trkAmplitude = new System.Windows.Forms.TrackBar();
            this.txtAmplitude = new System.Windows.Forms.Label();
            this.mnuMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSpeechActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmNewAction = new System.Windows.Forms.ToolStripMenuItem();
            this.itmDuplicateAction = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itmDeleteAction = new System.Windows.Forms.ToolStripMenuItem();
            this.grpSynthesizerProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkWordGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkAmplitude)).BeginInit();
            this.mnuMenu.SuspendLayout();
            this.ctxSpeechActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstSpeechActions
            // 
            this.lstSpeechActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstSpeechActions.Location = new System.Drawing.Point(12, 36);
            this.lstSpeechActions.MultiSelect = false;
            this.lstSpeechActions.Name = "lstSpeechActions";
            this.lstSpeechActions.Size = new System.Drawing.Size(372, 421);
            this.lstSpeechActions.TabIndex = 12;
            this.lstSpeechActions.UseCompatibleStateImageBehavior = false;
            this.lstSpeechActions.SelectedIndexChanged += new System.EventHandler(this.lstSpeechActions_SelectedIndexChanged);
            this.lstSpeechActions.DoubleClick += new System.EventHandler(this.cmdSpeak_Click);
            this.lstSpeechActions.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstSpeechActions_MouseUp);
            // 
            // grpSynthesizerProperties
            // 
            this.grpSynthesizerProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSynthesizerProperties.Controls.Add(this.txtId);
            this.grpSynthesizerProperties.Controls.Add(this.lblId);
            this.grpSynthesizerProperties.Controls.Add(this.cmdSpeak);
            this.grpSynthesizerProperties.Controls.Add(this.boxClear);
            this.grpSynthesizerProperties.Controls.Add(this.trkPitch);
            this.grpSynthesizerProperties.Controls.Add(this.lblText);
            this.grpSynthesizerProperties.Controls.Add(this.txtPitch);
            this.grpSynthesizerProperties.Controls.Add(this.txtText);
            this.grpSynthesizerProperties.Controls.Add(this.trkSpeed);
            this.grpSynthesizerProperties.Controls.Add(this.txtWordGap);
            this.grpSynthesizerProperties.Controls.Add(this.txtSpeed);
            this.grpSynthesizerProperties.Controls.Add(this.trkWordGap);
            this.grpSynthesizerProperties.Controls.Add(this.trkAmplitude);
            this.grpSynthesizerProperties.Controls.Add(this.txtAmplitude);
            this.grpSynthesizerProperties.Location = new System.Drawing.Point(390, 36);
            this.grpSynthesizerProperties.Name = "grpSynthesizerProperties";
            this.grpSynthesizerProperties.Size = new System.Drawing.Size(541, 421);
            this.grpSynthesizerProperties.TabIndex = 16;
            this.grpSynthesizerProperties.TabStop = false;
            this.grpSynthesizerProperties.Text = "Synthesizer Properties";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(42, 380);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(62, 20);
            this.txtId.TabIndex = 31;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(15, 383);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 13);
            this.lblId.TabIndex = 30;
            this.lblId.Text = "ID:";
            // 
            // cmdSpeak
            // 
            this.cmdSpeak.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSpeak.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSpeak.Location = new System.Drawing.Point(125, 375);
            this.cmdSpeak.Name = "cmdSpeak";
            this.cmdSpeak.Size = new System.Drawing.Size(397, 29);
            this.cmdSpeak.TabIndex = 11;
            this.cmdSpeak.Text = "Speak";
            this.cmdSpeak.UseVisualStyleBackColor = true;
            this.cmdSpeak.Click += new System.EventHandler(this.cmdSpeak_Click);
            // 
            // boxClear
            // 
            this.boxClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxClear.AutoSize = true;
            this.boxClear.Location = new System.Drawing.Point(386, 68);
            this.boxClear.Name = "boxClear";
            this.boxClear.Size = new System.Drawing.Size(139, 17);
            this.boxClear.TabIndex = 10;
            this.boxClear.Text = "Clear Text After Speech";
            this.boxClear.UseVisualStyleBackColor = true;
            // 
            // trkPitch
            // 
            this.trkPitch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trkPitch.Location = new System.Drawing.Point(13, 172);
            this.trkPitch.Maximum = 99;
            this.trkPitch.Name = "trkPitch";
            this.trkPitch.Size = new System.Drawing.Size(506, 45);
            this.trkPitch.TabIndex = 0;
            this.trkPitch.TickFrequency = 2;
            this.trkPitch.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trkPitch.Value = 50;
            this.trkPitch.ValueChanged += new System.EventHandler(this.trkPitch_ValueChanged);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(16, 26);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(80, 13);
            this.lblText.TabIndex = 9;
            this.lblText.Text = "Text to Speech";
            // 
            // txtPitch
            // 
            this.txtPitch.AutoSize = true;
            this.txtPitch.Location = new System.Drawing.Point(16, 156);
            this.txtPitch.Name = "txtPitch";
            this.txtPitch.Size = new System.Drawing.Size(118, 13);
            this.txtPitch.TabIndex = 1;
            this.txtPitch.Text = "Voice Pitch: 50   [0, 99]";
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.Location = new System.Drawing.Point(19, 42);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(503, 20);
            this.txtText.TabIndex = 8;
            this.txtText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtText_KeyUp);
            this.txtText.Leave += new System.EventHandler(this.txtText_Leave);
            // 
            // trkSpeed
            // 
            this.trkSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trkSpeed.Location = new System.Drawing.Point(13, 241);
            this.trkSpeed.Maximum = 450;
            this.trkSpeed.Minimum = 80;
            this.trkSpeed.Name = "trkSpeed";
            this.trkSpeed.Size = new System.Drawing.Size(506, 45);
            this.trkSpeed.TabIndex = 2;
            this.trkSpeed.TickFrequency = 5;
            this.trkSpeed.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trkSpeed.Value = 175;
            this.trkSpeed.ValueChanged += new System.EventHandler(this.trkSpeed_ValueChanged);
            // 
            // txtWordGap
            // 
            this.txtWordGap.AutoSize = true;
            this.txtWordGap.Location = new System.Drawing.Point(16, 294);
            this.txtWordGap.Name = "txtWordGap";
            this.txtWordGap.Size = new System.Drawing.Size(161, 13);
            this.txtWordGap.TabIndex = 7;
            this.txtWordGap.Text = "Voice Word Gap: 10   [10, 1000]";
            // 
            // txtSpeed
            // 
            this.txtSpeed.AutoSize = true;
            this.txtSpeed.Location = new System.Drawing.Point(16, 225);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(143, 13);
            this.txtSpeed.TabIndex = 3;
            this.txtSpeed.Text = "Voice Speed: 175   [80, 450]";
            // 
            // trkWordGap
            // 
            this.trkWordGap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trkWordGap.LargeChange = 10;
            this.trkWordGap.Location = new System.Drawing.Point(13, 310);
            this.trkWordGap.Maximum = 1000;
            this.trkWordGap.Minimum = 10;
            this.trkWordGap.Name = "trkWordGap";
            this.trkWordGap.Size = new System.Drawing.Size(506, 45);
            this.trkWordGap.TabIndex = 6;
            this.trkWordGap.TickFrequency = 10;
            this.trkWordGap.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trkWordGap.Value = 10;
            this.trkWordGap.ValueChanged += new System.EventHandler(this.trkWordGap_ValueChanged);
            // 
            // trkAmplitude
            // 
            this.trkAmplitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trkAmplitude.Location = new System.Drawing.Point(16, 103);
            this.trkAmplitude.Maximum = 200;
            this.trkAmplitude.Name = "trkAmplitude";
            this.trkAmplitude.Size = new System.Drawing.Size(506, 45);
            this.trkAmplitude.TabIndex = 4;
            this.trkAmplitude.TickFrequency = 5;
            this.trkAmplitude.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trkAmplitude.Value = 100;
            this.trkAmplitude.ValueChanged += new System.EventHandler(this.trkAmplitude_ValueChanged);
            // 
            // txtAmplitude
            // 
            this.txtAmplitude.AutoSize = true;
            this.txtAmplitude.Location = new System.Drawing.Point(16, 87);
            this.txtAmplitude.Name = "txtAmplitude";
            this.txtAmplitude.Size = new System.Drawing.Size(152, 13);
            this.txtAmplitude.TabIndex = 5;
            this.txtAmplitude.Text = "Voice Amplitude: 100   [0, 200]";
            // 
            // mnuMenu
            // 
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(946, 24);
            this.mnuMenu.TabIndex = 17;
            this.mnuMenu.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmSave,
            this.itmExit});
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
            // itmExit
            // 
            this.itmExit.Name = "itmExit";
            this.itmExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.itmExit.Size = new System.Drawing.Size(138, 22);
            this.itmExit.Text = "Exit";
            this.itmExit.Click += new System.EventHandler(this.itmExit_Click);
            // 
            // ctxSpeechActions
            // 
            this.ctxSpeechActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmNewAction,
            this.itmDuplicateAction,
            this.toolStripSeparator1,
            this.itmDeleteAction});
            this.ctxSpeechActions.Name = "ctxSpeechActions";
            this.ctxSpeechActions.Size = new System.Drawing.Size(174, 76);
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
            this.itmDuplicateAction.Enabled = false;
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
            // SpeechSynthesizerTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 471);
            this.Controls.Add(this.grpSynthesizerProperties);
            this.Controls.Add(this.lstSpeechActions);
            this.Controls.Add(this.mnuMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.mnuMenu;
            this.MinimumSize = new System.Drawing.Size(962, 510);
            this.Name = "SpeechSynthesizerTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Speech Synthesizer";
            this.grpSynthesizerProperties.ResumeLayout(false);
            this.grpSynthesizerProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkWordGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkAmplitude)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.ctxSpeechActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstSpeechActions;
        private System.Windows.Forms.GroupBox grpSynthesizerProperties;
        private System.Windows.Forms.Button cmdSpeak;
        private System.Windows.Forms.CheckBox boxClear;
        private System.Windows.Forms.TrackBar trkPitch;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label txtPitch;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.TrackBar trkSpeed;
        private System.Windows.Forms.Label txtWordGap;
        private System.Windows.Forms.Label txtSpeed;
        private System.Windows.Forms.TrackBar trkWordGap;
        private System.Windows.Forms.TrackBar trkAmplitude;
        private System.Windows.Forms.Label txtAmplitude;
        private System.Windows.Forms.MenuStrip mnuMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem itmSave;
        private System.Windows.Forms.ToolStripMenuItem itmExit;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.ContextMenuStrip ctxSpeechActions;
        private System.Windows.Forms.ToolStripMenuItem itmNewAction;
        private System.Windows.Forms.ToolStripMenuItem itmDuplicateAction;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem itmDeleteAction;
    }
}
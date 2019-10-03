namespace RemoteCtrl {
    partial class CameraConfigWindow {
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
            this.trkQuality = new System.Windows.Forms.TrackBar();
            this.boxCapturing = new System.Windows.Forms.CheckBox();
            this.boxSwapped = new System.Windows.Forms.CheckBox();
            this.boxStreaming = new System.Windows.Forms.CheckBox();
            this.boxColoured = new System.Windows.Forms.CheckBox();
            this.txtQuality = new System.Windows.Forms.Label();
            this.cbxResolutions = new System.Windows.Forms.ComboBox();
            this.grpProperties = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsbPort = new System.Windows.Forms.Label();
            this.cbxUsbPorts = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.trkQuality)).BeginInit();
            this.grpProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // trkQuality
            // 
            this.trkQuality.Enabled = false;
            this.trkQuality.Location = new System.Drawing.Point(181, 90);
            this.trkQuality.Maximum = 100;
            this.trkQuality.Name = "trkQuality";
            this.trkQuality.Size = new System.Drawing.Size(158, 45);
            this.trkQuality.TabIndex = 20;
            this.trkQuality.TickFrequency = 5;
            this.trkQuality.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trkQuality.Value = 85;
            // 
            // boxCapturing
            // 
            this.boxCapturing.AutoSize = true;
            this.boxCapturing.Enabled = false;
            this.boxCapturing.Location = new System.Drawing.Point(9, 90);
            this.boxCapturing.Name = "boxCapturing";
            this.boxCapturing.Size = new System.Drawing.Size(71, 17);
            this.boxCapturing.TabIndex = 19;
            this.boxCapturing.Text = "Capturing";
            this.boxCapturing.UseVisualStyleBackColor = true;
            // 
            // boxSwapped
            // 
            this.boxSwapped.AutoSize = true;
            this.boxSwapped.Enabled = false;
            this.boxSwapped.Location = new System.Drawing.Point(83, 112);
            this.boxSwapped.Name = "boxSwapped";
            this.boxSwapped.Size = new System.Drawing.Size(71, 17);
            this.boxSwapped.TabIndex = 18;
            this.boxSwapped.Text = "Swapped";
            this.boxSwapped.UseVisualStyleBackColor = true;
            // 
            // boxStreaming
            // 
            this.boxStreaming.AutoSize = true;
            this.boxStreaming.Enabled = false;
            this.boxStreaming.Location = new System.Drawing.Point(83, 90);
            this.boxStreaming.Name = "boxStreaming";
            this.boxStreaming.Size = new System.Drawing.Size(73, 17);
            this.boxStreaming.TabIndex = 17;
            this.boxStreaming.Text = "Streaming";
            this.boxStreaming.UseVisualStyleBackColor = true;
            // 
            // boxColoured
            // 
            this.boxColoured.AutoSize = true;
            this.boxColoured.Enabled = false;
            this.boxColoured.Location = new System.Drawing.Point(9, 112);
            this.boxColoured.Name = "boxColoured";
            this.boxColoured.Size = new System.Drawing.Size(68, 17);
            this.boxColoured.TabIndex = 16;
            this.boxColoured.Text = "Coloured";
            this.boxColoured.UseVisualStyleBackColor = true;
            // 
            // txtQuality
            // 
            this.txtQuality.AutoSize = true;
            this.txtQuality.Enabled = false;
            this.txtQuality.Location = new System.Drawing.Point(186, 74);
            this.txtQuality.Name = "txtQuality";
            this.txtQuality.Size = new System.Drawing.Size(113, 13);
            this.txtQuality.TabIndex = 1;
            this.txtQuality.Text = "Encoding Quality: 85%";
            // 
            // cbxResolutions
            // 
            this.cbxResolutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxResolutions.Enabled = false;
            this.cbxResolutions.FormattingEnabled = true;
            this.cbxResolutions.Items.AddRange(new object[] {
            "640 x 480"});
            this.cbxResolutions.Location = new System.Drawing.Point(189, 42);
            this.cbxResolutions.Name = "cbxResolutions";
            this.cbxResolutions.Size = new System.Drawing.Size(150, 21);
            this.cbxResolutions.TabIndex = 0;
            // 
            // grpProperties
            // 
            this.grpProperties.Controls.Add(this.trkQuality);
            this.grpProperties.Controls.Add(this.label1);
            this.grpProperties.Controls.Add(this.boxCapturing);
            this.grpProperties.Controls.Add(this.lblUsbPort);
            this.grpProperties.Controls.Add(this.boxSwapped);
            this.grpProperties.Controls.Add(this.cbxUsbPorts);
            this.grpProperties.Controls.Add(this.boxStreaming);
            this.grpProperties.Controls.Add(this.cbxResolutions);
            this.grpProperties.Controls.Add(this.boxColoured);
            this.grpProperties.Controls.Add(this.txtQuality);
            this.grpProperties.Location = new System.Drawing.Point(12, 12);
            this.grpProperties.Name = "grpProperties";
            this.grpProperties.Size = new System.Drawing.Size(348, 145);
            this.grpProperties.TabIndex = 22;
            this.grpProperties.TabStop = false;
            this.grpProperties.Text = "Properties";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(186, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Resolution";
            // 
            // lblUsbPort
            // 
            this.lblUsbPort.AutoSize = true;
            this.lblUsbPort.Enabled = false;
            this.lblUsbPort.Location = new System.Drawing.Point(3, 26);
            this.lblUsbPort.Name = "lblUsbPort";
            this.lblUsbPort.Size = new System.Drawing.Size(51, 13);
            this.lblUsbPort.TabIndex = 22;
            this.lblUsbPort.Text = "USB Port";
            // 
            // cbxUsbPorts
            // 
            this.cbxUsbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUsbPorts.Enabled = false;
            this.cbxUsbPorts.FormattingEnabled = true;
            this.cbxUsbPorts.Items.AddRange(new object[] {
            "640 x 480"});
            this.cbxUsbPorts.Location = new System.Drawing.Point(6, 42);
            this.cbxUsbPorts.Name = "cbxUsbPorts";
            this.cbxUsbPorts.Size = new System.Drawing.Size(150, 21);
            this.cbxUsbPorts.TabIndex = 21;
            // 
            // CameraConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 166);
            this.Controls.Add(this.grpProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CameraConfigWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CameraConfigWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CameraConfigWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trkQuality)).EndInit();
            this.grpProperties.ResumeLayout(false);
            this.grpProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TrackBar trkQuality;
        private System.Windows.Forms.CheckBox boxCapturing;
        private System.Windows.Forms.CheckBox boxSwapped;
        private System.Windows.Forms.CheckBox boxStreaming;
        private System.Windows.Forms.CheckBox boxColoured;
        private System.Windows.Forms.Label txtQuality;
        private System.Windows.Forms.ComboBox cbxResolutions;
        private System.Windows.Forms.GroupBox grpProperties;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsbPort;
        private System.Windows.Forms.ComboBox cbxUsbPorts;
    }
}
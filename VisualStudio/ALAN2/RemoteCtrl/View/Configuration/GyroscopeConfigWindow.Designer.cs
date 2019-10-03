namespace RemoteCtrl {
    partial class GyroscopeConfigWindow {
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
            this.grpProperties = new System.Windows.Forms.GroupBox();
            this.cbxAccelerometerScale = new System.Windows.Forms.ComboBox();
            this.lblAccelerometerScale = new System.Windows.Forms.Label();
            this.cbxGyroscopeScale = new System.Windows.Forms.ComboBox();
            this.lblGyroscopeScale = new System.Windows.Forms.Label();
            this.txtReadInterval = new System.Windows.Forms.TextBox();
            this.lblReadInterval = new System.Windows.Forms.Label();
            this.cbxAddress = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.grpProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpProperties
            // 
            this.grpProperties.Controls.Add(this.cbxAccelerometerScale);
            this.grpProperties.Controls.Add(this.lblAccelerometerScale);
            this.grpProperties.Controls.Add(this.cbxGyroscopeScale);
            this.grpProperties.Controls.Add(this.lblGyroscopeScale);
            this.grpProperties.Controls.Add(this.txtReadInterval);
            this.grpProperties.Controls.Add(this.lblReadInterval);
            this.grpProperties.Controls.Add(this.cbxAddress);
            this.grpProperties.Controls.Add(this.txtName);
            this.grpProperties.Controls.Add(this.lblName);
            this.grpProperties.Controls.Add(this.lblAddress);
            this.grpProperties.Location = new System.Drawing.Point(12, 12);
            this.grpProperties.Name = "grpProperties";
            this.grpProperties.Size = new System.Drawing.Size(469, 105);
            this.grpProperties.TabIndex = 14;
            this.grpProperties.TabStop = false;
            this.grpProperties.Text = "Properties";
            // 
            // cbxAccelerometerScale
            // 
            this.cbxAccelerometerScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAccelerometerScale.Enabled = false;
            this.cbxAccelerometerScale.FormattingEnabled = true;
            this.cbxAccelerometerScale.Items.AddRange(new object[] {
            "2 G",
            "4 G",
            "8 G",
            "16 G"});
            this.cbxAccelerometerScale.Location = new System.Drawing.Point(367, 72);
            this.cbxAccelerometerScale.Name = "cbxAccelerometerScale";
            this.cbxAccelerometerScale.Size = new System.Drawing.Size(90, 21);
            this.cbxAccelerometerScale.TabIndex = 42;
            // 
            // lblAccelerometerScale
            // 
            this.lblAccelerometerScale.AutoSize = true;
            this.lblAccelerometerScale.Location = new System.Drawing.Point(252, 75);
            this.lblAccelerometerScale.Name = "lblAccelerometerScale";
            this.lblAccelerometerScale.Size = new System.Drawing.Size(105, 13);
            this.lblAccelerometerScale.TabIndex = 41;
            this.lblAccelerometerScale.Text = "Accelerometer Scale";
            // 
            // cbxGyroscopeScale
            // 
            this.cbxGyroscopeScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGyroscopeScale.Enabled = false;
            this.cbxGyroscopeScale.FormattingEnabled = true;
            this.cbxGyroscopeScale.Items.AddRange(new object[] {
            "250 DPS",
            "500 DPS",
            "1000 DPS",
            "2000 DPS"});
            this.cbxGyroscopeScale.Location = new System.Drawing.Point(129, 72);
            this.cbxGyroscopeScale.Name = "cbxGyroscopeScale";
            this.cbxGyroscopeScale.Size = new System.Drawing.Size(90, 21);
            this.cbxGyroscopeScale.TabIndex = 40;
            // 
            // lblGyroscopeScale
            // 
            this.lblGyroscopeScale.AutoSize = true;
            this.lblGyroscopeScale.Location = new System.Drawing.Point(6, 75);
            this.lblGyroscopeScale.Name = "lblGyroscopeScale";
            this.lblGyroscopeScale.Size = new System.Drawing.Size(88, 13);
            this.lblGyroscopeScale.TabIndex = 39;
            this.lblGyroscopeScale.Text = "Gyroscope Scale";
            // 
            // txtReadInterval
            // 
            this.txtReadInterval.Location = new System.Drawing.Point(367, 45);
            this.txtReadInterval.Name = "txtReadInterval";
            this.txtReadInterval.Size = new System.Drawing.Size(90, 20);
            this.txtReadInterval.TabIndex = 38;
            this.txtReadInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblReadInterval
            // 
            this.lblReadInterval.AutoSize = true;
            this.lblReadInterval.Location = new System.Drawing.Point(252, 48);
            this.lblReadInterval.Name = "lblReadInterval";
            this.lblReadInterval.Size = new System.Drawing.Size(93, 13);
            this.lblReadInterval.TabIndex = 37;
            this.lblReadInterval.Text = "Read Interval [ms]";
            // 
            // cbxAddress
            // 
            this.cbxAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAddress.Enabled = false;
            this.cbxAddress.FormattingEnabled = true;
            this.cbxAddress.Location = new System.Drawing.Point(129, 45);
            this.cbxAddress.Name = "cbxAddress";
            this.cbxAddress.Size = new System.Drawing.Size(90, 21);
            this.cbxAddress.TabIndex = 36;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(129, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(328, 20);
            this.txtName.TabIndex = 35;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 34;
            this.lblName.Text = "Name";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(6, 48);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(64, 13);
            this.lblAddress.TabIndex = 32;
            this.lblAddress.Text = "I2C Address";
            // 
            // GyroscopeConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 127);
            this.Controls.Add(this.grpProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GyroscopeConfigWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gyroscope Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GyroscopeConfigWindow_FormClosing);
            this.grpProperties.ResumeLayout(false);
            this.grpProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProperties;
        private System.Windows.Forms.TextBox txtReadInterval;
        private System.Windows.Forms.Label lblReadInterval;
        private System.Windows.Forms.ComboBox cbxAddress;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.ComboBox cbxAccelerometerScale;
        private System.Windows.Forms.Label lblAccelerometerScale;
        private System.Windows.Forms.ComboBox cbxGyroscopeScale;
        private System.Windows.Forms.Label lblGyroscopeScale;
    }
}
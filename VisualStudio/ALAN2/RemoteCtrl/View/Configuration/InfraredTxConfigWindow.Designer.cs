namespace RemoteCtrl {
    partial class InfraredTxConfigWindow {
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
            this.cbxProtocol = new System.Windows.Forms.ComboBox();
            this.lblProtocol = new System.Windows.Forms.Label();
            this.cbxPin = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPin = new System.Windows.Forms.Label();
            this.grpProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpProperties
            // 
            this.grpProperties.Controls.Add(this.cbxProtocol);
            this.grpProperties.Controls.Add(this.lblProtocol);
            this.grpProperties.Controls.Add(this.cbxPin);
            this.grpProperties.Controls.Add(this.txtName);
            this.grpProperties.Controls.Add(this.lblName);
            this.grpProperties.Controls.Add(this.lblPin);
            this.grpProperties.Location = new System.Drawing.Point(12, 12);
            this.grpProperties.Name = "grpProperties";
            this.grpProperties.Size = new System.Drawing.Size(414, 76);
            this.grpProperties.TabIndex = 15;
            this.grpProperties.TabStop = false;
            this.grpProperties.Text = "Properties";
            // 
            // cbxProtocol
            // 
            this.cbxProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProtocol.Enabled = false;
            this.cbxProtocol.FormattingEnabled = true;
            this.cbxProtocol.Items.AddRange(new object[] {
            "Amiga CDTV"});
            this.cbxProtocol.Location = new System.Drawing.Point(266, 45);
            this.cbxProtocol.Name = "cbxProtocol";
            this.cbxProtocol.Size = new System.Drawing.Size(137, 21);
            this.cbxProtocol.TabIndex = 38;
            // 
            // lblProtocol
            // 
            this.lblProtocol.AutoSize = true;
            this.lblProtocol.Location = new System.Drawing.Point(214, 48);
            this.lblProtocol.Name = "lblProtocol";
            this.lblProtocol.Size = new System.Drawing.Size(46, 13);
            this.lblProtocol.TabIndex = 37;
            this.lblProtocol.Text = "Protocol";
            // 
            // cbxPin
            // 
            this.cbxPin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPin.Enabled = false;
            this.cbxPin.FormattingEnabled = true;
            this.cbxPin.Location = new System.Drawing.Point(84, 45);
            this.cbxPin.Name = "cbxPin";
            this.cbxPin.Size = new System.Drawing.Size(88, 21);
            this.cbxPin.TabIndex = 36;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(84, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(319, 20);
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
            // lblPin
            // 
            this.lblPin.AutoSize = true;
            this.lblPin.Location = new System.Drawing.Point(6, 48);
            this.lblPin.Name = "lblPin";
            this.lblPin.Size = new System.Drawing.Size(54, 13);
            this.lblPin.TabIndex = 32;
            this.lblPin.Text = "Digital Pin";
            // 
            // InfraredTxConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 98);
            this.Controls.Add(this.grpProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InfraredTxConfigWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Infrared Transceiver Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InfraredTxConfigWindow_FormClosing);
            this.grpProperties.ResumeLayout(false);
            this.grpProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProperties;
        private System.Windows.Forms.ComboBox cbxProtocol;
        private System.Windows.Forms.Label lblProtocol;
        private System.Windows.Forms.ComboBox cbxPin;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPin;
    }
}
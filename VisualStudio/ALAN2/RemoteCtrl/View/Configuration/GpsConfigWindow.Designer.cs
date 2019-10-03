namespace RemoteCtrl {
    partial class GpsConfigWindow {
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
            this.boxAutoPosition = new System.Windows.Forms.CheckBox();
            this.boxSatelliteView = new System.Windows.Forms.CheckBox();
            this.boxAutoZoom = new System.Windows.Forms.CheckBox();
            this.grpProperties = new System.Windows.Forms.GroupBox();
            this.txtReadInterval = new System.Windows.Forms.TextBox();
            this.lblReadInterval = new System.Windows.Forms.Label();
            this.cbxPin = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPin = new System.Windows.Forms.Label();
            this.grpProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxAutoPosition
            // 
            this.boxAutoPosition.AutoSize = true;
            this.boxAutoPosition.Checked = true;
            this.boxAutoPosition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxAutoPosition.Enabled = false;
            this.boxAutoPosition.Location = new System.Drawing.Point(357, 80);
            this.boxAutoPosition.Name = "boxAutoPosition";
            this.boxAutoPosition.Size = new System.Drawing.Size(102, 17);
            this.boxAutoPosition.TabIndex = 58;
            this.boxAutoPosition.Text = "Auto Positioning";
            this.boxAutoPosition.UseVisualStyleBackColor = true;
            // 
            // boxSatelliteView
            // 
            this.boxSatelliteView.AutoSize = true;
            this.boxSatelliteView.Checked = true;
            this.boxSatelliteView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxSatelliteView.Enabled = false;
            this.boxSatelliteView.Location = new System.Drawing.Point(129, 80);
            this.boxSatelliteView.Name = "boxSatelliteView";
            this.boxSatelliteView.Size = new System.Drawing.Size(89, 17);
            this.boxSatelliteView.TabIndex = 57;
            this.boxSatelliteView.Text = "Satellite View";
            this.boxSatelliteView.UseVisualStyleBackColor = true;
            // 
            // boxAutoZoom
            // 
            this.boxAutoZoom.AutoSize = true;
            this.boxAutoZoom.Checked = true;
            this.boxAutoZoom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxAutoZoom.Enabled = false;
            this.boxAutoZoom.Location = new System.Drawing.Point(237, 80);
            this.boxAutoZoom.Name = "boxAutoZoom";
            this.boxAutoZoom.Size = new System.Drawing.Size(92, 17);
            this.boxAutoZoom.TabIndex = 56;
            this.boxAutoZoom.Text = "Auto Zooming";
            this.boxAutoZoom.UseVisualStyleBackColor = true;
            // 
            // grpProperties
            // 
            this.grpProperties.Controls.Add(this.txtReadInterval);
            this.grpProperties.Controls.Add(this.boxAutoPosition);
            this.grpProperties.Controls.Add(this.boxSatelliteView);
            this.grpProperties.Controls.Add(this.lblReadInterval);
            this.grpProperties.Controls.Add(this.boxAutoZoom);
            this.grpProperties.Controls.Add(this.cbxPin);
            this.grpProperties.Controls.Add(this.txtName);
            this.grpProperties.Controls.Add(this.lblName);
            this.grpProperties.Controls.Add(this.lblPin);
            this.grpProperties.Location = new System.Drawing.Point(12, 12);
            this.grpProperties.Name = "grpProperties";
            this.grpProperties.Size = new System.Drawing.Size(470, 111);
            this.grpProperties.TabIndex = 59;
            this.grpProperties.TabStop = false;
            this.grpProperties.Text = "Properties";
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
            this.lblReadInterval.Location = new System.Drawing.Point(258, 48);
            this.lblReadInterval.Name = "lblReadInterval";
            this.lblReadInterval.Size = new System.Drawing.Size(93, 13);
            this.lblReadInterval.TabIndex = 37;
            this.lblReadInterval.Text = "Read Interval [ms]";
            // 
            // cbxPin
            // 
            this.cbxPin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPin.Enabled = false;
            this.cbxPin.FormattingEnabled = true;
            this.cbxPin.Items.AddRange(new object[] {
            "Serial#0",
            "Serial#1",
            "Serial#2",
            "Serial#3"});
            this.cbxPin.Location = new System.Drawing.Point(129, 45);
            this.cbxPin.Name = "cbxPin";
            this.cbxPin.Size = new System.Drawing.Size(106, 21);
            this.cbxPin.TabIndex = 36;
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
            // lblPin
            // 
            this.lblPin.AutoSize = true;
            this.lblPin.Location = new System.Drawing.Point(6, 48);
            this.lblPin.Name = "lblPin";
            this.lblPin.Size = new System.Drawing.Size(55, 13);
            this.lblPin.TabIndex = 32;
            this.lblPin.Text = "Serial Port";
            // 
            // GpsConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 135);
            this.Controls.Add(this.grpProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GpsConfigWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GPS Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GpsConfigWindow_FormClosing);
            this.grpProperties.ResumeLayout(false);
            this.grpProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox boxAutoPosition;
        private System.Windows.Forms.CheckBox boxSatelliteView;
        private System.Windows.Forms.CheckBox boxAutoZoom;
        private System.Windows.Forms.GroupBox grpProperties;
        private System.Windows.Forms.TextBox txtReadInterval;
        private System.Windows.Forms.Label lblReadInterval;
        private System.Windows.Forms.ComboBox cbxPin;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPin;
    }
}
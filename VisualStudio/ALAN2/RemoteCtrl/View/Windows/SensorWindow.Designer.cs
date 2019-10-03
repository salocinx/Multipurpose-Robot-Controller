namespace RemoteCtrl {
    partial class SensorWindow {
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
            this.viewSensorLogbook = new RemoteCtrl.SensorLogbookView();
            this.lblZoom = new System.Windows.Forms.Label();
            this.trkZoom = new System.Windows.Forms.TrackBar();
            this.pnlSensorLogbook = new System.Windows.Forms.Panel();
            this.txtReadInterval = new System.Windows.Forms.TextBox();
            this.lblReadInterval = new System.Windows.Forms.Label();
            this.txtTimestamp = new System.Windows.Forms.TextBox();
            this.lblTimestamp = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.txtPostfix = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trkZoom)).BeginInit();
            this.pnlSensorLogbook.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewSensorLogbook
            // 
            this.viewSensorLogbook.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.viewSensorLogbook.BackColor = System.Drawing.Color.White;
            this.viewSensorLogbook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewSensorLogbook.Location = new System.Drawing.Point(-1, -1);
            this.viewSensorLogbook.Name = "viewSensorLogbook";
            this.viewSensorLogbook.Size = new System.Drawing.Size(4096, 274);
            this.viewSensorLogbook.TabIndex = 0;
            // 
            // lblZoom
            // 
            this.lblZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZoom.AutoSize = true;
            this.lblZoom.Location = new System.Drawing.Point(702, 304);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(72, 13);
            this.lblZoom.TabIndex = 33;
            this.lblZoom.Text = "Zoom [100%]:";
            // 
            // trkZoom
            // 
            this.trkZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trkZoom.Location = new System.Drawing.Point(781, 296);
            this.trkZoom.Maximum = 200;
            this.trkZoom.Minimum = 25;
            this.trkZoom.Name = "trkZoom";
            this.trkZoom.Size = new System.Drawing.Size(160, 45);
            this.trkZoom.TabIndex = 32;
            this.trkZoom.TickFrequency = 5;
            this.trkZoom.Value = 100;
            this.trkZoom.ValueChanged += new System.EventHandler(this.trkZoom_ValueChanged);
            // 
            // pnlSensorLogbook
            // 
            this.pnlSensorLogbook.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSensorLogbook.AutoScroll = true;
            this.pnlSensorLogbook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSensorLogbook.Controls.Add(this.viewSensorLogbook);
            this.pnlSensorLogbook.Location = new System.Drawing.Point(12, 12);
            this.pnlSensorLogbook.Name = "pnlSensorLogbook";
            this.pnlSensorLogbook.Size = new System.Drawing.Size(929, 274);
            this.pnlSensorLogbook.TabIndex = 34;
            this.pnlSensorLogbook.Scroll += new System.Windows.Forms.ScrollEventHandler(this.pnlSensorLogbook_Scroll);
            // 
            // txtReadInterval
            // 
            this.txtReadInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtReadInterval.Enabled = false;
            this.txtReadInterval.Location = new System.Drawing.Point(116, 301);
            this.txtReadInterval.Name = "txtReadInterval";
            this.txtReadInterval.Size = new System.Drawing.Size(90, 20);
            this.txtReadInterval.TabIndex = 42;
            this.txtReadInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblReadInterval
            // 
            this.lblReadInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReadInterval.AutoSize = true;
            this.lblReadInterval.Location = new System.Drawing.Point(9, 304);
            this.lblReadInterval.Name = "lblReadInterval";
            this.lblReadInterval.Size = new System.Drawing.Size(93, 13);
            this.lblReadInterval.TabIndex = 41;
            this.lblReadInterval.Text = "Read Interval [ms]";
            // 
            // txtTimestamp
            // 
            this.txtTimestamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTimestamp.Enabled = false;
            this.txtTimestamp.Location = new System.Drawing.Point(298, 301);
            this.txtTimestamp.Name = "txtTimestamp";
            this.txtTimestamp.Size = new System.Drawing.Size(180, 20);
            this.txtTimestamp.TabIndex = 44;
            this.txtTimestamp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTimestamp
            // 
            this.lblTimestamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTimestamp.AutoSize = true;
            this.lblTimestamp.Location = new System.Drawing.Point(234, 304);
            this.lblTimestamp.Name = "lblTimestamp";
            this.lblTimestamp.Size = new System.Drawing.Size(58, 13);
            this.lblTimestamp.TabIndex = 43;
            this.lblTimestamp.Text = "Timestamp";
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtValue.Enabled = false;
            this.txtValue.Location = new System.Drawing.Point(537, 301);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(93, 20);
            this.txtValue.TabIndex = 46;
            this.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblValue
            // 
            this.lblValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(497, 304);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(34, 13);
            this.lblValue.TabIndex = 45;
            this.lblValue.Text = "Value";
            // 
            // txtPostfix
            // 
            this.txtPostfix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPostfix.AutoSize = true;
            this.txtPostfix.Location = new System.Drawing.Point(636, 304);
            this.txtPostfix.Name = "txtPostfix";
            this.txtPostfix.Size = new System.Drawing.Size(20, 13);
            this.txtPostfix.TabIndex = 47;
            this.txtPostfix.Text = "[V]";
            // 
            // SensorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 335);
            this.Controls.Add(this.txtPostfix);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.txtTimestamp);
            this.Controls.Add(this.lblTimestamp);
            this.Controls.Add(this.txtReadInterval);
            this.Controls.Add(this.lblReadInterval);
            this.Controls.Add(this.pnlSensorLogbook);
            this.Controls.Add(this.lblZoom);
            this.Controls.Add(this.trkZoom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(970, 374);
            this.Name = "SensorWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Logbook [Sensor-Name]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SensorWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trkZoom)).EndInit();
            this.pnlSensorLogbook.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SensorLogbookView viewSensorLogbook;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.TrackBar trkZoom;
        private System.Windows.Forms.Panel pnlSensorLogbook;
        private System.Windows.Forms.TextBox txtReadInterval;
        private System.Windows.Forms.Label lblReadInterval;
        private System.Windows.Forms.TextBox txtTimestamp;
        private System.Windows.Forms.Label lblTimestamp;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label txtPostfix;
    }
}
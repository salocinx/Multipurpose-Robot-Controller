namespace RemoteCtrl {
    partial class SensorPanel {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.grpSensors = new System.Windows.Forms.GroupBox();
            this.lstSensors = new System.Windows.Forms.Panel();
            this.grpSensors.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSensors
            // 
            this.grpSensors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSensors.Controls.Add(this.lstSensors);
            this.grpSensors.Location = new System.Drawing.Point(3, 3);
            this.grpSensors.Name = "grpSensors";
            this.grpSensors.Size = new System.Drawing.Size(840, 498);
            this.grpSensors.TabIndex = 0;
            this.grpSensors.TabStop = false;
            this.grpSensors.Text = "Sensors";
            // 
            // lstSensors
            // 
            this.lstSensors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSensors.AutoScroll = true;
            this.lstSensors.BackColor = System.Drawing.Color.White;
            this.lstSensors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSensors.Location = new System.Drawing.Point(6, 19);
            this.lstSensors.Name = "lstSensors";
            this.lstSensors.Size = new System.Drawing.Size(828, 473);
            this.lstSensors.TabIndex = 0;
            this.lstSensors.SizeChanged += new System.EventHandler(this.lstSensors_SizeChanged);
            // 
            // SensorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpSensors);
            this.MinimumSize = new System.Drawing.Size(846, 504);
            this.Name = "SensorPanel";
            this.Size = new System.Drawing.Size(846, 504);
            this.grpSensors.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSensors;
        private System.Windows.Forms.Panel lstSensors;
    }
}

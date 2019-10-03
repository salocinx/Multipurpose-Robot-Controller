namespace RemoteCtrl {
    partial class SensorControl {
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
            this.pgsData = new System.Windows.Forms.ProgressBar();
            this.grpSensor = new System.Windows.Forms.GroupBox();
            this.txtMaximum = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.Label();
            this.txtMinimum = new System.Windows.Forms.Label();
            this.txtPin1 = new System.Windows.Forms.Label();
            this.txtPin2 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.Label();
            this.grpSensor.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgsData
            // 
            this.pgsData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgsData.Location = new System.Drawing.Point(6, 23);
            this.pgsData.Maximum = 250;
            this.pgsData.Name = "pgsData";
            this.pgsData.Size = new System.Drawing.Size(382, 23);
            this.pgsData.TabIndex = 0;
            this.pgsData.Value = 50;
            // 
            // grpSensor
            // 
            this.grpSensor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSensor.Controls.Add(this.txtInterval);
            this.grpSensor.Controls.Add(this.txtMaximum);
            this.grpSensor.Controls.Add(this.txtData);
            this.grpSensor.Controls.Add(this.txtMinimum);
            this.grpSensor.Controls.Add(this.pgsData);
            this.grpSensor.Controls.Add(this.txtPin1);
            this.grpSensor.Controls.Add(this.txtPin2);
            this.grpSensor.Location = new System.Drawing.Point(3, 3);
            this.grpSensor.Name = "grpSensor";
            this.grpSensor.Size = new System.Drawing.Size(394, 90);
            this.grpSensor.TabIndex = 1;
            this.grpSensor.TabStop = false;
            this.grpSensor.Text = "<Sensor Name>";
            // 
            // txtMaximum
            // 
            this.txtMaximum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaximum.AutoSize = true;
            this.txtMaximum.Location = new System.Drawing.Point(290, 70);
            this.txtMaximum.Name = "txtMaximum";
            this.txtMaximum.Size = new System.Drawing.Size(94, 13);
            this.txtMaximum.TabIndex = 17;
            this.txtMaximum.Text = "Maximum: xy [???]";
            // 
            // txtData
            // 
            this.txtData.AutoSize = true;
            this.txtData.Location = new System.Drawing.Point(6, 54);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(78, 13);
            this.txtData.TabIndex = 18;
            this.txtData.Text = "Data: xyz [???]";
            // 
            // txtMinimum
            // 
            this.txtMinimum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMinimum.AutoSize = true;
            this.txtMinimum.Location = new System.Drawing.Point(182, 70);
            this.txtMinimum.Name = "txtMinimum";
            this.txtMinimum.Size = new System.Drawing.Size(91, 13);
            this.txtMinimum.TabIndex = 16;
            this.txtMinimum.Text = "Minimum: xy [???]";
            // 
            // txtPin1
            // 
            this.txtPin1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPin1.AutoSize = true;
            this.txtPin1.Location = new System.Drawing.Point(182, 54);
            this.txtPin1.Name = "txtPin1";
            this.txtPin1.Size = new System.Drawing.Size(44, 13);
            this.txtPin1.TabIndex = 15;
            this.txtPin1.Text = "Pin1: xy";
            // 
            // txtPin2
            // 
            this.txtPin2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPin2.AutoSize = true;
            this.txtPin2.Location = new System.Drawing.Point(290, 54);
            this.txtPin2.Name = "txtPin2";
            this.txtPin2.Size = new System.Drawing.Size(44, 13);
            this.txtPin2.TabIndex = 14;
            this.txtPin2.Text = "Pin2: xy";
            // 
            // txtInterval
            // 
            this.txtInterval.AutoSize = true;
            this.txtInterval.Location = new System.Drawing.Point(6, 70);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(114, 13);
            this.txtInterval.TabIndex = 19;
            this.txtInterval.Text = "Read Interval: xyz [ms]";
            // 
            // SensorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpSensor);
            this.Name = "SensorControl";
            this.Size = new System.Drawing.Size(400, 94);
            this.grpSensor.ResumeLayout(false);
            this.grpSensor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgsData;
        private System.Windows.Forms.GroupBox grpSensor;
        private System.Windows.Forms.Label txtMaximum;
        private System.Windows.Forms.Label txtData;
        private System.Windows.Forms.Label txtMinimum;
        private System.Windows.Forms.Label txtPin1;
        private System.Windows.Forms.Label txtPin2;
        private System.Windows.Forms.Label txtInterval;
    }
}

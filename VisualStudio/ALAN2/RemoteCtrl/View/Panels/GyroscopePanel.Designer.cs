namespace RemoteCtrl {
    partial class GyroscopePanel {
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
            this.layGyroscope = new System.Windows.Forms.TableLayoutPanel();
            this.grpGyroscope = new System.Windows.Forms.GroupBox();
            this.grpAccelerometer = new System.Windows.Forms.GroupBox();
            this.pgsAxMinus = new System.Windows.Forms.ProgressBar();
            this.pgsAxPlus = new System.Windows.Forms.ProgressBar();
            this.lblGX = new System.Windows.Forms.Label();
            this.lblGY = new System.Windows.Forms.Label();
            this.pgsAyPlus = new System.Windows.Forms.ProgressBar();
            this.pgsAyMinus = new System.Windows.Forms.ProgressBar();
            this.lblGZ = new System.Windows.Forms.Label();
            this.pgsAzPlus = new System.Windows.Forms.ProgressBar();
            this.pgsAzMinus = new System.Windows.Forms.ProgressBar();
            this.lblAZ = new System.Windows.Forms.Label();
            this.pgsGzPlus = new System.Windows.Forms.ProgressBar();
            this.pgsGzMinus = new System.Windows.Forms.ProgressBar();
            this.lblAY = new System.Windows.Forms.Label();
            this.pgsGyPlus = new System.Windows.Forms.ProgressBar();
            this.pgsGyMinus = new System.Windows.Forms.ProgressBar();
            this.lblAX = new System.Windows.Forms.Label();
            this.pgsGxPlus = new System.Windows.Forms.ProgressBar();
            this.pgsGxMinus = new System.Windows.Forms.ProgressBar();
            this.layGyroscope.SuspendLayout();
            this.grpGyroscope.SuspendLayout();
            this.grpAccelerometer.SuspendLayout();
            this.SuspendLayout();
            // 
            // layGyroscope
            // 
            this.layGyroscope.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layGyroscope.ColumnCount = 1;
            this.layGyroscope.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layGyroscope.Controls.Add(this.grpGyroscope, 0, 0);
            this.layGyroscope.Controls.Add(this.grpAccelerometer, 0, 1);
            this.layGyroscope.Location = new System.Drawing.Point(3, 3);
            this.layGyroscope.Name = "layGyroscope";
            this.layGyroscope.RowCount = 2;
            this.layGyroscope.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layGyroscope.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layGyroscope.Size = new System.Drawing.Size(840, 498);
            this.layGyroscope.TabIndex = 0;
            // 
            // grpGyroscope
            // 
            this.grpGyroscope.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGyroscope.Controls.Add(this.lblGZ);
            this.grpGyroscope.Controls.Add(this.pgsAzPlus);
            this.grpGyroscope.Controls.Add(this.pgsAzMinus);
            this.grpGyroscope.Controls.Add(this.lblGY);
            this.grpGyroscope.Controls.Add(this.pgsAyPlus);
            this.grpGyroscope.Controls.Add(this.pgsAyMinus);
            this.grpGyroscope.Controls.Add(this.lblGX);
            this.grpGyroscope.Controls.Add(this.pgsAxPlus);
            this.grpGyroscope.Controls.Add(this.pgsAxMinus);
            this.grpGyroscope.Location = new System.Drawing.Point(3, 3);
            this.grpGyroscope.Name = "grpGyroscope";
            this.grpGyroscope.Size = new System.Drawing.Size(834, 243);
            this.grpGyroscope.TabIndex = 0;
            this.grpGyroscope.TabStop = false;
            this.grpGyroscope.Text = "Gyroscope";
            // 
            // grpAccelerometer
            // 
            this.grpAccelerometer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAccelerometer.Controls.Add(this.lblAZ);
            this.grpAccelerometer.Controls.Add(this.pgsGzMinus);
            this.grpAccelerometer.Controls.Add(this.pgsGzPlus);
            this.grpAccelerometer.Controls.Add(this.pgsGxMinus);
            this.grpAccelerometer.Controls.Add(this.pgsGxPlus);
            this.grpAccelerometer.Controls.Add(this.lblAY);
            this.grpAccelerometer.Controls.Add(this.lblAX);
            this.grpAccelerometer.Controls.Add(this.pgsGyPlus);
            this.grpAccelerometer.Controls.Add(this.pgsGyMinus);
            this.grpAccelerometer.Location = new System.Drawing.Point(3, 252);
            this.grpAccelerometer.Name = "grpAccelerometer";
            this.grpAccelerometer.Size = new System.Drawing.Size(834, 243);
            this.grpAccelerometer.TabIndex = 1;
            this.grpAccelerometer.TabStop = false;
            this.grpAccelerometer.Text = "Accelerometer";
            // 
            // pgsAxMinus
            // 
            this.pgsAxMinus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pgsAxMinus.Location = new System.Drawing.Point(24, 63);
            this.pgsAxMinus.Maximum = 2500;
            this.pgsAxMinus.Name = "pgsAxMinus";
            this.pgsAxMinus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pgsAxMinus.RightToLeftLayout = true;
            this.pgsAxMinus.Size = new System.Drawing.Size(390, 23);
            this.pgsAxMinus.TabIndex = 0;
            // 
            // pgsAxPlus
            // 
            this.pgsAxPlus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pgsAxPlus.Location = new System.Drawing.Point(414, 63);
            this.pgsAxPlus.Maximum = 2500;
            this.pgsAxPlus.Name = "pgsAxPlus";
            this.pgsAxPlus.Size = new System.Drawing.Size(390, 23);
            this.pgsAxPlus.TabIndex = 1;
            // 
            // lblGX
            // 
            this.lblGX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGX.AutoSize = true;
            this.lblGX.Location = new System.Drawing.Point(21, 47);
            this.lblGX.Name = "lblGX";
            this.lblGX.Size = new System.Drawing.Size(36, 13);
            this.lblGX.TabIndex = 2;
            this.lblGX.Text = "X-Axis";
            // 
            // lblGY
            // 
            this.lblGY.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGY.AutoSize = true;
            this.lblGY.Location = new System.Drawing.Point(21, 97);
            this.lblGY.Name = "lblGY";
            this.lblGY.Size = new System.Drawing.Size(36, 13);
            this.lblGY.TabIndex = 5;
            this.lblGY.Text = "Y-Axis";
            // 
            // pgsAyPlus
            // 
            this.pgsAyPlus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pgsAyPlus.Location = new System.Drawing.Point(414, 113);
            this.pgsAyPlus.Maximum = 2500;
            this.pgsAyPlus.Name = "pgsAyPlus";
            this.pgsAyPlus.Size = new System.Drawing.Size(390, 23);
            this.pgsAyPlus.TabIndex = 4;
            // 
            // pgsAyMinus
            // 
            this.pgsAyMinus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pgsAyMinus.Location = new System.Drawing.Point(24, 113);
            this.pgsAyMinus.Maximum = 2500;
            this.pgsAyMinus.Name = "pgsAyMinus";
            this.pgsAyMinus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pgsAyMinus.RightToLeftLayout = true;
            this.pgsAyMinus.Size = new System.Drawing.Size(390, 23);
            this.pgsAyMinus.TabIndex = 3;
            // 
            // lblGZ
            // 
            this.lblGZ.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGZ.AutoSize = true;
            this.lblGZ.Location = new System.Drawing.Point(21, 147);
            this.lblGZ.Name = "lblGZ";
            this.lblGZ.Size = new System.Drawing.Size(36, 13);
            this.lblGZ.TabIndex = 8;
            this.lblGZ.Text = "Z-Axis";
            // 
            // pgsAzPlus
            // 
            this.pgsAzPlus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pgsAzPlus.Location = new System.Drawing.Point(414, 163);
            this.pgsAzPlus.Maximum = 2500;
            this.pgsAzPlus.Name = "pgsAzPlus";
            this.pgsAzPlus.Size = new System.Drawing.Size(390, 23);
            this.pgsAzPlus.TabIndex = 7;
            // 
            // pgsAzMinus
            // 
            this.pgsAzMinus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pgsAzMinus.Location = new System.Drawing.Point(24, 163);
            this.pgsAzMinus.Maximum = 2500;
            this.pgsAzMinus.Name = "pgsAzMinus";
            this.pgsAzMinus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pgsAzMinus.RightToLeftLayout = true;
            this.pgsAzMinus.Size = new System.Drawing.Size(390, 23);
            this.pgsAzMinus.TabIndex = 6;
            // 
            // lblAZ
            // 
            this.lblAZ.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAZ.AutoSize = true;
            this.lblAZ.Location = new System.Drawing.Point(21, 155);
            this.lblAZ.Name = "lblAZ";
            this.lblAZ.Size = new System.Drawing.Size(36, 13);
            this.lblAZ.TabIndex = 17;
            this.lblAZ.Text = "Z-Axis";
            // 
            // pgsGzPlus
            // 
            this.pgsGzPlus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pgsGzPlus.Location = new System.Drawing.Point(414, 171);
            this.pgsGzPlus.Maximum = 2500;
            this.pgsGzPlus.Name = "pgsGzPlus";
            this.pgsGzPlus.Size = new System.Drawing.Size(390, 23);
            this.pgsGzPlus.TabIndex = 16;
            // 
            // pgsGzMinus
            // 
            this.pgsGzMinus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pgsGzMinus.Location = new System.Drawing.Point(24, 171);
            this.pgsGzMinus.Maximum = 2500;
            this.pgsGzMinus.Name = "pgsGzMinus";
            this.pgsGzMinus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pgsGzMinus.RightToLeftLayout = true;
            this.pgsGzMinus.Size = new System.Drawing.Size(390, 23);
            this.pgsGzMinus.TabIndex = 15;
            // 
            // lblAY
            // 
            this.lblAY.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAY.AutoSize = true;
            this.lblAY.Location = new System.Drawing.Point(21, 105);
            this.lblAY.Name = "lblAY";
            this.lblAY.Size = new System.Drawing.Size(36, 13);
            this.lblAY.TabIndex = 14;
            this.lblAY.Text = "Y-Axis";
            // 
            // pgsGyPlus
            // 
            this.pgsGyPlus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pgsGyPlus.Location = new System.Drawing.Point(414, 121);
            this.pgsGyPlus.Maximum = 2500;
            this.pgsGyPlus.Name = "pgsGyPlus";
            this.pgsGyPlus.Size = new System.Drawing.Size(390, 23);
            this.pgsGyPlus.TabIndex = 13;
            // 
            // pgsGyMinus
            // 
            this.pgsGyMinus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pgsGyMinus.Location = new System.Drawing.Point(24, 121);
            this.pgsGyMinus.Maximum = 2500;
            this.pgsGyMinus.Name = "pgsGyMinus";
            this.pgsGyMinus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pgsGyMinus.RightToLeftLayout = true;
            this.pgsGyMinus.Size = new System.Drawing.Size(390, 23);
            this.pgsGyMinus.TabIndex = 12;
            // 
            // lblAX
            // 
            this.lblAX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAX.AutoSize = true;
            this.lblAX.Location = new System.Drawing.Point(21, 55);
            this.lblAX.Name = "lblAX";
            this.lblAX.Size = new System.Drawing.Size(36, 13);
            this.lblAX.TabIndex = 11;
            this.lblAX.Text = "X-Axis";
            // 
            // pgsGxPlus
            // 
            this.pgsGxPlus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pgsGxPlus.Location = new System.Drawing.Point(414, 71);
            this.pgsGxPlus.Maximum = 2500;
            this.pgsGxPlus.Name = "pgsGxPlus";
            this.pgsGxPlus.Size = new System.Drawing.Size(390, 23);
            this.pgsGxPlus.TabIndex = 10;
            // 
            // pgsGxMinus
            // 
            this.pgsGxMinus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pgsGxMinus.Location = new System.Drawing.Point(24, 71);
            this.pgsGxMinus.Maximum = 2500;
            this.pgsGxMinus.Name = "pgsGxMinus";
            this.pgsGxMinus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pgsGxMinus.RightToLeftLayout = true;
            this.pgsGxMinus.Size = new System.Drawing.Size(390, 23);
            this.pgsGxMinus.TabIndex = 9;
            // 
            // GyroscopePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layGyroscope);
            this.MinimumSize = new System.Drawing.Size(846, 504);
            this.Name = "GyroscopePanel";
            this.Size = new System.Drawing.Size(846, 504);
            this.layGyroscope.ResumeLayout(false);
            this.grpGyroscope.ResumeLayout(false);
            this.grpGyroscope.PerformLayout();
            this.grpAccelerometer.ResumeLayout(false);
            this.grpAccelerometer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layGyroscope;
        private System.Windows.Forms.GroupBox grpGyroscope;
        private System.Windows.Forms.Label lblGZ;
        private System.Windows.Forms.ProgressBar pgsAzPlus;
        private System.Windows.Forms.ProgressBar pgsAzMinus;
        private System.Windows.Forms.Label lblGY;
        private System.Windows.Forms.ProgressBar pgsAyPlus;
        private System.Windows.Forms.ProgressBar pgsAyMinus;
        private System.Windows.Forms.Label lblGX;
        private System.Windows.Forms.ProgressBar pgsAxPlus;
        private System.Windows.Forms.ProgressBar pgsAxMinus;
        private System.Windows.Forms.GroupBox grpAccelerometer;
        private System.Windows.Forms.Label lblAZ;
        private System.Windows.Forms.ProgressBar pgsGzMinus;
        private System.Windows.Forms.ProgressBar pgsGzPlus;
        private System.Windows.Forms.ProgressBar pgsGxMinus;
        private System.Windows.Forms.ProgressBar pgsGxPlus;
        private System.Windows.Forms.Label lblAY;
        private System.Windows.Forms.Label lblAX;
        private System.Windows.Forms.ProgressBar pgsGyPlus;
        private System.Windows.Forms.ProgressBar pgsGyMinus;
    }
}

namespace RemoteCtrl {
    partial class HumidityConfigWindow {
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
            this.txtMaximum = new System.Windows.Forms.TextBox();
            this.lblMaximum = new System.Windows.Forms.Label();
            this.txtMinimum = new System.Windows.Forms.TextBox();
            this.lblMinimum = new System.Windows.Forms.Label();
            this.txtReadInterval = new System.Windows.Forms.TextBox();
            this.lblReadInterval = new System.Windows.Forms.Label();
            this.cbxPin = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPin = new System.Windows.Forms.Label();
            this.txtPostfix = new System.Windows.Forms.TextBox();
            this.lblPostfix = new System.Windows.Forms.Label();
            this.grpTranslation = new System.Windows.Forms.GroupBox();
            this.imgLinearFunction = new System.Windows.Forms.PictureBox();
            this.lblInfo5 = new System.Windows.Forms.Label();
            this.txtIntercept = new System.Windows.Forms.TextBox();
            this.lblIntercept = new System.Windows.Forms.Label();
            this.txtSlope = new System.Windows.Forms.TextBox();
            this.lblSlope = new System.Windows.Forms.Label();
            this.lblInfo4 = new System.Windows.Forms.Label();
            this.grpLogging = new System.Windows.Forms.GroupBox();
            this.txtLogInterval = new System.Windows.Forms.TextBox();
            this.lblLogInterval = new System.Windows.Forms.Label();
            this.txtLogCapacity = new System.Windows.Forms.TextBox();
            this.lblLogCapacity = new System.Windows.Forms.Label();
            this.boxLogging = new System.Windows.Forms.CheckBox();
            this.grpProperties.SuspendLayout();
            this.grpTranslation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLinearFunction)).BeginInit();
            this.grpLogging.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpProperties
            // 
            this.grpProperties.Controls.Add(this.txtMaximum);
            this.grpProperties.Controls.Add(this.lblMaximum);
            this.grpProperties.Controls.Add(this.txtMinimum);
            this.grpProperties.Controls.Add(this.lblMinimum);
            this.grpProperties.Controls.Add(this.txtReadInterval);
            this.grpProperties.Controls.Add(this.lblReadInterval);
            this.grpProperties.Controls.Add(this.cbxPin);
            this.grpProperties.Controls.Add(this.txtName);
            this.grpProperties.Controls.Add(this.lblName);
            this.grpProperties.Controls.Add(this.lblPin);
            this.grpProperties.Controls.Add(this.txtPostfix);
            this.grpProperties.Controls.Add(this.lblPostfix);
            this.grpProperties.Location = new System.Drawing.Point(12, 12);
            this.grpProperties.Name = "grpProperties";
            this.grpProperties.Size = new System.Drawing.Size(472, 134);
            this.grpProperties.TabIndex = 10;
            this.grpProperties.TabStop = false;
            this.grpProperties.Text = "Properties";
            // 
            // txtMaximum
            // 
            this.txtMaximum.Location = new System.Drawing.Point(367, 72);
            this.txtMaximum.Name = "txtMaximum";
            this.txtMaximum.Size = new System.Drawing.Size(90, 20);
            this.txtMaximum.TabIndex = 40;
            this.txtMaximum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMaximum
            // 
            this.lblMaximum.AutoSize = true;
            this.lblMaximum.Location = new System.Drawing.Point(258, 75);
            this.lblMaximum.Name = "lblMaximum";
            this.lblMaximum.Size = new System.Drawing.Size(51, 13);
            this.lblMaximum.TabIndex = 39;
            this.lblMaximum.Text = "Maximum";
            // 
            // txtMinimum
            // 
            this.txtMinimum.Location = new System.Drawing.Point(129, 72);
            this.txtMinimum.Name = "txtMinimum";
            this.txtMinimum.Size = new System.Drawing.Size(90, 20);
            this.txtMinimum.TabIndex = 42;
            this.txtMinimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMinimum
            // 
            this.lblMinimum.AutoSize = true;
            this.lblMinimum.Location = new System.Drawing.Point(6, 75);
            this.lblMinimum.Name = "lblMinimum";
            this.lblMinimum.Size = new System.Drawing.Size(48, 13);
            this.lblMinimum.TabIndex = 41;
            this.lblMinimum.Text = "Minimum";
            // 
            // txtReadInterval
            // 
            this.txtReadInterval.Location = new System.Drawing.Point(367, 98);
            this.txtReadInterval.Name = "txtReadInterval";
            this.txtReadInterval.Size = new System.Drawing.Size(90, 20);
            this.txtReadInterval.TabIndex = 38;
            this.txtReadInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblReadInterval
            // 
            this.lblReadInterval.AutoSize = true;
            this.lblReadInterval.Location = new System.Drawing.Point(258, 101);
            this.lblReadInterval.Name = "lblReadInterval";
            this.lblReadInterval.Size = new System.Drawing.Size(93, 13);
            this.lblReadInterval.TabIndex = 37;
            this.lblReadInterval.Text = "Read Interval [ms]";
            // 
            // cbxPin
            // 
            this.cbxPin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPin.FormattingEnabled = true;
            this.cbxPin.Location = new System.Drawing.Point(129, 45);
            this.cbxPin.Name = "cbxPin";
            this.cbxPin.Size = new System.Drawing.Size(90, 21);
            this.cbxPin.TabIndex = 36;
            this.cbxPin.SelectedValueChanged += new System.EventHandler(this.cbxPin_SelectedValueChanged);
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
            this.lblPin.Size = new System.Drawing.Size(54, 13);
            this.lblPin.TabIndex = 32;
            this.lblPin.Text = "Digital Pin";
            // 
            // txtPostfix
            // 
            this.txtPostfix.Location = new System.Drawing.Point(129, 98);
            this.txtPostfix.Name = "txtPostfix";
            this.txtPostfix.Size = new System.Drawing.Size(90, 20);
            this.txtPostfix.TabIndex = 27;
            this.txtPostfix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPostfix
            // 
            this.lblPostfix.AutoSize = true;
            this.lblPostfix.Location = new System.Drawing.Point(6, 101);
            this.lblPostfix.Name = "lblPostfix";
            this.lblPostfix.Size = new System.Drawing.Size(38, 13);
            this.lblPostfix.TabIndex = 26;
            this.lblPostfix.Text = "Postfix";
            // 
            // grpTranslation
            // 
            this.grpTranslation.Controls.Add(this.imgLinearFunction);
            this.grpTranslation.Controls.Add(this.lblInfo5);
            this.grpTranslation.Controls.Add(this.txtIntercept);
            this.grpTranslation.Controls.Add(this.lblIntercept);
            this.grpTranslation.Controls.Add(this.txtSlope);
            this.grpTranslation.Controls.Add(this.lblSlope);
            this.grpTranslation.Controls.Add(this.lblInfo4);
            this.grpTranslation.Location = new System.Drawing.Point(12, 236);
            this.grpTranslation.Name = "grpTranslation";
            this.grpTranslation.Size = new System.Drawing.Size(472, 181);
            this.grpTranslation.TabIndex = 11;
            this.grpTranslation.TabStop = false;
            this.grpTranslation.Text = "Translation";
            // 
            // imgLinearFunction
            // 
            this.imgLinearFunction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgLinearFunction.ErrorImage = global::RemoteCtrl.Properties.Resources.linear_function;
            this.imgLinearFunction.Image = global::RemoteCtrl.Properties.Resources.linear_function;
            this.imgLinearFunction.InitialImage = global::RemoteCtrl.Properties.Resources.linear_function;
            this.imgLinearFunction.Location = new System.Drawing.Point(261, 51);
            this.imgLinearFunction.Name = "imgLinearFunction";
            this.imgLinearFunction.Size = new System.Drawing.Size(198, 120);
            this.imgLinearFunction.TabIndex = 34;
            this.imgLinearFunction.TabStop = false;
            // 
            // lblInfo5
            // 
            this.lblInfo5.AutoSize = true;
            this.lblInfo5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblInfo5.Location = new System.Drawing.Point(113, 66);
            this.lblInfo5.Name = "lblInfo5";
            this.lblInfo5.Size = new System.Drawing.Size(106, 20);
            this.lblInfo5.TabIndex = 33;
            this.lblInfo5.Text = "y = f(x) = ax+b";
            // 
            // txtIntercept
            // 
            this.txtIntercept.Location = new System.Drawing.Point(92, 127);
            this.txtIntercept.Name = "txtIntercept";
            this.txtIntercept.Size = new System.Drawing.Size(151, 20);
            this.txtIntercept.TabIndex = 32;
            this.txtIntercept.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblIntercept
            // 
            this.lblIntercept.AutoSize = true;
            this.lblIntercept.Location = new System.Drawing.Point(10, 130);
            this.lblIntercept.Name = "lblIntercept";
            this.lblIntercept.Size = new System.Drawing.Size(64, 13);
            this.lblIntercept.TabIndex = 31;
            this.lblIntercept.Text = "Intercept [b]";
            // 
            // txtSlope
            // 
            this.txtSlope.Location = new System.Drawing.Point(92, 101);
            this.txtSlope.Name = "txtSlope";
            this.txtSlope.Size = new System.Drawing.Size(151, 20);
            this.txtSlope.TabIndex = 30;
            this.txtSlope.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSlope
            // 
            this.lblSlope.AutoSize = true;
            this.lblSlope.Location = new System.Drawing.Point(10, 104);
            this.lblSlope.Name = "lblSlope";
            this.lblSlope.Size = new System.Drawing.Size(49, 13);
            this.lblSlope.TabIndex = 29;
            this.lblSlope.Text = "Slope [a]";
            // 
            // lblInfo4
            // 
            this.lblInfo4.AutoSize = true;
            this.lblInfo4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblInfo4.Location = new System.Drawing.Point(6, 21);
            this.lblInfo4.Name = "lblInfo4";
            this.lblInfo4.Size = new System.Drawing.Size(462, 13);
            this.lblInfo4.TabIndex = 0;
            this.lblInfo4.Text = "This linear function is used to translate the measured value on the Arduino to a " +
    "meaningful value.";
            // 
            // grpLogging
            // 
            this.grpLogging.Controls.Add(this.txtLogInterval);
            this.grpLogging.Controls.Add(this.lblLogInterval);
            this.grpLogging.Controls.Add(this.txtLogCapacity);
            this.grpLogging.Controls.Add(this.lblLogCapacity);
            this.grpLogging.Controls.Add(this.boxLogging);
            this.grpLogging.Location = new System.Drawing.Point(12, 152);
            this.grpLogging.Name = "grpLogging";
            this.grpLogging.Size = new System.Drawing.Size(472, 78);
            this.grpLogging.TabIndex = 12;
            this.grpLogging.TabStop = false;
            this.grpLogging.Text = "Logbook";
            // 
            // txtLogInterval
            // 
            this.txtLogInterval.Location = new System.Drawing.Point(129, 45);
            this.txtLogInterval.Name = "txtLogInterval";
            this.txtLogInterval.Size = new System.Drawing.Size(90, 20);
            this.txtLogInterval.TabIndex = 42;
            this.txtLogInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLogInterval
            // 
            this.lblLogInterval.AutoSize = true;
            this.lblLogInterval.Location = new System.Drawing.Point(6, 48);
            this.lblLogInterval.Name = "lblLogInterval";
            this.lblLogInterval.Size = new System.Drawing.Size(85, 13);
            this.lblLogInterval.TabIndex = 41;
            this.lblLogInterval.Text = "Log Interval [ms]";
            // 
            // txtLogCapacity
            // 
            this.txtLogCapacity.Location = new System.Drawing.Point(129, 19);
            this.txtLogCapacity.Name = "txtLogCapacity";
            this.txtLogCapacity.Size = new System.Drawing.Size(90, 20);
            this.txtLogCapacity.TabIndex = 40;
            this.txtLogCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLogCapacity
            // 
            this.lblLogCapacity.AutoSize = true;
            this.lblLogCapacity.Location = new System.Drawing.Point(6, 22);
            this.lblLogCapacity.Name = "lblLogCapacity";
            this.lblLogCapacity.Size = new System.Drawing.Size(69, 13);
            this.lblLogCapacity.TabIndex = 39;
            this.lblLogCapacity.Text = "Log Capacity";
            // 
            // boxLogging
            // 
            this.boxLogging.AutoSize = true;
            this.boxLogging.Location = new System.Drawing.Point(393, 22);
            this.boxLogging.Name = "boxLogging";
            this.boxLogging.Size = new System.Drawing.Size(64, 17);
            this.boxLogging.TabIndex = 0;
            this.boxLogging.Text = "Logging";
            this.boxLogging.UseVisualStyleBackColor = true;
            // 
            // HumidityConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 428);
            this.Controls.Add(this.grpLogging);
            this.Controls.Add(this.grpTranslation);
            this.Controls.Add(this.grpProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HumidityConfigWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Humidity Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HumidityConfigWindow_FormClosing);
            this.grpProperties.ResumeLayout(false);
            this.grpProperties.PerformLayout();
            this.grpTranslation.ResumeLayout(false);
            this.grpTranslation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLinearFunction)).EndInit();
            this.grpLogging.ResumeLayout(false);
            this.grpLogging.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProperties;
        private System.Windows.Forms.ComboBox cbxPin;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPin;
        private System.Windows.Forms.TextBox txtPostfix;
        private System.Windows.Forms.Label lblPostfix;
        private System.Windows.Forms.GroupBox grpTranslation;
        private System.Windows.Forms.PictureBox imgLinearFunction;
        private System.Windows.Forms.Label lblInfo5;
        private System.Windows.Forms.TextBox txtIntercept;
        private System.Windows.Forms.Label lblIntercept;
        private System.Windows.Forms.TextBox txtSlope;
        private System.Windows.Forms.Label lblSlope;
        private System.Windows.Forms.Label lblInfo4;
        private System.Windows.Forms.TextBox txtReadInterval;
        private System.Windows.Forms.Label lblReadInterval;
        private System.Windows.Forms.GroupBox grpLogging;
        private System.Windows.Forms.TextBox txtLogInterval;
        private System.Windows.Forms.Label lblLogInterval;
        private System.Windows.Forms.TextBox txtLogCapacity;
        private System.Windows.Forms.Label lblLogCapacity;
        private System.Windows.Forms.CheckBox boxLogging;
        private System.Windows.Forms.TextBox txtMaximum;
        private System.Windows.Forms.Label lblMaximum;
        private System.Windows.Forms.TextBox txtMinimum;
        private System.Windows.Forms.Label lblMinimum;
    }
}
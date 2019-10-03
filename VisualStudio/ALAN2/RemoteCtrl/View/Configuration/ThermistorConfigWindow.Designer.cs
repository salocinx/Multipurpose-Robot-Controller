namespace RemoteCtrl {
    partial class ThermistorConfigWindow {
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
            this.grpLogging = new System.Windows.Forms.GroupBox();
            this.txtLogInterval = new System.Windows.Forms.TextBox();
            this.lblLogInterval = new System.Windows.Forms.Label();
            this.txtLogCapacity = new System.Windows.Forms.TextBox();
            this.lblLogCapacity = new System.Windows.Forms.Label();
            this.boxLogging = new System.Windows.Forms.CheckBox();
            this.grpTranslation = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblSeriesResistor = new System.Windows.Forms.Label();
            this.txtNominal2 = new System.Windows.Forms.TextBox();
            this.lblNominal2 = new System.Windows.Forms.Label();
            this.imgLinearFunction = new System.Windows.Forms.PictureBox();
            this.txtBetaCoefficient = new System.Windows.Forms.TextBox();
            this.lblBetaCoefficient = new System.Windows.Forms.Label();
            this.txtNominal1 = new System.Windows.Forms.TextBox();
            this.lblNominal1 = new System.Windows.Forms.Label();
            this.lblInfo4 = new System.Windows.Forms.Label();
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
            this.grpLogging.SuspendLayout();
            this.grpTranslation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLinearFunction)).BeginInit();
            this.grpProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLogging
            // 
            this.grpLogging.Controls.Add(this.txtLogInterval);
            this.grpLogging.Controls.Add(this.lblLogInterval);
            this.grpLogging.Controls.Add(this.txtLogCapacity);
            this.grpLogging.Controls.Add(this.lblLogCapacity);
            this.grpLogging.Controls.Add(this.boxLogging);
            this.grpLogging.Location = new System.Drawing.Point(12, 151);
            this.grpLogging.Name = "grpLogging";
            this.grpLogging.Size = new System.Drawing.Size(472, 78);
            this.grpLogging.TabIndex = 18;
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
            // grpTranslation
            // 
            this.grpTranslation.Controls.Add(this.textBox2);
            this.grpTranslation.Controls.Add(this.lblSeriesResistor);
            this.grpTranslation.Controls.Add(this.txtNominal2);
            this.grpTranslation.Controls.Add(this.lblNominal2);
            this.grpTranslation.Controls.Add(this.imgLinearFunction);
            this.grpTranslation.Controls.Add(this.txtBetaCoefficient);
            this.grpTranslation.Controls.Add(this.lblBetaCoefficient);
            this.grpTranslation.Controls.Add(this.txtNominal1);
            this.grpTranslation.Controls.Add(this.lblNominal1);
            this.grpTranslation.Controls.Add(this.lblInfo4);
            this.grpTranslation.Location = new System.Drawing.Point(12, 235);
            this.grpTranslation.Name = "grpTranslation";
            this.grpTranslation.Size = new System.Drawing.Size(472, 181);
            this.grpTranslation.TabIndex = 17;
            this.grpTranslation.TabStop = false;
            this.grpTranslation.Text = "Translation";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(129, 138);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(114, 20);
            this.textBox2.TabIndex = 38;
            this.textBox2.Text = "10000";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSeriesResistor
            // 
            this.lblSeriesResistor.AutoSize = true;
            this.lblSeriesResistor.Location = new System.Drawing.Point(10, 141);
            this.lblSeriesResistor.Name = "lblSeriesResistor";
            this.lblSeriesResistor.Size = new System.Drawing.Size(77, 13);
            this.lblSeriesResistor.TabIndex = 37;
            this.lblSeriesResistor.Text = "Series Resistor";
            // 
            // txtNominal2
            // 
            this.txtNominal2.Enabled = false;
            this.txtNominal2.Location = new System.Drawing.Point(129, 86);
            this.txtNominal2.Name = "txtNominal2";
            this.txtNominal2.Size = new System.Drawing.Size(114, 20);
            this.txtNominal2.TabIndex = 36;
            this.txtNominal2.Text = "25";
            this.txtNominal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNominal2
            // 
            this.lblNominal2.AutoSize = true;
            this.lblNominal2.Location = new System.Drawing.Point(10, 89);
            this.lblNominal2.Name = "lblNominal2";
            this.lblNominal2.Size = new System.Drawing.Size(108, 13);
            this.lblNominal2.TabIndex = 35;
            this.lblNominal2.Text = "Temperature Nominal";
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
            // txtBetaCoefficient
            // 
            this.txtBetaCoefficient.Enabled = false;
            this.txtBetaCoefficient.Location = new System.Drawing.Point(129, 112);
            this.txtBetaCoefficient.Name = "txtBetaCoefficient";
            this.txtBetaCoefficient.Size = new System.Drawing.Size(114, 20);
            this.txtBetaCoefficient.TabIndex = 32;
            this.txtBetaCoefficient.Text = "3977";
            this.txtBetaCoefficient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBetaCoefficient
            // 
            this.lblBetaCoefficient.AutoSize = true;
            this.lblBetaCoefficient.Location = new System.Drawing.Point(10, 115);
            this.lblBetaCoefficient.Name = "lblBetaCoefficient";
            this.lblBetaCoefficient.Size = new System.Drawing.Size(82, 13);
            this.lblBetaCoefficient.TabIndex = 31;
            this.lblBetaCoefficient.Text = "Beta Coefficient";
            // 
            // txtNominal1
            // 
            this.txtNominal1.Enabled = false;
            this.txtNominal1.Location = new System.Drawing.Point(129, 60);
            this.txtNominal1.Name = "txtNominal1";
            this.txtNominal1.Size = new System.Drawing.Size(114, 20);
            this.txtNominal1.TabIndex = 30;
            this.txtNominal1.Text = "10000";
            this.txtNominal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNominal1
            // 
            this.lblNominal1.AutoSize = true;
            this.lblNominal1.Location = new System.Drawing.Point(10, 63);
            this.lblNominal1.Name = "lblNominal1";
            this.lblNominal1.Size = new System.Drawing.Size(97, 13);
            this.lblNominal1.TabIndex = 29;
            this.lblNominal1.Text = "Thermistor Nominal";
            // 
            // lblInfo4
            // 
            this.lblInfo4.AutoSize = true;
            this.lblInfo4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblInfo4.Location = new System.Drawing.Point(6, 25);
            this.lblInfo4.Name = "lblInfo4";
            this.lblInfo4.Size = new System.Drawing.Size(274, 13);
            this.lblInfo4.TabIndex = 0;
            this.lblInfo4.Text = "The thermal data is computed by the beta factor method.";
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
            this.grpProperties.Size = new System.Drawing.Size(472, 133);
            this.grpProperties.TabIndex = 16;
            this.grpProperties.TabStop = false;
            this.grpProperties.Text = "Properties";
            // 
            // txtMaximum
            // 
            this.txtMaximum.Location = new System.Drawing.Point(367, 72);
            this.txtMaximum.Name = "txtMaximum";
            this.txtMaximum.Size = new System.Drawing.Size(90, 20);
            this.txtMaximum.TabIndex = 44;
            this.txtMaximum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMaximum
            // 
            this.lblMaximum.AutoSize = true;
            this.lblMaximum.Location = new System.Drawing.Point(258, 75);
            this.lblMaximum.Name = "lblMaximum";
            this.lblMaximum.Size = new System.Drawing.Size(51, 13);
            this.lblMaximum.TabIndex = 43;
            this.lblMaximum.Text = "Maximum";
            // 
            // txtMinimum
            // 
            this.txtMinimum.Location = new System.Drawing.Point(129, 72);
            this.txtMinimum.Name = "txtMinimum";
            this.txtMinimum.Size = new System.Drawing.Size(90, 20);
            this.txtMinimum.TabIndex = 46;
            this.txtMinimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMinimum
            // 
            this.lblMinimum.AutoSize = true;
            this.lblMinimum.Location = new System.Drawing.Point(6, 75);
            this.lblMinimum.Name = "lblMinimum";
            this.lblMinimum.Size = new System.Drawing.Size(48, 13);
            this.lblMinimum.TabIndex = 45;
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
            this.lblPin.Size = new System.Drawing.Size(58, 13);
            this.lblPin.TabIndex = 32;
            this.lblPin.Text = "Analog Pin";
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
            // ThermistorConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 429);
            this.Controls.Add(this.grpLogging);
            this.Controls.Add(this.grpTranslation);
            this.Controls.Add(this.grpProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ThermistorConfigWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thermistor Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThermistorConfigWindow_FormClosing);
            this.grpLogging.ResumeLayout(false);
            this.grpLogging.PerformLayout();
            this.grpTranslation.ResumeLayout(false);
            this.grpTranslation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLinearFunction)).EndInit();
            this.grpProperties.ResumeLayout(false);
            this.grpProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLogging;
        private System.Windows.Forms.TextBox txtLogInterval;
        private System.Windows.Forms.Label lblLogInterval;
        private System.Windows.Forms.TextBox txtLogCapacity;
        private System.Windows.Forms.Label lblLogCapacity;
        private System.Windows.Forms.CheckBox boxLogging;
        private System.Windows.Forms.GroupBox grpTranslation;
        private System.Windows.Forms.PictureBox imgLinearFunction;
        private System.Windows.Forms.TextBox txtBetaCoefficient;
        private System.Windows.Forms.Label lblBetaCoefficient;
        private System.Windows.Forms.TextBox txtNominal1;
        private System.Windows.Forms.Label lblNominal1;
        private System.Windows.Forms.Label lblInfo4;
        private System.Windows.Forms.GroupBox grpProperties;
        private System.Windows.Forms.TextBox txtReadInterval;
        private System.Windows.Forms.Label lblReadInterval;
        private System.Windows.Forms.ComboBox cbxPin;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPin;
        private System.Windows.Forms.TextBox txtPostfix;
        private System.Windows.Forms.Label lblPostfix;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblSeriesResistor;
        private System.Windows.Forms.TextBox txtNominal2;
        private System.Windows.Forms.Label lblNominal2;
        private System.Windows.Forms.TextBox txtMaximum;
        private System.Windows.Forms.Label lblMaximum;
        private System.Windows.Forms.TextBox txtMinimum;
        private System.Windows.Forms.Label lblMinimum;
    }
}
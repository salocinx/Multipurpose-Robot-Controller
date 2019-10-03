namespace RemoteCtrl {
    partial class BatteryConfigWindow {
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
            this.components = new System.ComponentModel.Container();
            this.grpProperties = new System.Windows.Forms.GroupBox();
            this.txtReadInterval = new System.Windows.Forms.TextBox();
            this.lblReadInterval = new System.Windows.Forms.Label();
            this.txtPostfix = new System.Windows.Forms.TextBox();
            this.txtMaximumVoltage = new System.Windows.Forms.TextBox();
            this.lblMaximumVoltage = new System.Windows.Forms.Label();
            this.txtMinimumVoltage = new System.Windows.Forms.TextBox();
            this.lblMinimumVoltage = new System.Windows.Forms.Label();
            this.txtCriticalVoltage = new System.Windows.Forms.TextBox();
            this.lblCriticalVoltage = new System.Windows.Forms.Label();
            this.lblPostfix = new System.Windows.Forms.Label();
            this.cbxPin = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPin = new System.Windows.Forms.Label();
            this.boxCharging = new System.Windows.Forms.CheckBox();
            this.lblInfo3 = new System.Windows.Forms.Label();
            this.imgBatteryL5 = new System.Windows.Forms.PictureBox();
            this.txtBatteryL5 = new System.Windows.Forms.TextBox();
            this.imgBatteryL4 = new System.Windows.Forms.PictureBox();
            this.txtBatteryL4 = new System.Windows.Forms.TextBox();
            this.imgBatteryL3 = new System.Windows.Forms.PictureBox();
            this.txtBatteryL3 = new System.Windows.Forms.TextBox();
            this.imgBatteryL2 = new System.Windows.Forms.PictureBox();
            this.txtBatteryL2 = new System.Windows.Forms.TextBox();
            this.imgBatteryL1 = new System.Windows.Forms.PictureBox();
            this.txtBatteryL1 = new System.Windows.Forms.TextBox();
            this.imgBatteryL0 = new System.Windows.Forms.PictureBox();
            this.txtBatteryL0 = new System.Windows.Forms.TextBox();
            this.grpTranslation = new System.Windows.Forms.GroupBox();
            this.imgLinearFunction = new System.Windows.Forms.PictureBox();
            this.lblInfo5 = new System.Windows.Forms.Label();
            this.txtIntercept = new System.Windows.Forms.TextBox();
            this.lblIntercept = new System.Windows.Forms.Label();
            this.txtSlope = new System.Windows.Forms.TextBox();
            this.lblSlope = new System.Windows.Forms.Label();
            this.lblInfo4 = new System.Windows.Forms.Label();
            this.tipMaximumVoltage = new System.Windows.Forms.ToolTip(this.components);
            this.tipCriticalVoltage = new System.Windows.Forms.ToolTip(this.components);
            this.grpLogging = new System.Windows.Forms.GroupBox();
            this.txtLogInterval = new System.Windows.Forms.TextBox();
            this.lblLogInterval = new System.Windows.Forms.Label();
            this.txtLogCapacity = new System.Windows.Forms.TextBox();
            this.lblLogCapacity = new System.Windows.Forms.Label();
            this.boxLogging = new System.Windows.Forms.CheckBox();
            this.grpProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBatteryL5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBatteryL4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBatteryL3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBatteryL2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBatteryL1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBatteryL0)).BeginInit();
            this.grpTranslation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLinearFunction)).BeginInit();
            this.grpLogging.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpProperties
            // 
            this.grpProperties.Controls.Add(this.txtReadInterval);
            this.grpProperties.Controls.Add(this.lblReadInterval);
            this.grpProperties.Controls.Add(this.txtPostfix);
            this.grpProperties.Controls.Add(this.txtMaximumVoltage);
            this.grpProperties.Controls.Add(this.lblMaximumVoltage);
            this.grpProperties.Controls.Add(this.txtMinimumVoltage);
            this.grpProperties.Controls.Add(this.lblMinimumVoltage);
            this.grpProperties.Controls.Add(this.txtCriticalVoltage);
            this.grpProperties.Controls.Add(this.lblCriticalVoltage);
            this.grpProperties.Controls.Add(this.lblPostfix);
            this.grpProperties.Controls.Add(this.cbxPin);
            this.grpProperties.Controls.Add(this.txtName);
            this.grpProperties.Controls.Add(this.lblName);
            this.grpProperties.Controls.Add(this.lblPin);
            this.grpProperties.Controls.Add(this.boxCharging);
            this.grpProperties.Controls.Add(this.lblInfo3);
            this.grpProperties.Controls.Add(this.imgBatteryL5);
            this.grpProperties.Controls.Add(this.txtBatteryL5);
            this.grpProperties.Controls.Add(this.imgBatteryL4);
            this.grpProperties.Controls.Add(this.txtBatteryL4);
            this.grpProperties.Controls.Add(this.imgBatteryL3);
            this.grpProperties.Controls.Add(this.txtBatteryL3);
            this.grpProperties.Controls.Add(this.imgBatteryL2);
            this.grpProperties.Controls.Add(this.txtBatteryL2);
            this.grpProperties.Controls.Add(this.imgBatteryL1);
            this.grpProperties.Controls.Add(this.txtBatteryL1);
            this.grpProperties.Controls.Add(this.imgBatteryL0);
            this.grpProperties.Controls.Add(this.txtBatteryL0);
            this.grpProperties.Location = new System.Drawing.Point(12, 12);
            this.grpProperties.Name = "grpProperties";
            this.grpProperties.Size = new System.Drawing.Size(472, 241);
            this.grpProperties.TabIndex = 9;
            this.grpProperties.TabStop = false;
            this.grpProperties.Text = "Properties";
            // 
            // txtReadInterval
            // 
            this.txtReadInterval.Location = new System.Drawing.Point(367, 99);
            this.txtReadInterval.Name = "txtReadInterval";
            this.txtReadInterval.Size = new System.Drawing.Size(90, 20);
            this.txtReadInterval.TabIndex = 42;
            this.txtReadInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblReadInterval
            // 
            this.lblReadInterval.AutoSize = true;
            this.lblReadInterval.Location = new System.Drawing.Point(257, 102);
            this.lblReadInterval.Name = "lblReadInterval";
            this.lblReadInterval.Size = new System.Drawing.Size(93, 13);
            this.lblReadInterval.TabIndex = 41;
            this.lblReadInterval.Text = "Read Interval [ms]";
            // 
            // txtPostfix
            // 
            this.txtPostfix.Location = new System.Drawing.Point(110, 99);
            this.txtPostfix.Name = "txtPostfix";
            this.txtPostfix.Size = new System.Drawing.Size(90, 20);
            this.txtPostfix.TabIndex = 40;
            this.txtPostfix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMaximumVoltage
            // 
            this.txtMaximumVoltage.Location = new System.Drawing.Point(367, 71);
            this.txtMaximumVoltage.Name = "txtMaximumVoltage";
            this.txtMaximumVoltage.Size = new System.Drawing.Size(90, 20);
            this.txtMaximumVoltage.TabIndex = 1;
            this.txtMaximumVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipMaximumVoltage.SetToolTip(this.txtMaximumVoltage, "Values above are interpreted as charging.");
            // 
            // lblMaximumVoltage
            // 
            this.lblMaximumVoltage.AutoSize = true;
            this.lblMaximumVoltage.Location = new System.Drawing.Point(258, 74);
            this.lblMaximumVoltage.Name = "lblMaximumVoltage";
            this.lblMaximumVoltage.Size = new System.Drawing.Size(67, 13);
            this.lblMaximumVoltage.TabIndex = 0;
            this.lblMaximumVoltage.Text = "Maximum [V]";
            // 
            // txtMinimumVoltage
            // 
            this.txtMinimumVoltage.Location = new System.Drawing.Point(110, 72);
            this.txtMinimumVoltage.Name = "txtMinimumVoltage";
            this.txtMinimumVoltage.Size = new System.Drawing.Size(90, 20);
            this.txtMinimumVoltage.TabIndex = 27;
            this.txtMinimumVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMinimumVoltage
            // 
            this.lblMinimumVoltage.AutoSize = true;
            this.lblMinimumVoltage.Location = new System.Drawing.Point(6, 75);
            this.lblMinimumVoltage.Name = "lblMinimumVoltage";
            this.lblMinimumVoltage.Size = new System.Drawing.Size(64, 13);
            this.lblMinimumVoltage.TabIndex = 26;
            this.lblMinimumVoltage.Text = "Minimum [V]";
            // 
            // txtCriticalVoltage
            // 
            this.txtCriticalVoltage.Location = new System.Drawing.Point(367, 45);
            this.txtCriticalVoltage.Name = "txtCriticalVoltage";
            this.txtCriticalVoltage.Size = new System.Drawing.Size(90, 20);
            this.txtCriticalVoltage.TabIndex = 31;
            this.txtCriticalVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipCriticalVoltage.SetToolTip(this.txtCriticalVoltage, "Values below trigger an event (e.g. can be used for auto-shutdown, charging-stati" +
        "on).");
            // 
            // lblCriticalVoltage
            // 
            this.lblCriticalVoltage.AutoSize = true;
            this.lblCriticalVoltage.Location = new System.Drawing.Point(258, 48);
            this.lblCriticalVoltage.Name = "lblCriticalVoltage";
            this.lblCriticalVoltage.Size = new System.Drawing.Size(93, 13);
            this.lblCriticalVoltage.TabIndex = 30;
            this.lblCriticalVoltage.Text = "Critical Voltage [V]";
            // 
            // lblPostfix
            // 
            this.lblPostfix.AutoSize = true;
            this.lblPostfix.Location = new System.Drawing.Point(6, 102);
            this.lblPostfix.Name = "lblPostfix";
            this.lblPostfix.Size = new System.Drawing.Size(38, 13);
            this.lblPostfix.TabIndex = 39;
            this.lblPostfix.Text = "Postfix";
            // 
            // cbxPin
            // 
            this.cbxPin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPin.FormattingEnabled = true;
            this.cbxPin.Location = new System.Drawing.Point(110, 45);
            this.cbxPin.Name = "cbxPin";
            this.cbxPin.Size = new System.Drawing.Size(90, 21);
            this.cbxPin.TabIndex = 36;
            this.cbxPin.SelectedValueChanged += new System.EventHandler(this.cbxPin_SelectedValueChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(110, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(347, 20);
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
            // boxCharging
            // 
            this.boxCharging.AutoSize = true;
            this.boxCharging.Enabled = false;
            this.boxCharging.Location = new System.Drawing.Point(393, 143);
            this.boxCharging.Name = "boxCharging";
            this.boxCharging.Size = new System.Drawing.Size(68, 17);
            this.boxCharging.TabIndex = 29;
            this.boxCharging.Text = "Charging";
            this.boxCharging.UseVisualStyleBackColor = true;
            // 
            // lblInfo3
            // 
            this.lblInfo3.AutoSize = true;
            this.lblInfo3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblInfo3.Location = new System.Drawing.Point(6, 144);
            this.lblInfo3.Name = "lblInfo3";
            this.lblInfo3.Size = new System.Drawing.Size(257, 13);
            this.lblInfo3.TabIndex = 1;
            this.lblInfo3.Text = "These are the voltage levels to indicate battery state.";
            // 
            // imgBatteryL5
            // 
            this.imgBatteryL5.ErrorImage = global::RemoteCtrl.Properties.Resources.battery_5;
            this.imgBatteryL5.Image = global::RemoteCtrl.Properties.Resources.battery_5;
            this.imgBatteryL5.InitialImage = global::RemoteCtrl.Properties.Resources.battery_5;
            this.imgBatteryL5.Location = new System.Drawing.Point(336, 206);
            this.imgBatteryL5.Name = "imgBatteryL5";
            this.imgBatteryL5.Size = new System.Drawing.Size(44, 24);
            this.imgBatteryL5.TabIndex = 24;
            this.imgBatteryL5.TabStop = false;
            // 
            // txtBatteryL5
            // 
            this.txtBatteryL5.Location = new System.Drawing.Point(394, 208);
            this.txtBatteryL5.Name = "txtBatteryL5";
            this.txtBatteryL5.Size = new System.Drawing.Size(60, 20);
            this.txtBatteryL5.TabIndex = 23;
            this.txtBatteryL5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // imgBatteryL4
            // 
            this.imgBatteryL4.ErrorImage = global::RemoteCtrl.Properties.Resources.battery_4;
            this.imgBatteryL4.Image = global::RemoteCtrl.Properties.Resources.battery_4;
            this.imgBatteryL4.InitialImage = global::RemoteCtrl.Properties.Resources.battery_4;
            this.imgBatteryL4.Location = new System.Drawing.Point(175, 206);
            this.imgBatteryL4.Name = "imgBatteryL4";
            this.imgBatteryL4.Size = new System.Drawing.Size(44, 24);
            this.imgBatteryL4.TabIndex = 22;
            this.imgBatteryL4.TabStop = false;
            // 
            // txtBatteryL4
            // 
            this.txtBatteryL4.Location = new System.Drawing.Point(233, 208);
            this.txtBatteryL4.Name = "txtBatteryL4";
            this.txtBatteryL4.Size = new System.Drawing.Size(60, 20);
            this.txtBatteryL4.TabIndex = 21;
            this.txtBatteryL4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // imgBatteryL3
            // 
            this.imgBatteryL3.ErrorImage = global::RemoteCtrl.Properties.Resources.battery_3;
            this.imgBatteryL3.Image = global::RemoteCtrl.Properties.Resources.battery_3;
            this.imgBatteryL3.InitialImage = global::RemoteCtrl.Properties.Resources.battery_3;
            this.imgBatteryL3.Location = new System.Drawing.Point(9, 206);
            this.imgBatteryL3.Name = "imgBatteryL3";
            this.imgBatteryL3.Size = new System.Drawing.Size(44, 24);
            this.imgBatteryL3.TabIndex = 20;
            this.imgBatteryL3.TabStop = false;
            // 
            // txtBatteryL3
            // 
            this.txtBatteryL3.Location = new System.Drawing.Point(67, 208);
            this.txtBatteryL3.Name = "txtBatteryL3";
            this.txtBatteryL3.Size = new System.Drawing.Size(60, 20);
            this.txtBatteryL3.TabIndex = 19;
            this.txtBatteryL3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // imgBatteryL2
            // 
            this.imgBatteryL2.ErrorImage = global::RemoteCtrl.Properties.Resources.battery_2;
            this.imgBatteryL2.Image = global::RemoteCtrl.Properties.Resources.battery_2;
            this.imgBatteryL2.InitialImage = global::RemoteCtrl.Properties.Resources.battery_2;
            this.imgBatteryL2.Location = new System.Drawing.Point(336, 172);
            this.imgBatteryL2.Name = "imgBatteryL2";
            this.imgBatteryL2.Size = new System.Drawing.Size(44, 24);
            this.imgBatteryL2.TabIndex = 18;
            this.imgBatteryL2.TabStop = false;
            // 
            // txtBatteryL2
            // 
            this.txtBatteryL2.Location = new System.Drawing.Point(394, 174);
            this.txtBatteryL2.Name = "txtBatteryL2";
            this.txtBatteryL2.Size = new System.Drawing.Size(60, 20);
            this.txtBatteryL2.TabIndex = 17;
            this.txtBatteryL2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // imgBatteryL1
            // 
            this.imgBatteryL1.ErrorImage = global::RemoteCtrl.Properties.Resources.battery_1;
            this.imgBatteryL1.Image = global::RemoteCtrl.Properties.Resources.battery_1;
            this.imgBatteryL1.InitialImage = global::RemoteCtrl.Properties.Resources.battery_1;
            this.imgBatteryL1.Location = new System.Drawing.Point(175, 172);
            this.imgBatteryL1.Name = "imgBatteryL1";
            this.imgBatteryL1.Size = new System.Drawing.Size(44, 24);
            this.imgBatteryL1.TabIndex = 16;
            this.imgBatteryL1.TabStop = false;
            // 
            // txtBatteryL1
            // 
            this.txtBatteryL1.Location = new System.Drawing.Point(233, 174);
            this.txtBatteryL1.Name = "txtBatteryL1";
            this.txtBatteryL1.Size = new System.Drawing.Size(60, 20);
            this.txtBatteryL1.TabIndex = 15;
            this.txtBatteryL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // imgBatteryL0
            // 
            this.imgBatteryL0.ErrorImage = global::RemoteCtrl.Properties.Resources.battery_0;
            this.imgBatteryL0.Image = global::RemoteCtrl.Properties.Resources.battery_0;
            this.imgBatteryL0.InitialImage = global::RemoteCtrl.Properties.Resources.battery_0;
            this.imgBatteryL0.Location = new System.Drawing.Point(9, 172);
            this.imgBatteryL0.Name = "imgBatteryL0";
            this.imgBatteryL0.Size = new System.Drawing.Size(44, 24);
            this.imgBatteryL0.TabIndex = 14;
            this.imgBatteryL0.TabStop = false;
            // 
            // txtBatteryL0
            // 
            this.txtBatteryL0.Enabled = false;
            this.txtBatteryL0.Location = new System.Drawing.Point(67, 174);
            this.txtBatteryL0.Name = "txtBatteryL0";
            this.txtBatteryL0.Size = new System.Drawing.Size(60, 20);
            this.txtBatteryL0.TabIndex = 3;
            this.txtBatteryL0.Text = "0";
            this.txtBatteryL0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.grpTranslation.Location = new System.Drawing.Point(12, 343);
            this.grpTranslation.Name = "grpTranslation";
            this.grpTranslation.Size = new System.Drawing.Size(472, 181);
            this.grpTranslation.TabIndex = 8;
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
            this.lblInfo4.Size = new System.Drawing.Size(446, 13);
            this.lblInfo4.TabIndex = 0;
            this.lblInfo4.Text = "This linear function is used to translate the measured value on the Arduino to a " +
    "voltage value.";
            // 
            // tipMaximumVoltage
            // 
            this.tipMaximumVoltage.AutomaticDelay = 250;
            this.tipMaximumVoltage.AutoPopDelay = 10000;
            this.tipMaximumVoltage.InitialDelay = 250;
            this.tipMaximumVoltage.ReshowDelay = 50;
            // 
            // tipCriticalVoltage
            // 
            this.tipCriticalVoltage.AutomaticDelay = 250;
            this.tipCriticalVoltage.AutoPopDelay = 10000;
            this.tipCriticalVoltage.InitialDelay = 250;
            this.tipCriticalVoltage.ReshowDelay = 50;
            // 
            // grpLogging
            // 
            this.grpLogging.Controls.Add(this.txtLogInterval);
            this.grpLogging.Controls.Add(this.lblLogInterval);
            this.grpLogging.Controls.Add(this.txtLogCapacity);
            this.grpLogging.Controls.Add(this.lblLogCapacity);
            this.grpLogging.Controls.Add(this.boxLogging);
            this.grpLogging.Location = new System.Drawing.Point(12, 259);
            this.grpLogging.Name = "grpLogging";
            this.grpLogging.Size = new System.Drawing.Size(472, 78);
            this.grpLogging.TabIndex = 22;
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
            // BatteryConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 535);
            this.Controls.Add(this.grpLogging);
            this.Controls.Add(this.grpProperties);
            this.Controls.Add(this.grpTranslation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BatteryConfigWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Battery Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BatteryConfigWindow_FormClosing);
            this.grpProperties.ResumeLayout(false);
            this.grpProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBatteryL5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBatteryL4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBatteryL3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBatteryL2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBatteryL1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBatteryL0)).EndInit();
            this.grpTranslation.ResumeLayout(false);
            this.grpTranslation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLinearFunction)).EndInit();
            this.grpLogging.ResumeLayout(false);
            this.grpLogging.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProperties;
        private System.Windows.Forms.Label lblPin;
        private System.Windows.Forms.TextBox txtCriticalVoltage;
        private System.Windows.Forms.Label lblCriticalVoltage;
        private System.Windows.Forms.CheckBox boxCharging;
        private System.Windows.Forms.TextBox txtMinimumVoltage;
        private System.Windows.Forms.Label lblMinimumVoltage;
        private System.Windows.Forms.Label lblInfo3;
        private System.Windows.Forms.PictureBox imgBatteryL5;
        private System.Windows.Forms.TextBox txtBatteryL5;
        private System.Windows.Forms.PictureBox imgBatteryL4;
        private System.Windows.Forms.TextBox txtBatteryL4;
        private System.Windows.Forms.PictureBox imgBatteryL3;
        private System.Windows.Forms.TextBox txtBatteryL3;
        private System.Windows.Forms.PictureBox imgBatteryL2;
        private System.Windows.Forms.TextBox txtBatteryL2;
        private System.Windows.Forms.PictureBox imgBatteryL1;
        private System.Windows.Forms.TextBox txtBatteryL1;
        private System.Windows.Forms.PictureBox imgBatteryL0;
        private System.Windows.Forms.TextBox txtBatteryL0;
        private System.Windows.Forms.TextBox txtMaximumVoltage;
        private System.Windows.Forms.Label lblMaximumVoltage;
        private System.Windows.Forms.GroupBox grpTranslation;
        private System.Windows.Forms.PictureBox imgLinearFunction;
        private System.Windows.Forms.Label lblInfo5;
        private System.Windows.Forms.TextBox txtIntercept;
        private System.Windows.Forms.Label lblIntercept;
        private System.Windows.Forms.TextBox txtSlope;
        private System.Windows.Forms.Label lblSlope;
        private System.Windows.Forms.Label lblInfo4;
        private System.Windows.Forms.ToolTip tipMaximumVoltage;
        private System.Windows.Forms.ToolTip tipCriticalVoltage;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cbxPin;
        private System.Windows.Forms.GroupBox grpLogging;
        private System.Windows.Forms.TextBox txtLogInterval;
        private System.Windows.Forms.Label lblLogInterval;
        private System.Windows.Forms.TextBox txtLogCapacity;
        private System.Windows.Forms.Label lblLogCapacity;
        private System.Windows.Forms.CheckBox boxLogging;
        private System.Windows.Forms.TextBox txtReadInterval;
        private System.Windows.Forms.Label lblReadInterval;
        private System.Windows.Forms.TextBox txtPostfix;
        private System.Windows.Forms.Label lblPostfix;
    }
}
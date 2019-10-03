namespace RemoteCtrl {
    partial class ServoConfigWindow {
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
            this.grpStep1 = new System.Windows.Forms.GroupBox();
            this.cbxPin = new System.Windows.Forms.ComboBox();
            this.lblPin = new System.Windows.Forms.Label();
            this.lblBoard = new System.Windows.Forms.Label();
            this.cbxBoard = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.grpStep3 = new System.Windows.Forms.GroupBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.cmdMeasure = new System.Windows.Forms.Button();
            this.grpStep2 = new System.Windows.Forms.GroupBox();
            this.lblMaximum = new System.Windows.Forms.Label();
            this.txtMaximum = new System.Windows.Forms.TextBox();
            this.trkMaximum = new System.Windows.Forms.TrackBar();
            this.lblMinimum = new System.Windows.Forms.Label();
            this.txtMinimum = new System.Windows.Forms.TextBox();
            this.trkMinimum = new System.Windows.Forms.TrackBar();
            this.timUpdateProperties = new System.Windows.Forms.Timer(this.components);
            this.grpStep1.SuspendLayout();
            this.grpStep3.SuspendLayout();
            this.grpStep2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkMaximum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkMinimum)).BeginInit();
            this.SuspendLayout();
            // 
            // grpStep1
            // 
            this.grpStep1.Controls.Add(this.cbxPin);
            this.grpStep1.Controls.Add(this.lblPin);
            this.grpStep1.Controls.Add(this.lblBoard);
            this.grpStep1.Controls.Add(this.cbxBoard);
            this.grpStep1.Controls.Add(this.lblName);
            this.grpStep1.Controls.Add(this.txtName);
            this.grpStep1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStep1.Location = new System.Drawing.Point(12, 12);
            this.grpStep1.Name = "grpStep1";
            this.grpStep1.Size = new System.Drawing.Size(720, 97);
            this.grpStep1.TabIndex = 7;
            this.grpStep1.TabStop = false;
            this.grpStep1.Text = "Step 1: Define Properties";
            // 
            // cbxPin
            // 
            this.cbxPin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPin.FormattingEnabled = true;
            this.cbxPin.Location = new System.Drawing.Point(89, 59);
            this.cbxPin.Name = "cbxPin";
            this.cbxPin.Size = new System.Drawing.Size(90, 21);
            this.cbxPin.TabIndex = 11;
            this.cbxPin.SelectedValueChanged += new System.EventHandler(this.cbxPin_SelectedValueChanged);
            // 
            // lblPin
            // 
            this.lblPin.AutoSize = true;
            this.lblPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPin.Location = new System.Drawing.Point(6, 63);
            this.lblPin.Name = "lblPin";
            this.lblPin.Size = new System.Drawing.Size(52, 13);
            this.lblPin.TabIndex = 10;
            this.lblPin.Text = "PWM Pin";
            // 
            // lblBoard
            // 
            this.lblBoard.AutoSize = true;
            this.lblBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoard.Location = new System.Drawing.Point(337, 63);
            this.lblBoard.Name = "lblBoard";
            this.lblBoard.Size = new System.Drawing.Size(109, 13);
            this.lblBoard.TabIndex = 8;
            this.lblBoard.Text = "Controller Board Type";
            // 
            // cbxBoard
            // 
            this.cbxBoard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBoard.FormattingEnabled = true;
            this.cbxBoard.Items.AddRange(new object[] {
            "PCA9685 I2C-Address: 0x40",
            "PCA9685 I2C-Address: 0x41",
            "PCA9685 I2C-Address: 0x42",
            "PCA9685 I2C-Address: 0x43"});
            this.cbxBoard.Location = new System.Drawing.Point(461, 59);
            this.cbxBoard.Name = "cbxBoard";
            this.cbxBoard.Size = new System.Drawing.Size(252, 21);
            this.cbxBoard.TabIndex = 7;
            this.cbxBoard.SelectedValueChanged += new System.EventHandler(this.boxControllerBoardType_SelectedValueChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(5, 33);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(89, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(624, 20);
            this.txtName.TabIndex = 5;
            this.txtName.Text = "<Default>";
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyUp);
            // 
            // grpStep3
            // 
            this.grpStep3.Controls.Add(this.lblTime);
            this.grpStep3.Controls.Add(this.txtTime);
            this.grpStep3.Controls.Add(this.cmdMeasure);
            this.grpStep3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStep3.Location = new System.Drawing.Point(12, 255);
            this.grpStep3.Name = "grpStep3";
            this.grpStep3.Size = new System.Drawing.Size(720, 82);
            this.grpStep3.TabIndex = 5;
            this.grpStep3.TabStop = false;
            this.grpStep3.Text = "Step 3: Determine Max Speed";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(6, 36);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(111, 13);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "Time for Full Turn [ms]";
            // 
            // txtTime
            // 
            this.txtTime.Enabled = false;
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.Location = new System.Drawing.Point(136, 33);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(100, 20);
            this.txtTime.TabIndex = 6;
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdMeasure
            // 
            this.cmdMeasure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmdMeasure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMeasure.Location = new System.Drawing.Point(461, 16);
            this.cmdMeasure.Name = "cmdMeasure";
            this.cmdMeasure.Size = new System.Drawing.Size(252, 53);
            this.cmdMeasure.TabIndex = 5;
            this.cmdMeasure.Text = "Reset Measurement [F12]";
            this.cmdMeasure.UseVisualStyleBackColor = false;
            this.cmdMeasure.Click += new System.EventHandler(this.cmdMeasure_Click);
            // 
            // grpStep2
            // 
            this.grpStep2.Controls.Add(this.lblMaximum);
            this.grpStep2.Controls.Add(this.txtMaximum);
            this.grpStep2.Controls.Add(this.trkMaximum);
            this.grpStep2.Controls.Add(this.lblMinimum);
            this.grpStep2.Controls.Add(this.txtMinimum);
            this.grpStep2.Controls.Add(this.trkMinimum);
            this.grpStep2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStep2.Location = new System.Drawing.Point(12, 115);
            this.grpStep2.Name = "grpStep2";
            this.grpStep2.Size = new System.Drawing.Size(720, 134);
            this.grpStep2.TabIndex = 4;
            this.grpStep2.TabStop = false;
            this.grpStep2.Text = "Step 2: Determine Min / Max Values";
            // 
            // lblMaximum
            // 
            this.lblMaximum.AutoSize = true;
            this.lblMaximum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaximum.Location = new System.Drawing.Point(5, 90);
            this.lblMaximum.Name = "lblMaximum";
            this.lblMaximum.Size = new System.Drawing.Size(71, 13);
            this.lblMaximum.TabIndex = 5;
            this.lblMaximum.Text = "Maximum [us]";
            // 
            // txtMaximum
            // 
            this.txtMaximum.Enabled = false;
            this.txtMaximum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaximum.Location = new System.Drawing.Point(89, 87);
            this.txtMaximum.Name = "txtMaximum";
            this.txtMaximum.Size = new System.Drawing.Size(90, 20);
            this.txtMaximum.TabIndex = 4;
            this.txtMaximum.Text = "2300";
            this.txtMaximum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // trkMaximum
            // 
            this.trkMaximum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trkMaximum.Location = new System.Drawing.Point(185, 75);
            this.trkMaximum.Maximum = 2600;
            this.trkMaximum.Minimum = 50;
            this.trkMaximum.Name = "trkMaximum";
            this.trkMaximum.Size = new System.Drawing.Size(528, 45);
            this.trkMaximum.TabIndex = 3;
            this.trkMaximum.TickFrequency = 25;
            this.trkMaximum.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trkMaximum.Value = 2300;
            this.trkMaximum.ValueChanged += new System.EventHandler(this.trkMaximum_ValueChanged);
            // 
            // lblMinimum
            // 
            this.lblMinimum.AutoSize = true;
            this.lblMinimum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimum.Location = new System.Drawing.Point(5, 39);
            this.lblMinimum.Name = "lblMinimum";
            this.lblMinimum.Size = new System.Drawing.Size(68, 13);
            this.lblMinimum.TabIndex = 2;
            this.lblMinimum.Text = "Minimum [us]";
            // 
            // txtMinimum
            // 
            this.txtMinimum.Enabled = false;
            this.txtMinimum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinimum.Location = new System.Drawing.Point(89, 36);
            this.txtMinimum.Name = "txtMinimum";
            this.txtMinimum.Size = new System.Drawing.Size(90, 20);
            this.txtMinimum.TabIndex = 1;
            this.txtMinimum.Text = "800";
            this.txtMinimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // trkMinimum
            // 
            this.trkMinimum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trkMinimum.Location = new System.Drawing.Point(185, 24);
            this.trkMinimum.Maximum = 2600;
            this.trkMinimum.Minimum = 50;
            this.trkMinimum.Name = "trkMinimum";
            this.trkMinimum.Size = new System.Drawing.Size(528, 45);
            this.trkMinimum.TabIndex = 0;
            this.trkMinimum.TickFrequency = 25;
            this.trkMinimum.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trkMinimum.Value = 800;
            this.trkMinimum.ValueChanged += new System.EventHandler(this.trkMinimum_ValueChanged);
            // 
            // timUpdateProperties
            // 
            this.timUpdateProperties.Enabled = true;
            this.timUpdateProperties.Interval = 250;
            this.timUpdateProperties.Tick += new System.EventHandler(this.timUpdateProperties_Tick);
            // 
            // ServoConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 347);
            this.Controls.Add(this.grpStep1);
            this.Controls.Add(this.grpStep3);
            this.Controls.Add(this.grpStep2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "ServoConfigWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Servo Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServoConfigWindow_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ServoConfigWindow_KeyUp);
            this.grpStep1.ResumeLayout(false);
            this.grpStep1.PerformLayout();
            this.grpStep3.ResumeLayout(false);
            this.grpStep3.PerformLayout();
            this.grpStep2.ResumeLayout(false);
            this.grpStep2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkMaximum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkMinimum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpStep1;
        private System.Windows.Forms.Label lblPin;
        private System.Windows.Forms.Label lblBoard;
        private System.Windows.Forms.ComboBox cbxBoard;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox grpStep3;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Button cmdMeasure;
        private System.Windows.Forms.GroupBox grpStep2;
        private System.Windows.Forms.Label lblMaximum;
        private System.Windows.Forms.TextBox txtMaximum;
        private System.Windows.Forms.TrackBar trkMaximum;
        private System.Windows.Forms.Label lblMinimum;
        private System.Windows.Forms.TextBox txtMinimum;
        private System.Windows.Forms.TrackBar trkMinimum;
        private System.Windows.Forms.Timer timUpdateProperties;
        private System.Windows.Forms.ComboBox cbxPin;
    }
}
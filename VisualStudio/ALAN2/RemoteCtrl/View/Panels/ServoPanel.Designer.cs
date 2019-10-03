namespace RemoteCtrl {
    partial class ServoPanel {
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
            CommonCtrl.Vector2 vector21 = new CommonCtrl.Vector2();
            this.pnlServoComponents = new System.Windows.Forms.Panel();
            this.cbxServoUpdateInterval = new System.Windows.Forms.ComboBox();
            this.lblServoUpdateInterval = new System.Windows.Forms.Label();
            this.chkAxisX = new System.Windows.Forms.CheckedListBox();
            this.chkAxisY = new System.Windows.Forms.CheckedListBox();
            this.lblAxisX = new System.Windows.Forms.Label();
            this.lblAxisY = new System.Windows.Forms.Label();
            this.lblRotation = new System.Windows.Forms.Label();
            this.txtRotation = new System.Windows.Forms.TextBox();
            this.pnlServoControl = new RemoteCtrl.ServoControlView();
            this.lblReversed = new System.Windows.Forms.Label();
            this.chkReversed = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // pnlServoComponents
            // 
            this.pnlServoComponents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlServoComponents.AutoScroll = true;
            this.pnlServoComponents.Location = new System.Drawing.Point(3, 3);
            this.pnlServoComponents.Name = "pnlServoComponents";
            this.pnlServoComponents.Size = new System.Drawing.Size(447, 386);
            this.pnlServoComponents.TabIndex = 4;
            // 
            // cbxServoUpdateInterval
            // 
            this.cbxServoUpdateInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxServoUpdateInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServoUpdateInterval.FormattingEnabled = true;
            this.cbxServoUpdateInterval.Items.AddRange(new object[] {
            "20",
            "50",
            "100",
            "250",
            "500",
            "1000",
            "1500",
            "2000",
            "2500",
            "5000"});
            this.cbxServoUpdateInterval.Location = new System.Drawing.Point(692, 476);
            this.cbxServoUpdateInterval.Name = "cbxServoUpdateInterval";
            this.cbxServoUpdateInterval.Size = new System.Drawing.Size(150, 21);
            this.cbxServoUpdateInterval.TabIndex = 6;
            this.cbxServoUpdateInterval.SelectedValueChanged += new System.EventHandler(this.cbxServoUpdateInterval_SelectedValueChanged);
            // 
            // lblServoUpdateInterval
            // 
            this.lblServoUpdateInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServoUpdateInterval.AutoSize = true;
            this.lblServoUpdateInterval.Location = new System.Drawing.Point(689, 460);
            this.lblServoUpdateInterval.Name = "lblServoUpdateInterval";
            this.lblServoUpdateInterval.Size = new System.Drawing.Size(133, 13);
            this.lblServoUpdateInterval.TabIndex = 7;
            this.lblServoUpdateInterval.Text = "Servo Update Interval [ms]";
            // 
            // chkAxisX
            // 
            this.chkAxisX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAxisX.FormattingEnabled = true;
            this.chkAxisX.Location = new System.Drawing.Point(6, 418);
            this.chkAxisX.Name = "chkAxisX";
            this.chkAxisX.Size = new System.Drawing.Size(180, 79);
            this.chkAxisX.TabIndex = 9;
            this.chkAxisX.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkAxisX_ItemCheck);
            // 
            // chkAxisY
            // 
            this.chkAxisY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAxisY.FormattingEnabled = true;
            this.chkAxisY.Location = new System.Drawing.Point(192, 418);
            this.chkAxisY.Name = "chkAxisY";
            this.chkAxisY.Size = new System.Drawing.Size(180, 79);
            this.chkAxisY.TabIndex = 10;
            this.chkAxisY.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkAxisY_ItemCheck);
            // 
            // lblAxisX
            // 
            this.lblAxisX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAxisX.AutoSize = true;
            this.lblAxisX.Location = new System.Drawing.Point(3, 402);
            this.lblAxisX.Name = "lblAxisX";
            this.lblAxisX.Size = new System.Drawing.Size(72, 13);
            this.lblAxisX.TabIndex = 11;
            this.lblAxisX.Text = "Servos X-Axis";
            // 
            // lblAxisY
            // 
            this.lblAxisY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAxisY.AutoSize = true;
            this.lblAxisY.Location = new System.Drawing.Point(189, 402);
            this.lblAxisY.Name = "lblAxisY";
            this.lblAxisY.Size = new System.Drawing.Size(72, 13);
            this.lblAxisY.TabIndex = 12;
            this.lblAxisY.Text = "Servos Y-Axis";
            // 
            // lblRotation
            // 
            this.lblRotation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRotation.AutoSize = true;
            this.lblRotation.Location = new System.Drawing.Point(689, 402);
            this.lblRotation.Name = "lblRotation";
            this.lblRotation.Size = new System.Drawing.Size(86, 13);
            this.lblRotation.TabIndex = 13;
            this.lblRotation.Text = "View Rotation [°]";
            // 
            // txtRotation
            // 
            this.txtRotation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRotation.Location = new System.Drawing.Point(692, 418);
            this.txtRotation.Name = "txtRotation";
            this.txtRotation.Size = new System.Drawing.Size(150, 20);
            this.txtRotation.TabIndex = 14;
            this.txtRotation.Text = "0";
            this.txtRotation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRotation.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRotation_KeyUp);
            this.txtRotation.Leave += new System.EventHandler(this.txtRotation_Leave);
            // 
            // pnlServoControl
            // 
            this.pnlServoControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlServoControl.BackColor = System.Drawing.Color.White;
            this.pnlServoControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlServoControl.Interval = 50;
            this.pnlServoControl.Location = new System.Drawing.Point(456, 3);
            this.pnlServoControl.Name = "pnlServoControl";
            vector21.X = 0F;
            vector21.Y = 0F;
            this.pnlServoControl.Position = vector21;
            this.pnlServoControl.Rotation = 0F;
            this.pnlServoControl.Size = new System.Drawing.Size(386, 386);
            this.pnlServoControl.TabIndex = 8;
            // 
            // lblReversed
            // 
            this.lblReversed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReversed.AutoSize = true;
            this.lblReversed.Location = new System.Drawing.Point(375, 402);
            this.lblReversed.Name = "lblReversed";
            this.lblReversed.Size = new System.Drawing.Size(89, 13);
            this.lblReversed.TabIndex = 16;
            this.lblReversed.Text = "Servos Reversed";
            // 
            // chkReversed
            // 
            this.chkReversed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkReversed.FormattingEnabled = true;
            this.chkReversed.Location = new System.Drawing.Point(378, 418);
            this.chkReversed.Name = "chkReversed";
            this.chkReversed.Size = new System.Drawing.Size(180, 79);
            this.chkReversed.TabIndex = 15;
            this.chkReversed.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkReversed_ItemCheck);
            // 
            // ServoPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblReversed);
            this.Controls.Add(this.chkReversed);
            this.Controls.Add(this.txtRotation);
            this.Controls.Add(this.lblRotation);
            this.Controls.Add(this.lblAxisY);
            this.Controls.Add(this.lblAxisX);
            this.Controls.Add(this.chkAxisY);
            this.Controls.Add(this.chkAxisX);
            this.Controls.Add(this.pnlServoControl);
            this.Controls.Add(this.lblServoUpdateInterval);
            this.Controls.Add(this.cbxServoUpdateInterval);
            this.Controls.Add(this.pnlServoComponents);
            this.MinimumSize = new System.Drawing.Size(846, 504);
            this.Name = "ServoPanel";
            this.Size = new System.Drawing.Size(846, 504);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlServoComponents;
        private System.Windows.Forms.ComboBox cbxServoUpdateInterval;
        private System.Windows.Forms.Label lblServoUpdateInterval;
        private ServoControlView pnlServoControl;
        private System.Windows.Forms.CheckedListBox chkAxisX;
        private System.Windows.Forms.CheckedListBox chkAxisY;
        private System.Windows.Forms.Label lblAxisX;
        private System.Windows.Forms.Label lblAxisY;
        private System.Windows.Forms.Label lblRotation;
        private System.Windows.Forms.TextBox txtRotation;
        private System.Windows.Forms.Label lblReversed;
        private System.Windows.Forms.CheckedListBox chkReversed;
    }
}

namespace RemoteCtrl {
    partial class ServoControl {
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
            this.trkPosition = new System.Windows.Forms.TrackBar();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.grpServoComponent = new System.Windows.Forms.GroupBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblMaximum = new System.Windows.Forms.Label();
            this.lblMinimum = new System.Windows.Forms.Label();
            this.lblRange = new System.Windows.Forms.Label();
            this.lblBoard = new System.Windows.Forms.Label();
            this.lblPin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trkPosition)).BeginInit();
            this.grpServoComponent.SuspendLayout();
            this.SuspendLayout();
            // 
            // trkPosition
            // 
            this.trkPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trkPosition.Location = new System.Drawing.Point(6, 19);
            this.trkPosition.Maximum = 100;
            this.trkPosition.Name = "trkPosition";
            this.trkPosition.Size = new System.Drawing.Size(413, 45);
            this.trkPosition.TabIndex = 1;
            this.trkPosition.TickFrequency = 5;
            this.trkPosition.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trkPosition.Value = 50;
            this.trkPosition.Scroll += new System.EventHandler(this.trkPosition_Scroll);
            this.trkPosition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trkPosition_KeyDown);
            this.trkPosition.KeyUp += new System.Windows.Forms.KeyEventHandler(this.trkPosition_KeyUp);
            this.trkPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trkPosition_MouseDown);
            this.trkPosition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trkPosition_MouseUp);
            // 
            // lblPosition
            // 
            this.lblPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(12, 67);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(98, 13);
            this.lblPosition.TabIndex = 7;
            this.lblPosition.Text = "Current Position [%]";
            // 
            // txtPosition
            // 
            this.txtPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPosition.Location = new System.Drawing.Point(15, 83);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(92, 20);
            this.txtPosition.TabIndex = 6;
            this.txtPosition.Text = "50";
            this.txtPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPosition.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPosition_KeyUp);
            // 
            // grpServoComponent
            // 
            this.grpServoComponent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpServoComponent.Controls.Add(this.lblTime);
            this.grpServoComponent.Controls.Add(this.lblMaximum);
            this.grpServoComponent.Controls.Add(this.lblMinimum);
            this.grpServoComponent.Controls.Add(this.lblRange);
            this.grpServoComponent.Controls.Add(this.lblBoard);
            this.grpServoComponent.Controls.Add(this.lblPin);
            this.grpServoComponent.Controls.Add(this.trkPosition);
            this.grpServoComponent.Controls.Add(this.lblPosition);
            this.grpServoComponent.Controls.Add(this.txtPosition);
            this.grpServoComponent.Location = new System.Drawing.Point(3, 3);
            this.grpServoComponent.Name = "grpServoComponent";
            this.grpServoComponent.Size = new System.Drawing.Size(424, 122);
            this.grpServoComponent.TabIndex = 8;
            this.grpServoComponent.TabStop = false;
            this.grpServoComponent.Text = "<Servo Name>";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(335, 83);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(76, 13);
            this.lblTime.TabIndex = 13;
            this.lblTime.Text = "Time: 400 [ms]";
            // 
            // lblMaximum
            // 
            this.lblMaximum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaximum.AutoSize = true;
            this.lblMaximum.Location = new System.Drawing.Point(335, 99);
            this.lblMaximum.Name = "lblMaximum";
            this.lblMaximum.Size = new System.Drawing.Size(77, 13);
            this.lblMaximum.TabIndex = 12;
            this.lblMaximum.Text = "Max: 2300 [us]";
            // 
            // lblMinimum
            // 
            this.lblMinimum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinimum.AutoSize = true;
            this.lblMinimum.Location = new System.Drawing.Point(244, 99);
            this.lblMinimum.Name = "lblMinimum";
            this.lblMinimum.Size = new System.Drawing.Size(68, 13);
            this.lblMinimum.TabIndex = 11;
            this.lblMinimum.Text = "Min: 800 [us]";
            // 
            // lblRange
            // 
            this.lblRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRange.AutoSize = true;
            this.lblRange.Location = new System.Drawing.Point(244, 83);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(89, 13);
            this.lblRange.TabIndex = 10;
            this.lblRange.Text = "Range: [0, 100]%";
            // 
            // lblBoard
            // 
            this.lblBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBoard.AutoSize = true;
            this.lblBoard.Location = new System.Drawing.Point(244, 67);
            this.lblBoard.Name = "lblBoard";
            this.lblBoard.Size = new System.Drawing.Size(64, 13);
            this.lblBoard.TabIndex = 9;
            this.lblBoard.Text = "Board: 0x20";
            // 
            // lblPin
            // 
            this.lblPin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPin.AutoSize = true;
            this.lblPin.Location = new System.Drawing.Point(335, 67);
            this.lblPin.Name = "lblPin";
            this.lblPin.Size = new System.Drawing.Size(34, 13);
            this.lblPin.TabIndex = 8;
            this.lblPin.Text = "Pin: 0";
            // 
            // ServoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpServoComponent);
            this.Name = "ServoControl";
            this.Size = new System.Drawing.Size(430, 127);
            ((System.ComponentModel.ISupportInitialize)(this.trkPosition)).EndInit();
            this.grpServoComponent.ResumeLayout(false);
            this.grpServoComponent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar trkPosition;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.GroupBox grpServoComponent;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblMaximum;
        private System.Windows.Forms.Label lblMinimum;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.Label lblBoard;
        private System.Windows.Forms.Label lblPin;
    }
}

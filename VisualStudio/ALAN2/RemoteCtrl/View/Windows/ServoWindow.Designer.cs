namespace RemoteCtrl {
    partial class ServoWindow {
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
            CommonCtrl.Vector2 vector21 = new CommonCtrl.Vector2();
            this.pnlServoControl = new RemoteCtrl.ServoControlView();
            this.SuspendLayout();
            // 
            // pnlServoControl
            // 
            this.pnlServoControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlServoControl.BackColor = System.Drawing.Color.White;
            this.pnlServoControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlServoControl.Interval = 50;
            this.pnlServoControl.Location = new System.Drawing.Point(0, 0);
            this.pnlServoControl.Name = "pnlServoControl";
            vector21.X = 0F;
            vector21.Y = 0F;
            this.pnlServoControl.Position = vector21;
            this.pnlServoControl.Rotation = 0F;
            this.pnlServoControl.Size = new System.Drawing.Size(386, 386);
            this.pnlServoControl.TabIndex = 0;
            // 
            // ServoWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 386);
            this.Controls.Add(this.pnlServoControl);
            this.Name = "ServoWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Servo Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServoWindow_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private ServoControlView pnlServoControl;
    }
}
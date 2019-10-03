namespace RemoteCtrl {
    partial class TimeLineControl {
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
            this.SuspendLayout();
            // 
            // TimeLineControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.DoubleBuffered = true;
            this.Name = "TimeLineControl";
            this.Size = new System.Drawing.Size(10000, 381);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TimeLineControl_Scroll);
            this.SizeChanged += new System.EventHandler(this.TimeLineControl_Update);
            this.VisibleChanged += new System.EventHandler(this.TimeLineControl_Update);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TimeLineControl_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TimeLineControl_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TimeLineControl_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TimeLineControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TimeLineControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TimeLineControl_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

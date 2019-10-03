namespace RemoteCtrl {
    partial class SensorLogbookView {
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
            // SensorLogbookView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Name = "SensorLogbookView";
            this.Size = new System.Drawing.Size(4096, 402);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SensorLogbookView_Scroll);
            this.SizeChanged += new System.EventHandler(this.SensorLogbookView_Update);
            this.VisibleChanged += new System.EventHandler(this.SensorLogbookView_Update);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SensorLogbookView_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SensorLogbookView_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

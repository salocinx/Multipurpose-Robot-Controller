namespace RemoteCtrl {
    partial class CameraWindow {
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
            this.imgNetworkStreamImage = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgNetworkStreamImage)).BeginInit();
            this.SuspendLayout();
            // 
            // imgNetworkStreamImage
            // 
            this.imgNetworkStreamImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgNetworkStreamImage.ErrorImage = global::RemoteCtrl.Properties.Resources.no_cam_connected;
            this.imgNetworkStreamImage.InitialImage = global::RemoteCtrl.Properties.Resources.no_cam_connected;
            this.imgNetworkStreamImage.Location = new System.Drawing.Point(0, 0);
            this.imgNetworkStreamImage.Name = "imgNetworkStreamImage";
            this.imgNetworkStreamImage.Size = new System.Drawing.Size(640, 480);
            this.imgNetworkStreamImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgNetworkStreamImage.TabIndex = 3;
            this.imgNetworkStreamImage.TabStop = false;
            // 
            // CameraWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.imgNetworkStreamImage);
            this.Name = "CameraWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Camera";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CameraWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.imgNetworkStreamImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox imgNetworkStreamImage;
    }
}
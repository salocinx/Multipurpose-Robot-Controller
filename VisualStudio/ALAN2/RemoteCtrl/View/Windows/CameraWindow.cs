
#region Usings
using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Windows.Forms;
#endregion

namespace RemoteCtrl {

    public partial class CameraWindow : Form {

        private CameraPanel parent;

        private int cwidth = 640;
        private int cheight = 480;

        public CameraWindow(CameraPanel parent) {
            this.parent = parent;
            InitializeComponent();
        }

        private void CameraWindow_FormClosing(object sender, FormClosingEventArgs evt) {
            if(evt.CloseReason == CloseReason.UserClosing) {
                evt.Cancel = true;
                Hide();
            }
        }

        public void updateImage(Image<Bgr, byte> image, int width, int height) {
            if(cwidth!=width || cheight!=height) {
                ClientSize = new Size(width, height);
                cwidth = width;
                cheight = height;
            }
            imgNetworkStreamImage.Image = image;
        }

    }
}

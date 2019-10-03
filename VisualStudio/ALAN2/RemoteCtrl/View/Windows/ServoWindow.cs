
#region Usings
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace RemoteCtrl {

    public partial class ServoWindow : Form {

        private ServoPanel parent;

        public ServoWindow(ServoPanel parent) {
            this.parent = parent;
            InitializeComponent();
        }

        public ServoControlView ServoControlPanel {
            get { return pnlServoControl; }
        }

        private void ServoWindow_FormClosing(object sender, FormClosingEventArgs evt) {
            if(evt.CloseReason == CloseReason.UserClosing) {
                parent.ServoControlPanel.Enabled = true;
                evt.Cancel = true;
                Hide();
            }
        }

    }
}


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
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public partial class GpsConfigWindow : Form {

        #region Fields
        private Agent agent;
        private GPS gps;
        #endregion

        #region Lifecycle
        public GpsConfigWindow(Agent agent, GPS gps) {
            this.agent = agent;
            this.gps = gps;
            InitializeComponent();
            initializeGui();
            agent.registerWindow(this);
        }

        private void initializeGui() {
            txtName.Text = gps.Name;
            txtReadInterval.Text = gps.ReadInterval.ToString();
            #region Setup Serial Combobox
            cbxPin.SelectedIndex = 1;
            #endregion
        }
        #endregion

        #region Functions
        private bool updateModel(bool show) {
            bool success = false;
            #region Validated Fields
            uint uint_result;
            if(txtName.Text.Length<=64) {
                gps.Name = txtName.Text;
                if(uint.TryParse(txtReadInterval.Text, out uint_result)) {
                    gps.ReadInterval = uint_result;
                    success = true;
                }
            }
            if(!success && show) {
                Validation.show();
            }
            #endregion
            return success;
        }

        private void sendComponentUpdate() {
            UpdateComponent update = new UpdateComponent(gps.Id);
            update.Component = gps;
            agent.TcpNetworkClient.send(update);
        }
        #endregion

        #region Event-Handling
        private void GpsConfigWindow_FormClosing(object sender, FormClosingEventArgs evt) {
            if(evt.CloseReason == CloseReason.UserClosing) {
                if(updateModel(true)) {
                    sendComponentUpdate();
                    agent.doLocalUpdate(gps);
                } else {
                    evt.Cancel = true;
                }
            } else {
                if(updateModel(false)) {
                    sendComponentUpdate();
                }
            }
        }
        #endregion

    }

}

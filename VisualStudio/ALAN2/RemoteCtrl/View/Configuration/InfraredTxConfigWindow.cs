
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

    public partial class InfraredTxConfigWindow : Form {

        #region Fields
        private Agent agent;
        private InfraredTx infrared;
        #endregion

        #region Lifecycle
        public InfraredTxConfigWindow(Agent agent, InfraredTx infrared) {
            this.agent = agent;
            this.infrared = infrared;
            InitializeComponent();
            initializeGui();
            agent.registerWindow(this);
        }

        private void initializeGui() {
            txtName.Text = infrared.Name;
            #region Setup Pin Combobox
            int index = -1;
            for(int i = 0; i<agent.Arduino.DigitalPins.Count; i++) {
                int cpin = agent.Arduino.DigitalPins[i];
                cbxPin.Items.Add("            "+cpin);
                if(cpin==infrared.Pin) index=i;
            }
            if(index>=0) {
                cbxPin.SelectedIndex = index;
            }
            #endregion
            #region Setup Protocol Combobox
            cbxProtocol.SelectedIndex = 0;
            #endregion
        }
        #endregion

        #region Functions
        private bool updateModel(bool show) {
            bool success = false;
            #region Validated Fields
            if(txtName.Text.Length<=64) {
                infrared.Name = txtName.Text;
                success = true;
            }
            if(!success && show) {
                Validation.show();
            }
            #endregion
            #region Non-Validated Fields
            infrared.Name = txtName.Text;
            #endregion
            return success;
        }

        private void sendComponentUpdate() {
            UpdateComponent update = new UpdateComponent(infrared.Id);
            update.Component = infrared;
            agent.TcpNetworkClient.send(update);
        }
        #endregion

        #region Event-Handling
        private void InfraredTxConfigWindow_FormClosing(object sender, FormClosingEventArgs evt) {
            if(evt.CloseReason == CloseReason.UserClosing) {
                if(updateModel(true)) {
                    sendComponentUpdate();
                    agent.doLocalUpdate(infrared);
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

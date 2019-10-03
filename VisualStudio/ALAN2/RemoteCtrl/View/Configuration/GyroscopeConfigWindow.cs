
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

    public partial class GyroscopeConfigWindow : Form {

        #region Fields
        private Agent agent;
        private Gyroscope gyroscope;
        #endregion

        #region Lifecycle
        public GyroscopeConfigWindow(Agent agent, Gyroscope gyroscope) {
            this.agent = agent;
            this.gyroscope = gyroscope;
            InitializeComponent();
            initializeGui();
            agent.registerWindow(this);
        }

        private void initializeGui() {
            txtName.Text = gyroscope.Name;
            txtReadInterval.Text = gyroscope.ReadInterval.ToString();
            #region Setup Address Combobox
            cbxAddress.Items.Add(Toolkit.toHexFormat(gyroscope.Address));
            cbxAddress.SelectedIndex = 0;
            #endregion
            #region Setup Scale Comboboxes
            cbxGyroscopeScale.SelectedIndex = 3;
            cbxAccelerometerScale.SelectedIndex = 3;
            #endregion
        }
        #endregion

        #region Functions
        private bool updateModel(bool show) {
            bool success = false;
            #region Validated Fields
            uint uint_result;
            if(txtName.Text.Length<=64) {
                gyroscope.Name = txtName.Text;
                if(uint.TryParse(txtReadInterval.Text, out uint_result)) {
                    gyroscope.ReadInterval = uint_result;
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
            UpdateComponent update = new UpdateComponent(gyroscope.Id);
            update.Component = gyroscope;
            agent.TcpNetworkClient.send(update);
        }
        #endregion

        #region Event-Handling
        private void GyroscopeConfigWindow_FormClosing(object sender, FormClosingEventArgs evt) {
            if(evt.CloseReason == CloseReason.UserClosing) {
                if(updateModel(true)) {
                    sendComponentUpdate();
                    agent.doLocalUpdate(gyroscope);
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


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

    public partial class PhotoresistorConfigWindow : Form {

        #region Fields
        private Agent agent;
        private Photoresistor photoresistor;
        #endregion

        #region Lifecycle
        public PhotoresistorConfigWindow(Agent agent, Photoresistor photoresistor) {
            this.agent = agent;
            this.photoresistor = photoresistor;
            InitializeComponent();
            this.initializeGui();
            agent.registerWindow(this);
        }

        private void initializeGui() {
            txtName.Text = photoresistor.Name;
            txtMinimum.Text = photoresistor.Minimum.ToString("0.0");
            txtMaximum.Text = photoresistor.Maximum.ToString("0.0");
            txtPostfix.Text = photoresistor.Postfix;
            txtReadInterval.Text = photoresistor.ReadInterval.ToString();
            boxLogging.Checked = photoresistor.Logging;
            txtLogCapacity.Text = photoresistor.LogCapacity.ToString();
            txtLogInterval.Text = photoresistor.LogInterval.ToString();
            txtSlope.Text = photoresistor.Slope.ToString();
            txtIntercept.Text = photoresistor.Intercept.ToString();
            #region Setup Pin Combobox
            int index = -1;
            for(int i=0; i<agent.Arduino.AnalogPins.Count; i++) {
                int cpin = agent.Arduino.AnalogPins[i];
                cbxPin.Items.Add("            "+cpin);
                if(cpin==photoresistor.Pin) index=i;
            }
            if(index>=0) {
                cbxPin.SelectedIndex = index;
            }
            #endregion
        }
        #endregion

        #region Functions
        private bool updateModel(bool show) {
            bool success = false;
            #region Validated Fields
            uint uint_result;
            float float_result;
            if(txtName.Text.Length<=64) {
                photoresistor.Name = txtName.Text;
                if(float.TryParse(txtMinimum.Text, out float_result)) {
                    photoresistor.Minimum = float_result;
                    if(float.TryParse(txtMaximum.Text, out float_result)) {
                        photoresistor.Maximum = float_result;
                        if(txtPostfix.Text.Length<=8) {
                            photoresistor.Postfix = txtPostfix.Text;
                            if(uint.TryParse(txtReadInterval.Text, out uint_result)) {
                                photoresistor.ReadInterval = uint_result;
                                if(uint.TryParse(txtLogCapacity.Text, out uint_result)) {
                                    photoresistor.LogCapacity = uint_result;
                                    if(uint.TryParse(txtLogInterval.Text, out uint_result)) {
                                        photoresistor.LogInterval = uint_result;
                                        if(float.TryParse(txtSlope.Text, out float_result)) {
                                            photoresistor.Slope = float_result;
                                            if(float.TryParse(txtIntercept.Text, out float_result)) {
                                                photoresistor.Intercept = float_result;
                                                success = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if(!success && show) {
                Validation.show();
            }
            #endregion
            #region Non-Validated Fields
            photoresistor.Logging = boxLogging.Checked;
            #endregion
            return success;
        }

        private void sendComponentUpdate() {
            UpdateComponent update = new UpdateComponent(photoresistor.Id);
            update.Component = photoresistor;
            agent.TcpNetworkClient.send(update);
        }
        #endregion

        #region Event-Handling
        private void cbxPin_SelectedValueChanged(object sender, EventArgs evt) {
            if(cbxPin.SelectedItem!=null) {
                photoresistor.Pin = ushort.Parse(((String)cbxPin.SelectedItem).Trim());
            }
        }

        private void PhotoresistorConfigWindow_FormClosing(object sender, FormClosingEventArgs evt) {
            if(evt.CloseReason == CloseReason.UserClosing) {
                if(updateModel(true)) {
                    sendComponentUpdate();
                    agent.doLocalUpdate(photoresistor);
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

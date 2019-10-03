
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

    public partial class ThermistorConfigWindow : Form {

        #region Fields
        private Agent agent;
        private Thermistor thermistor;
        #endregion

        #region Lifecycle
        public ThermistorConfigWindow(Agent agent, Thermistor thermistor) {
            this.agent = agent;
            this.thermistor = thermistor;
            InitializeComponent();
            this.initializeGui();
            agent.registerWindow(this);
        }

        private void initializeGui() {
            txtName.Text = thermistor.Name;
            txtMinimum.Text = thermistor.Minimum.ToString("0.0");
            txtMaximum.Text = thermistor.Maximum.ToString("0.0");
            txtPostfix.Text = thermistor.Postfix;
            txtReadInterval.Text = thermistor.ReadInterval.ToString();
            boxLogging.Checked = thermistor.Logging;
            txtLogCapacity.Text = thermistor.LogCapacity.ToString();
            txtLogInterval.Text = thermistor.LogInterval.ToString();
            txtNominal1.Text = thermistor.Slope.ToString();
            txtBetaCoefficient.Text = thermistor.Intercept.ToString();
            #region Setup Pin Combobox
            int index = -1;
            for(int i = 0; i<agent.Arduino.AnalogPins.Count; i++) {
                int cpin = agent.Arduino.AnalogPins[i];
                cbxPin.Items.Add("            "+cpin);
                if(cpin==thermistor.Pin) index=i;
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
                thermistor.Name = txtName.Text;
                if(float.TryParse(txtMinimum.Text, out float_result)) {
                    thermistor.Minimum = float_result;
                    if(float.TryParse(txtMaximum.Text, out float_result)) {
                        thermistor.Maximum = float_result;
                        if(txtPostfix.Text.Length<=8) {
                            thermistor.Postfix = txtPostfix.Text;
                            if(uint.TryParse(txtReadInterval.Text, out uint_result)) {
                                thermistor.ReadInterval = uint_result;
                                if(uint.TryParse(txtLogCapacity.Text, out uint_result)) {
                                    thermistor.LogCapacity = uint_result;
                                    if(uint.TryParse(txtLogInterval.Text, out uint_result)) {
                                        thermistor.LogInterval = uint_result;
                                        if(float.TryParse(txtNominal1.Text, out float_result)) {
                                            thermistor.Slope = float_result;
                                            if(float.TryParse(txtBetaCoefficient.Text, out float_result)) {
                                                thermistor.Intercept = float_result;
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
            thermistor.Name = txtName.Text;
            thermistor.Logging = boxLogging.Checked;
            #endregion
            return success;
        }

        private void sendComponentUpdate() {
            UpdateComponent update = new UpdateComponent(thermistor.Id);
            update.Component = thermistor;
            agent.TcpNetworkClient.send(update);
        }
        #endregion

        #region Event-Handling
        private void cbxPin_SelectedValueChanged(object sender, EventArgs evt) {
            if(cbxPin.SelectedItem!=null) {
                thermistor.Pin = ushort.Parse(((String)cbxPin.SelectedItem).Trim());
            }
        }

        private void ThermistorConfigWindow_FormClosing(object sender, FormClosingEventArgs evt) {
            if(evt.CloseReason == CloseReason.UserClosing) {
                if(updateModel(true)) {
                    sendComponentUpdate();
                    agent.doLocalUpdate(thermistor);
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

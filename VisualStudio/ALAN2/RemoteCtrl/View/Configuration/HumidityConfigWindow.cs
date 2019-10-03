
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

    public partial class HumidityConfigWindow : Form {

        #region Fields
        private Agent agent;
        private Humidity humidity;
        #endregion

        #region Lifecycle
        public HumidityConfigWindow(Agent agent, Humidity humidity) {
            this.agent = agent;
            this.humidity = humidity;
            InitializeComponent();
            this.initializeGui();
            agent.registerWindow(this);
        }

        private void initializeGui() {
            txtName.Text = humidity.Name;
            txtMinimum.Text = humidity.Minimum.ToString("0.0");
            txtMaximum.Text = humidity.Maximum.ToString("0.0");
            txtPostfix.Text = humidity.Postfix;
            txtReadInterval.Text = humidity.ReadInterval.ToString();
            boxLogging.Checked = humidity.Logging;
            txtLogCapacity.Text = humidity.LogCapacity.ToString();
            txtLogInterval.Text = humidity.LogInterval.ToString();
            txtSlope.Text = humidity.Slope.ToString();
            txtIntercept.Text = humidity.Intercept.ToString();
            #region Setup Pin Combobox
            int index = -1;
            for(int i = 0; i<agent.Arduino.DigitalPins.Count; i++) {
                int cpin = agent.Arduino.DigitalPins[i];
                cbxPin.Items.Add("            "+cpin);
                if(cpin==humidity.Pin) index=i;
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
                humidity.Name = txtName.Text;
                if(float.TryParse(txtMinimum.Text, out float_result)) {
                    humidity.Minimum = float_result;
                    if(float.TryParse(txtMaximum.Text, out float_result)) {
                        humidity.Maximum = float_result;
                        if(txtPostfix.Text.Length<=8) {
                            humidity.Postfix = txtPostfix.Text;
                            if(uint.TryParse(txtReadInterval.Text, out uint_result)) {
                                humidity.ReadInterval = uint_result;
                                if(uint.TryParse(txtLogCapacity.Text, out uint_result)) {
                                    humidity.LogCapacity = uint_result;
                                    if(uint.TryParse(txtLogInterval.Text, out uint_result)) {
                                        humidity.LogInterval = uint_result;
                                        if(float.TryParse(txtSlope.Text, out float_result)) {
                                            humidity.Slope = float_result;
                                            if(float.TryParse(txtIntercept.Text, out float_result)) {
                                                humidity.Intercept = float_result;
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
            humidity.Name = txtName.Text;
            humidity.Logging = boxLogging.Checked;
            #endregion
            return success;
        }

        private void sendComponentUpdate() {
            UpdateComponent update = new UpdateComponent(humidity.Id);
            update.Component = humidity;
            agent.TcpNetworkClient.send(update);
        }
        #endregion

        #region Event-Handling
        private void cbxPin_SelectedValueChanged(object sender, EventArgs evt) {
            if(cbxPin.SelectedItem!=null) {
                humidity.Pin = ushort.Parse(((String)cbxPin.SelectedItem).Trim());
            }
        }

        private void HumidityConfigWindow_FormClosing(object sender, FormClosingEventArgs evt) {
            if(evt.CloseReason == CloseReason.UserClosing) {
                if(updateModel(true)) {
                    sendComponentUpdate();
                    agent.doLocalUpdate(humidity);
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


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

    public partial class BatteryConfigWindow : Form {

        #region Fields
        private Agent agent;
        private Battery battery;
        #endregion

        #region Lifecycle
        public BatteryConfigWindow(Agent agent, Battery battery) {
            this.agent = agent;
            this.battery = battery;
            InitializeComponent();
            this.initializeGui();
            agent.registerWindow(this);
        }

        private void initializeGui() {
            txtName.Text = battery.Name;
            txtMinimumVoltage.Text = battery.Minimum.ToString("0.0");
            txtMaximumVoltage.Text = battery.Maximum.ToString("0.0");
            txtCriticalVoltage.Text = battery.CriticalVoltage.ToString("0.0");
            txtPostfix.Text = battery.Postfix;
            txtReadInterval.Text = battery.ReadInterval.ToString();
            boxCharging.Checked = battery.Charging;
            txtBatteryL0.Text = "0";
            txtBatteryL1.Text = battery.State[0].ToString();
            txtBatteryL2.Text = battery.State[1].ToString();
            txtBatteryL3.Text = battery.State[2].ToString();
            txtBatteryL4.Text = battery.State[3].ToString();
            txtBatteryL5.Text = battery.State[4].ToString();
            boxLogging.Checked = battery.Logging;
            txtLogCapacity.Text = battery.LogCapacity.ToString();
            txtLogInterval.Text = battery.LogInterval.ToString();
            txtSlope.Text = battery.Slope.ToString();
            txtIntercept.Text = battery.Intercept.ToString();
            #region Setup Pin Combobox
            int index = -1;
            for(int i = 0; i<agent.Arduino.AnalogPins.Count; i++) {
                int cpin = agent.Arduino.AnalogPins[i];
                cbxPin.Items.Add("            "+cpin);
                if(cpin==battery.Pin) index=i;
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
                battery.Name = txtName.Text;
                if(float.TryParse(txtMinimumVoltage.Text, out float_result)) {
                    battery.Minimum = float_result;
                    if(float.TryParse(txtMaximumVoltage.Text, out float_result)) {
                        battery.Maximum = float_result;
                        if(float.TryParse(txtCriticalVoltage.Text, out float_result)) {
                            battery.CriticalVoltage = float_result;
                            if(txtPostfix.Text.Length<=8) {
                                battery.Postfix = txtPostfix.Text;
                                if(uint.TryParse(txtReadInterval.Text, out uint_result)) {
                                    battery.ReadInterval = uint_result;
                                    if(float.TryParse(txtBatteryL1.Text, out float_result)) {
                                        battery.State[0] = float_result;
                                        if(float.TryParse(txtBatteryL2.Text, out float_result)) {
                                            battery.State[1] = float_result;
                                            if(float.TryParse(txtBatteryL3.Text, out float_result)) {
                                                battery.State[2] = float_result;
                                                if(float.TryParse(txtBatteryL4.Text, out float_result)) {
                                                    battery.State[3] = float_result;
                                                    if(float.TryParse(txtBatteryL5.Text, out float_result)) {
                                                        battery.State[4] = float_result;
                                                        if(uint.TryParse(txtLogCapacity.Text, out uint_result)) {
                                                            battery.LogCapacity = uint_result;
                                                            if(uint.TryParse(txtLogInterval.Text, out uint_result)) {
                                                                battery.LogInterval = uint_result;
                                                                if(float.TryParse(txtSlope.Text, out float_result)) {
                                                                    battery.Slope = float_result;
                                                                    if(float.TryParse(txtIntercept.Text, out float_result)) {
                                                                        battery.Intercept = float_result;
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
            battery.Name = txtName.Text;
            battery.Logging = boxLogging.Checked;
            #endregion
            return success;
        }

        private void sendComponentUpdate() {
            UpdateComponent update = new UpdateComponent(battery.Id);
            update.Component = battery;
            agent.TcpNetworkClient.send(update);
        }
        #endregion

        #region Event-Handling
        private void cbxPin_SelectedValueChanged(object sender, EventArgs evt) {
            if(cbxPin.SelectedItem!=null) {
                battery.Pin = ushort.Parse(((String)cbxPin.SelectedItem).Trim());
            }
        }

        private void BatteryConfigWindow_FormClosing(object sender, FormClosingEventArgs evt) {
            if(evt.CloseReason == CloseReason.UserClosing) {
                if(updateModel(true)) {
                    sendComponentUpdate();
                    agent.doLocalUpdate(battery);
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

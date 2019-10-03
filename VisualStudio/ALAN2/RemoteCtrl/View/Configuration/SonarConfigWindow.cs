
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

    public partial class SonarConfigWindow : Form {

        #region Fields
        private Agent agent;
        private Sonar sonar;
        #endregion

        #region Lifecycle
        public SonarConfigWindow(Agent agent, Sonar sonar) {
            this.agent = agent;
            this.sonar = sonar;
            InitializeComponent();
            this.initializeGui();
            agent.registerWindow(this);
        }

        private void initializeGui() {
            txtName.Text = sonar.Name;
            txtMinimum.Text = sonar.Minimum.ToString("0.0");
            txtMaximum.Text = sonar.Maximum.ToString("0.0");
            txtPostfix.Text = sonar.Postfix;
            txtReadInterval.Text = sonar.ReadInterval.ToString();
            boxLogging.Checked = sonar.Logging;
            txtLogCapacity.Text = sonar.LogCapacity.ToString();
            txtLogInterval.Text = sonar.LogInterval.ToString();
            txtSlope.Text = sonar.Slope.ToString();
            txtIntercept.Text = sonar.Intercept.ToString();
            #region Setup Trigger Pin Combobox
            int trigger_index = -1;
            for(int i = 0; i<agent.Arduino.DigitalPins.Count; i++) {
                int cpin = agent.Arduino.DigitalPins[i];
                cbxTriggerPin.Items.Add("            "+cpin);
                if(cpin==sonar.TriggerPin) trigger_index=i;
            }
            if(trigger_index>=0) {
                cbxTriggerPin.SelectedIndex = trigger_index;
            }
            #endregion
            #region Setup Echo Pin Combobox
            int echo_index = -1;
            for(int i = 0; i<agent.Arduino.DigitalPins.Count; i++) {
                int cpin = agent.Arduino.DigitalPins[i];
                cbxEchoPin.Items.Add("            "+cpin);
                if(cpin==sonar.EchoPin) echo_index=i;
            }
            if(echo_index>=0) {
                cbxEchoPin.SelectedIndex = echo_index;
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
                sonar.Name = txtName.Text;
                if(float.TryParse(txtMinimum.Text, out float_result)) {
                    sonar.Minimum = float_result;
                    if(float.TryParse(txtMaximum.Text, out float_result)) {
                        sonar.Maximum = float_result;
                        if(txtPostfix.Text.Length<=8) {
                            sonar.Postfix = txtPostfix.Text;
                            if(uint.TryParse(txtReadInterval.Text, out uint_result)) {
                                sonar.ReadInterval = uint_result;
                                if(uint.TryParse(txtLogCapacity.Text, out uint_result)) {
                                    sonar.LogCapacity = uint_result;
                                    if(uint.TryParse(txtLogInterval.Text, out uint_result)) {
                                        sonar.LogInterval = uint_result;
                                        if(float.TryParse(txtSlope.Text, out float_result)) {
                                            sonar.Slope = float_result;
                                            if(float.TryParse(txtIntercept.Text, out float_result)) {
                                                sonar.Intercept = float_result;
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
            sonar.Name = txtName.Text;
            sonar.Logging = boxLogging.Checked;
            #endregion
            return success;
        }

        private void sendComponentUpdate() {
            UpdateComponent update = new UpdateComponent(sonar.Id);
            update.Component = sonar;
            agent.TcpNetworkClient.send(update);
        }
        #endregion

        #region Event-Handling
        private void cbxTriggerPin_SelectedValueChanged(object sender, EventArgs evt) {
            if(cbxTriggerPin.SelectedItem!=null) {
                sonar.TriggerPin = ushort.Parse(((String)cbxTriggerPin.SelectedItem).Trim());
            }
        }

        private void cbxEchoPin_SelectedValueChanged(object sender, EventArgs evt) {
            if(cbxEchoPin.SelectedItem!=null) {
                sonar.EchoPin = ushort.Parse(((String)cbxEchoPin.SelectedItem).Trim());
            }
        }

        private void SonarConfigWindow_FormClosing(object sender, FormClosingEventArgs evt) {
            if(evt.CloseReason == CloseReason.UserClosing) {
                if(updateModel(true)) {
                    sendComponentUpdate();
                    agent.doLocalUpdate(sonar);
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

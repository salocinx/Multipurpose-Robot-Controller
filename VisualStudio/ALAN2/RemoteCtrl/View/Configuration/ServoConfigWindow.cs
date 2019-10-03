
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

    public partial class ServoConfigWindow : Form {

        #region Fields
        private Agent agent;
        private Servo servo;
        private MeasurementState cstate;

        private long tstart;
        private int prevMinimum;
        private int prevMaximum;
        #endregion

        #region Enumerations
        public enum MeasurementState {
            Reset, Start, Stop
        };
        #endregion

        #region Lifecycle
        public ServoConfigWindow(Agent agent, Servo servo) {
            this.agent = agent;
            this.servo = servo;
            InitializeComponent();
            this.initializeGui();
            agent.registerWindow(this);
        }

        private void initializeGui() {
            txtName.Text = servo.Name;
            trkMinimum.Value = servo.Minimum;
            prevMinimum = servo.Minimum;
            trkMaximum.Value = servo.Maximum;
            prevMaximum = servo.Maximum;
            txtTime.Text = servo.Time.ToString();
            #region Set Board Comboxbox
            // the board event triggers the pin combobox setup
            if(servo.Address == 0x40) {
                cbxBoard.SelectedIndex = 0;
            } else if(servo.Address == 0x41) {
                cbxBoard.SelectedIndex = 1;
            } else if(servo.Address == 0x42) {
                cbxBoard.SelectedIndex = 2;
            } else if(servo.Address == 0x43) {
                cbxBoard.SelectedIndex = 3;
            }
            #endregion
            setMeasurementState(MeasurementState.Reset);
        }
        #endregion

        #region Functions
        private void setMeasurementState(MeasurementState state) {
            switch(state) {
                case MeasurementState.Reset:
                    cmdMeasure.BackColor = Color.LightGray;
                    cmdMeasure.Text = "Reset Measurement [F12]";
                    break;
                case MeasurementState.Start:
                    cmdMeasure.BackColor = Color.YellowGreen;
                    cmdMeasure.Text = "Start Measurement [F12]";
                    break;
                case MeasurementState.Stop:
                    cmdMeasure.BackColor = Color.OrangeRed;
                    cmdMeasure.Text = "Stop Measurement [F12]";
                    break;
            }
            this.cstate = state;
        }

        private void sendComponentUpdate() {
            UpdateComponent update = new UpdateComponent(servo.Id);
            update.Component = servo;
            agent.TcpNetworkClient.send(update);
        }

        private void sendServoSignalChanged(ushort signal) {
            ServoPositionCommand cmd = new ServoPositionCommand(servo.Id);
            cmd.Pin = servo.Pin;
            cmd.Board = servo.Address;
            cmd.Signal = signal;
            agent.TcpNetworkClient.send(cmd);
        }

        private bool updateModel(bool show) {
            bool success = false;
            #region Validated Fields
            if(txtName.Text.Length<=64) {
                if(cbxBoard.SelectedItem!=null) {
                    if(cbxPin.SelectedItem!=null) {
                        success = true;
                    }
                }
            }
            if(!success && show) {
                Validation.show();
            }
            #endregion
            #region Non-Validated Fields
            servo.Name = txtName.Text;
            servo.Minimum = ushort.Parse(txtMinimum.Text);
            servo.Maximum = ushort.Parse(txtMaximum.Text);
            servo.Time = ushort.Parse(txtTime.Text);
            #endregion
            return success;
        }
        #endregion

        #region Event-Handling
        private void txtName_KeyUp(object sender, KeyEventArgs evt) {
            if(evt.KeyCode==Keys.Enter || evt.KeyCode==Keys.Return) {
                if(!txtName.Equals(servo.Name)) {
                    updateModel(true);
                }
            }
        }

        private void cbxPin_SelectedValueChanged(object sender, EventArgs evt) {
            if(cbxPin.SelectedItem!=null) {
                servo.Pin = ushort.Parse(((String)cbxPin.SelectedItem).Trim());
            }
        }

        private void boxControllerBoardType_SelectedValueChanged(object sender, EventArgs evt) {
            if(cbxBoard.SelectedItem!=null) {
                if(cbxBoard.SelectedIndex==0) {
                    servo.Address = 0x40;
                } else if(cbxBoard.SelectedIndex==1) {
                    servo.Address = 0x41;
                } else if(cbxBoard.SelectedIndex==2) {
                    servo.Address = 0x42;
                } else if(cbxBoard.SelectedIndex==3) {
                    servo.Address = 0x43;
                }
                #region Setup Pin Combobox
                cbxPin.Items.Clear();
                int index = -1;
                if(servo.Address==0x20) {
                    for(int i=0; i<agent.Arduino.PwmPins.Count; i++) {
                        int cpin = agent.Arduino.PwmPins[i];
                        cbxPin.Items.Add("            "+cpin);
                        if(cpin==servo.Pin) index=i;
                    }
                } else {
                    for(int pin=0; pin<16; pin++) {
                        cbxPin.Items.Add("            "+pin);
                        if(pin==servo.Pin) index=pin;
                    }
                }
                if(index>=0) {
                    cbxPin.SelectedIndex = index;
                }
                #endregion
            }
        }

        private void trkMinimum_ValueChanged(object sender, EventArgs evt) {
            txtMinimum.Text = trkMinimum.Value.ToString();
        }

        private void trkMaximum_ValueChanged(object sender, EventArgs evt) {
            txtMaximum.Text = trkMaximum.Value.ToString();
        }

        private void ServoConfigWindow_KeyUp(object sender, KeyEventArgs evt) {
            if(evt.KeyCode==Keys.F12) {
                cmdMeasure_Click(sender, evt);
            }
        }

        private void cmdMeasure_Click(object sender, EventArgs evt) {
            if(cstate==MeasurementState.Reset) {
                sendServoSignalChanged(servo.Minimum);
                setMeasurementState(MeasurementState.Start);
            } else if(cstate==MeasurementState.Start) {
                sendServoSignalChanged(servo.Maximum);
                setMeasurementState(MeasurementState.Stop);
                tstart = Toolkit.CurrentTimeMillis();
            } else if(cstate==MeasurementState.Stop) {
                servo.Time = (ushort)(Toolkit.CurrentTimeMillis()-tstart);
                txtTime.Text = servo.Time.ToString();
                updateModel(false);
                setMeasurementState(MeasurementState.Reset);
            }
        }

        private void timUpdateProperties_Tick(object sender, EventArgs evt) {
            if(prevMinimum!=trkMinimum.Value) {
                updateModel(false);
                sendServoSignalChanged((ushort)trkMinimum.Value);
                prevMinimum = trkMinimum.Value;
            }
            if(prevMaximum!=trkMaximum.Value) {
                updateModel(false);
                sendServoSignalChanged((ushort)trkMaximum.Value);
                prevMaximum = trkMaximum.Value;
            }
        }

        private void ServoConfigWindow_FormClosing(object sender, FormClosingEventArgs evt) {
            if(evt.CloseReason == CloseReason.UserClosing) {
                if(updateModel(true)) {
                    sendComponentUpdate();
                    agent.doLocalUpdate(servo);
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


#region Usings
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public partial class ServoPanel : UserControl, iDetachableView {

        #region Fields
        private Agent agent;
        private Component servoGroup;
        private List<Servo> servos;
        private ServoWindow window;
        #endregion

        #region Lifecycle
        public ServoPanel(Agent agent, Component servoGroup) {
            this.agent = agent;
            this.servoGroup = servoGroup;
            InitializeComponent();
            initializeGui();
        }

        private void initializeGui() {
            this.UIThreadInvoke(delegate {
                try {
                    // set default reaction time to 20ms
                    cbxServoUpdateInterval.SelectedIndex = 0;
                    // subscribe for signal reception
                    pnlServoControl.onPositionUpdate += servoPositionUpdate;
                    // clear checkbox lists
                    chkAxisX.Items.Clear();
                    chkAxisY.Items.Clear();
                    // construct servo list
                    servos = new List<Servo>();
                    for(int i=0; i<servoGroup.Components.Count; i++) {
                        Servo servo = (Servo)servoGroup.Components[i];
                        servos.Add(servo);
                    }
                    // create custom user controls & fill servo checkbox lists
                    for(int i=0; i<servos.Count; i++) {
                        if(servos[i].Active) {
                            ServoControl servoControl = new ServoControl(agent, servos[i]);
                            servoControl.Location = new Point(0, servoControl.Size.Height*i);
                            pnlServoComponents.Controls.Add(servoControl);
                            chkAxisX.Items.Add(servos[i], servos[i].ViewAxisX);
                            chkAxisY.Items.Add(servos[i], servos[i].ViewAxisY);
                            chkReversed.Items.Add(servos[i], servos[i].ViewReversed);
                        }
                    }
                    // set current view rotation
                    if(servos.Count>0) {
                        pnlServoControl.Rotation = servos[0].ViewRotation;
                        txtRotation.Text = servos[0].ViewRotation.ToString();
                    }
                } catch(ComponentNotFoundException ex) {
                    #region Logbook
                    Logger.Log(Level.WARNING, ex);
                    #endregion
                }
            });
        }
        #endregion

        #region Properties
        public ServoControlView ServoControlPanel {
            get { return pnlServoControl; }
        }
        #endregion

        #region Functions
        public void detachView() {
            if(window==null) {
                window = new ServoWindow(this);
                window.Text = Parent.Text;
                window.ServoControlPanel.Rotation = servos[0].ViewRotation;
                window.ServoControlPanel.onPositionUpdate += servoPositionUpdate;
            }
            pnlServoControl.Enabled = false;
            window.Show();
        }

        private void sendComponentChanged(Servo servo) {
            UpdateComponent update = new UpdateComponent(servo.Id);
            update.Component = servo;
            agent.TcpNetworkClient.send(update);
        }

        private void sendServoPositionChanged(Servo servo) {
            ServoPositionCommand cmd = new ServoPositionCommand(servo.Id);
            cmd.Pin = servo.Pin;
            cmd.Board = servo.Address;
            cmd.Position = servo.Position;
            agent.TcpNetworkClient.send(cmd);
        }
        #endregion

        #region Event-Handling (Gui)
        /* This is an overload instead of attaching the Load(*) event manually.
         * Just copy and paste this code to other user-control classes. */
        protected override void OnLoad(EventArgs evt) {
            this.AutoSize = false;
            this.Dock = DockStyle.Fill;
            base.OnLoad(evt);
        }

        private void servoPositionUpdate(Vector2 position) {
            foreach(object item in chkAxisX.CheckedItems) {
                Servo servo = (Servo)item;
                if(servo.ViewReversed) {
                    servo.Position = 100f-Toolkit.clamp((position.X+1.0f)*0.5f*100f, 0f, 100f);
                } else {
                    servo.Position = Toolkit.clamp((position.X+1.0f)*0.5f*100f, 0f, 100f);
                }
                #region Update Track Bar
                foreach(ServoControl ctrl in pnlServoComponents.Controls) {
                    if(ctrl.Servo==servo) {
                        ctrl.TrackBar.Value = (int)servo.Position;
                        ctrl.TextBox.Text = ((int)servo.Position).ToString();
                    }
                }
                #endregion
                this.sendServoPositionChanged(servo);
            }
            foreach(object item in chkAxisY.CheckedItems) {
                Servo servo = (Servo)item;
                if(servo.ViewReversed) {
                    servo.Position = 100f-Toolkit.clamp((position.Y+1.0f)*0.5f*100f, 0f, 100f);
                } else {
                    servo.Position = Toolkit.clamp((position.Y+1.0f)*0.5f*100f, 0f, 100f);
                }
                #region Update Track Bar
                foreach(ServoControl ctrl in pnlServoComponents.Controls) {
                    if(ctrl.Servo==servo) {
                        ctrl.TrackBar.Value = (int)servo.Position;
                        ctrl.TextBox.Text = ((int)servo.Position).ToString();
                    }
                }
                #endregion
                this.sendServoPositionChanged(servo);
            }
        }

        private void txtRotation_Leave(object sender, EventArgs evt) {
            if(servos.Count>0) {
                float result = 0;
                if(float.TryParse(txtRotation.Text, out result)) {
                    servos[0].ViewRotation = result;
                    pnlServoControl.Rotation = result;
                    if(window!=null) window.ServoControlPanel.Rotation = result;
                    sendComponentChanged(servos[0]);
                } else {
                    servos[0].ViewRotation = 0;
                    txtRotation.Text = "0";
                }
            }
        }

        private void txtRotation_KeyUp(object sender, KeyEventArgs evt) {
            if(evt.KeyCode==Keys.Enter || evt.KeyCode==Keys.Return) {
                txtRotation_Leave(sender, evt);
            }
        }

        private void chkAxisX_ItemCheck(object sender, ItemCheckEventArgs evt) {
            Servo servo = servos[evt.Index];
            servo.ViewAxisX = evt.NewValue == CheckState.Checked ? true : false;
            sendComponentChanged(servo); 
        }

        private void chkAxisY_ItemCheck(object sender, ItemCheckEventArgs evt) {
            Servo servo = servos[evt.Index];
            servo.ViewAxisY = evt.NewValue == CheckState.Checked ? true : false;
            sendComponentChanged(servo);
        }

        private void chkReversed_ItemCheck(object sender, ItemCheckEventArgs evt) {
            Servo servo = servos[evt.Index];
            servo.ViewReversed = evt.NewValue == CheckState.Checked ? true : false;
            sendComponentChanged(servo);
        }

        private void cbxServoUpdateInterval_SelectedValueChanged(object sender, EventArgs e) {
            if(pnlServoControl!=null) {
                pnlServoControl.Interval = int.Parse(cbxServoUpdateInterval.GetItemText(cbxServoUpdateInterval.SelectedItem));
            }
            if(window!=null) {
                window.ServoControlPanel.Interval = int.Parse(cbxServoUpdateInterval.GetItemText(cbxServoUpdateInterval.SelectedItem));
            }
        }
        #endregion

    }

}

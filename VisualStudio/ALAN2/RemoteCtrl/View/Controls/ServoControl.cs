
#region Usings
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public partial class ServoControl : UserControl, iLocalUpdate {

        #region Fields
        private Agent agent;
        private Servo servo;
        private bool isKeyDown;
        private bool isMouseDown;
        private bool initialized;
        #endregion

        #region Lifecycle
        public ServoControl(Agent agent, Servo servo) {
            this.agent = agent;
            this.servo = servo;
            InitializeComponent();
            initializeLocalUpdate();
            agent.subscribeLocalUpdate(this);
            this.initialized = true;
        }
        #endregion

        #region Properties
        public Servo Servo {
            get { return servo; }
        }

        public TrackBar TrackBar {
            get { return trkPosition; }
        }

        public TextBox TextBox {
            get { return txtPosition; }
        } 
        #endregion

        #region Functions
        private void sendComponentChanged() {
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

        #region Local Update
        public void initializeLocalUpdate() {
            onLocalUpdate();
        }

        public iComponent getInterest() {
            return servo;
        }

        public List<iComponent> getInterests() {
            return null;
        }

        public void onLocalUpdate() {
            this.UIThreadInvoke(delegate {
                if(servo!=null) {
                    grpServoComponent.Text = servo.Name;
                    lblBoard.Text = "Board: "+Toolkit.toHexFormat(servo.Address);
                    lblPin.Text = "Pin: "+servo.Pin.ToString();
                    lblTime.Text = "Time: "+servo.Time.ToString()+" [ms]";
                    lblMinimum.Text = "Min: "+servo.Minimum.ToString()+" [us]";
                    lblMaximum.Text = "Max: "+servo.Maximum.ToString()+" [us]";
                    trkPosition.Value = (int)servo.Position;
                    txtPosition.Text = ((int)servo.Position).ToString();
                }
            });
        }
        #endregion

        #region Event-Handling (Gui)
        private void txtPosition_KeyUp(object sender, KeyEventArgs evt) {
            if(evt.KeyCode==Keys.Enter || evt.KeyCode==Keys.Return) {
                if(initialized) {
                    short value = 0;
                    if(short.TryParse(txtPosition.Text, out value)) {
                        if(Validation.validate(value, 0, 100)) {
                            trkPosition.Value = value;
                            servo.Position = value;
                            sendServoPositionChanged(servo);
                        } else {
                            trkPosition.Value = 50;
                            txtPosition.Text = "50";
                            servo.Position = 50f;
                            sendServoPositionChanged(servo);
                        }
                    }
                }
            }
        }

        private void trkPosition_MouseDown(object sender, MouseEventArgs e) {
            isMouseDown = true;
        }

        private void trkPosition_MouseUp(object sender, MouseEventArgs e) {
            if(initialized) {
                txtPosition.Text = trkPosition.Value.ToString();
                servo.Position = (float)trkPosition.Value;
                sendServoPositionChanged(servo);
            }
            isMouseDown = false;
        }

        private void trkPosition_KeyDown(object sender, KeyEventArgs e) {
            isKeyDown = true;
        }

        private void trkPosition_KeyUp(object sender, KeyEventArgs e) {
            if(initialized) {
                txtPosition.Text = trkPosition.Value.ToString();
                servo.Position = (float)trkPosition.Value;
                sendServoPositionChanged(servo);
            }
            isKeyDown = false;
        }

        private void trkPosition_Scroll(object sender, EventArgs e) {
            if(initialized) {
                if(!isMouseDown && !isKeyDown) {
                    txtPosition.Text = trkPosition.Value.ToString();
                    servo.Position = (float)trkPosition.Value;
                    sendServoPositionChanged(servo);
                }
            }
        }
        #endregion

    }

}
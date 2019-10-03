
#region Usings
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public partial class SensorControl : UserControl, iLocalUpdate {

        #region Fields
        private Agent agent;
        private Sensor sensor;
        private float range;
        #endregion

        #region Lifecycle
        public SensorControl(Agent agent, Sensor sensor) {
            this.agent = agent;
            this.sensor = sensor;
            InitializeComponent();
            initializeLocalUpdate();
            agent.subscribeLocalUpdate(this);
        }
        #endregion

        #region Local Update
        public void initializeLocalUpdate() {
            setLimits();
            onLocalUpdate();
        }

        public iComponent getInterest() {
            return sensor;
        }

        public List<iComponent> getInterests() {
            return null;
        }

        public void onLocalUpdate() {
            this.UIThreadInvoke(delegate {
                if(sensor is Battery) {
                    #region Battery
                    Battery battery = (Battery)sensor;
                    grpSensor.Text = battery.Name;
                    txtData.Text = "Current Voltage: "+battery.Data.ToString("0.0")+" ["+battery.Postfix+"]";
                    txtInterval.Text = "Read Interval: "+battery.ReadInterval;
                    txtPin1.Text = "Analog Pin: "+battery.Pin;
                    txtPin2.Visible = false;
                    txtMinimum.Text = "Minimum: "+battery.Minimum+" ["+battery.Postfix+"]";
                    txtMaximum.Text = "Maximum: "+battery.Maximum+" ["+battery.Postfix+"]";
                    pgsData.Value = getValue();
                    #endregion
                } else if(sensor is Humidity) {
                    #region Humidity
                    Humidity humidity = (Humidity)sensor;
                    grpSensor.Text = humidity.Name;
                    txtData.Text = "Current Humidity: "+humidity.Data.ToString("0.0")+" ["+humidity.Postfix+"]";
                    txtInterval.Text = "Read Interval: "+humidity.ReadInterval;
                    txtPin1.Text = "Digital Pin: "+humidity.Pin;
                    txtPin2.Visible = false;
                    txtMinimum.Text = "Minimum: "+humidity.Minimum+" ["+humidity.Postfix+"]";
                    txtMaximum.Text = "Maximum: "+humidity.Maximum+" ["+humidity.Postfix+"]";
                    pgsData.Value = getValue();
                    #endregion
                } else if(sensor is Thermistor) {
                    #region Thermistor
                    Thermistor thermistor = (Thermistor)sensor;
                    grpSensor.Text = thermistor.Name;
                    txtData.Text = "Current Temperature: "+thermistor.Data.ToString("0.0")+" ["+thermistor.Postfix+"]";
                    txtInterval.Text = "Read Interval: "+thermistor.ReadInterval;
                    txtPin1.Text = "Analog Pin: "+thermistor.Pin;
                    txtPin2.Visible = false;
                    txtMinimum.Text = "Minimum: "+thermistor.Minimum+" ["+thermistor.Postfix+"]";
                    txtMaximum.Text = "Maximum: "+thermistor.Maximum+" ["+thermistor.Postfix+"]";
                    pgsData.Value = getValue();
                    #endregion
                } else if(sensor is Photoresistor) {
                    #region Photoresistor
                    Photoresistor photoresistor = (Photoresistor)sensor;
                    grpSensor.Text = photoresistor.Name;
                    txtData.Text = "Current Intensity: "+photoresistor.Data.ToString("0.0")+" ["+photoresistor.Postfix+"]";
                    txtInterval.Text = "Read Interval: "+photoresistor.ReadInterval;
                    txtPin1.Text = "Analog Pin: "+photoresistor.Pin;
                    txtPin2.Visible = false;
                    txtMinimum.Text = "Minimum: "+photoresistor.Minimum+" ["+photoresistor.Postfix+"]";
                    txtMaximum.Text = "Maximum: "+photoresistor.Maximum+" ["+photoresistor.Postfix+"]";
                    pgsData.Value = getValue();
                    #endregion
                } else if(sensor is Sonar) {
                    #region Sonar
                    Sonar sonar = (Sonar)sensor;
                    grpSensor.Text = sonar.Name;
                    txtData.Text = "Current Distance: "+sonar.Data.ToString("0.0")+" ["+sonar.Postfix+"]";
                    txtInterval.Text = "Read Interval: "+sonar.ReadInterval;
                    txtPin1.Text = "Trigger Pin: "+sonar.TriggerPin;
                    txtPin2.Text = "Echo Pin: "+sonar.EchoPin;
                    txtMinimum.Text = "Minimum: "+sonar.Minimum+" ["+sonar.Postfix+"]";
                    txtMaximum.Text = "Maximum: "+sonar.Maximum+" ["+sonar.Postfix+"]";
                    pgsData.Value = getValue();
                    #endregion
                }
            });
        }
        #endregion

        #region Functions
        private void setLimits() {
            if(sensor.Minimum<0.0f) {
                range = Math.Abs(sensor.Maximum-sensor.Minimum);
                pgsData.Minimum = 0;
                pgsData.Maximum = (int)range;
            } else {
                pgsData.Minimum = (int)sensor.Minimum;
                pgsData.Maximum = (int)sensor.Maximum;
            }
        }

        private int getValue() {
            if(sensor.Minimum<0.0f) {
                return (int)Toolkit.clamp(sensor.Data+Math.Abs(sensor.Minimum), pgsData.Minimum, pgsData.Maximum);
            } else {
                return (int)Toolkit.clamp(sensor.Data, pgsData.Minimum, pgsData.Maximum);
            }
        }
        #endregion

    }

}

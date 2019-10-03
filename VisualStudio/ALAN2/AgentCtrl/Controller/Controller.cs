
#region Usings
using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using CommonCtrl;
using NativeWifi;
using DirectShowLib;
#endregion

namespace AgentCtrl {

    [Serializable]
    #region Xml Definitions
    [XmlRoot("Agent")]
    [XmlInclude(typeof(Identity))]
    [XmlInclude(typeof(Arduino))]
    [XmlInclude(typeof(Resolution))]
    [XmlInclude(typeof(Component))]
    [XmlInclude(typeof(Sensor))]
    [XmlInclude(typeof(Actuator))]
    [XmlInclude(typeof(Infrared))]
    [XmlInclude(typeof(InfraredRx))]
    [XmlInclude(typeof(InfraredTx))]
    [XmlInclude(typeof(Battery))]
    [XmlInclude(typeof(Gyroscope))]
    [XmlInclude(typeof(Humidity))]
    [XmlInclude(typeof(Thermistor))]
    [XmlInclude(typeof(Photoresistor))]
    [XmlInclude(typeof(Servo))]
    [XmlInclude(typeof(Sonar))]
    [XmlInclude(typeof(GPS))]
    [XmlInclude(typeof(Radar))]
    [XmlInclude(typeof(Camera))]
    [XmlInclude(typeof(CameraMono))]
    [XmlInclude(typeof(CameraStereo))]
    [XmlInclude(typeof(SpeechSyntheziser))]
    [XmlInclude(typeof(UdpNetworkServer))]
    [XmlInclude(typeof(TcpNetworkServer))]
    [XmlInclude(typeof(RtpNetworkServer))]
    #endregion
    public class Controller {

        #region Fields

        /* stored to xml */
        private Identity identity = new Identity();
        private Arduino arduino = new Arduino();
        private SpeechSyntheziser syntheziser = new SpeechSyntheziser();

        private UdpNetworkServer udpNetworkServer;
        private TcpNetworkServer tcpNetworkServer;
        private RtpNetworkServer rtpNetworkServer;

        private List<Component> components = new List<Component>();

        /* not stored to xml - system related fields */
        private WlanClient wlan = new WlanClient();
        private HwSystem system = new HwSystem();
        private HwWiFi wifi = new HwWiFi();
        private List<HwCamera> cameras = new List<HwCamera>();

        /* not stored to xml - console output */
        private volatile List<string> atmelConsole = new List<string>();
        private volatile List<string> agentConsole = new List<string>();

        /* not stored to xml - round trip measurements */
        private long tRoundTripTime;                        // time at which round trip request was sent to arduino
        private RoundTripTime roundTripTimePacket;          // cache packet received from remote controller to return after arduino measurement returned

        #endregion

        #region Lifecycle
        public Controller() {
            // used for xml serialization ...
        }

        public void launch() {
            this.initConsole();
            this.initWiFiState();
            this.initCameraDevices();
            this.initArduinoDevice();
            this.initSpeechSynthesizer();
            this.initHardwareComponents();
            this.initNetworkServices();
        }

        private void initConsole() {
            Console.Title = "Agent Controller ["+Program.Controller.Identity.Name+" v"+Program.Controller.Identity.Revision+"] @ "+Toolkit.getNetworkAdress(false);
            #region Calculate Dashes
            string dashes = "";
            for(int i = 0; i<Console.Title.Length; i++) {
                dashes += "-";
            }
            #endregion
            Console.WriteLine(dashes);
            Console.WriteLine(Console.Title);
            Console.WriteLine(dashes);
            Console.WriteLine("");
        }

        public void terminate() {
            // close all hardware components
            if(components.Count>0) {
                closeHardwareComponents(components);
            }
            // close all network services
            if(udpNetworkServer!=null) {
                udpNetworkServer.terminate();
            }
            if(tcpNetworkServer!=null) {
                tcpNetworkServer.terminate();
            }
            if(rtpNetworkServer!=null) {
                rtpNetworkServer.terminate();
            }
            // close arduino device
            arduino.terminate();
        }

        public void store() {
            try {
                using(TextWriter writer = new StreamWriter(@"Settings.xml")) {
                    XmlSerializer serializer = new XmlSerializer(typeof(Controller));
                    serializer.Serialize(writer, this);
                }
            } catch(Exception ex) {
                #region Logbook
                Logger.Log(Level.WARNING, "Could not store agent controller settings.", ex);
                #endregion
            }
        }
        #endregion

        #region Defaults
        public void defaults(string type) {
            if(type.Equals("EMPTY")) {
                #region EMPTY

                #region Arduino
                arduino.Board = Board.Mega;
                #endregion

                #region Identity
                identity.Id = Guid.NewGuid().ToString("N");
                identity.Name = "<DEFAULT>";
                identity.Revision = "1.0.0";
                #endregion

                #region Network
                udpNetworkServer = new UdpNetworkServer();
                tcpNetworkServer = new TcpNetworkServer();
                rtpNetworkServer = new RtpNetworkServer();
                #endregion

                #region Components
                Component group = new Component();
                group.Id = Component.getComponentId();
                group.Active = true;
                group.Name = "Servos";
                group.setComponentType(typeof(Servo));

                Servo servo1 = new Servo();
                servo1.Id = Component.getComponentId();
                servo1.Active = true;
                servo1.Name = "Servo";
                servo1.Pin = 0;
                servo1.Address = 0x40;
                servo1.Position = 50f;
                servo1.Time = 400;
                servo1.Minimum = 150;
                servo1.Maximum = 600;
                servo1.ViewAxisX = true;
                group.Components.Add(servo1);

                Servo servo2 = new Servo();
                servo2.Id = Component.getComponentId();
                servo2.Active = true;
                servo2.Name = "Servo";
                servo2.Pin = 1;
                servo2.Address = 0x40;
                servo2.Position = 50f;
                servo2.Time = 400;
                servo2.Minimum = 150;
                servo2.Maximum = 600;
                servo2.ViewAxisY = true;
                group.Components.Add(servo2);

                components.Add(group);
                #endregion

                #endregion
            } else if(type.Equals("WALL-E")) {
                #region WALL-E

                #region Arduino
                arduino.Board = Board.Mega;
                #endregion

                #region Identity
                identity.Id = Guid.NewGuid().ToString("N");
                identity.Name = "WALL-E";
                identity.Revision = "0.9.1";
                #endregion

                #region Network
                udpNetworkServer = new UdpNetworkServer();
                tcpNetworkServer = new TcpNetworkServer();
                rtpNetworkServer = new RtpNetworkServer();
                #endregion

                #region Components

                #region Battery
                Battery battery = new Battery();
                battery.Id = Component.getComponentId();
                battery.Active = true;
                battery.Name = "Battery [12V/10Ah]";
                battery.Pin = 0;
                battery.Minimum = 0.0f;
                battery.Maximum = 15.0f;
                battery.Slope = 0.01742316f;
                battery.Intercept = 0.0505752f;
                battery.Postfix = "V";
                battery.Charging = false;
                battery.CriticalVoltage = 10.5f;
                battery.State = new float[5] { 11.1f, 11.4f, 11.7f, 12.0f, 12.4f };
                battery.ReadInterval = 5000;
                battery.Logging = true;
                battery.LogInterval = 30000;
                components.Add(battery);
                #endregion

                #region GPS
                /*GPS gps = new GPS();
                gps.Id = Component.getComponentId();
                gps.Active = true;
                gps.Name = "GPS";
                gps.ReadInterval = 1000;
                components.Add(gps);*/
                #endregion

                #region Cameras
                CameraMono cameraMono = new CameraMono();
                cameraMono.Id = Component.getComponentId();
                cameraMono.Active = true;
                cameraMono.Name = "Camera";
                cameraMono.Resolution = new Resolution(640, 480);
                cameraMono.Quality = 85;
                cameraMono.Colour = true;
                cameraMono.Capturing = true;
                cameraMono.Streaming = true;
                cameraMono.CameraIndex = 0;
                components.Add(cameraMono);
                #endregion

                #region Infrared
                /*Component infraredGroup = new Component();
                infraredGroup.Id = Component.getComponentId();
                infraredGroup.Active = true;
                infraredGroup.Name = "Infrared";
                infraredGroup.setComponentType(typeof(Infrared));

                InfraredRx irRx = new InfraredRx();
                irRx.Id = Component.getComponentId();
                irRx.Active = true;
                irRx.Name = "Receiver";
                irRx.Pin = 48;
                irRx.Protocol = (ushort)InfraredProtocol.Amiga;
                infraredGroup.Components.Add(irRx);

                InfraredTx irTx = new InfraredTx();
                irTx.Id = Component.getComponentId();
                irTx.Active = true;
                irTx.Name = "Transceiver";
                irTx.Pin = 5;
                irTx.Protocol = (ushort)InfraredProtocol.Amiga;
                infraredGroup.Components.Add(irTx);

                components.Add(infraredGroup);*/
                #endregion

                #region Gyroscope
                /*Gyroscope gyroscope = new Gyroscope();
                gyroscope.Id = Component.getComponentId();
                gyroscope.Active = true;
                gyroscope.Name = "Gyroscope";
                gyroscope.Address = 0x68;
                gyroscope.ReadInterval = 200;
                components.Add(gyroscope);*/
                #endregion

                #region Sensors
                Component sensorGroup = new Component();
                sensorGroup.Id = Component.getComponentId();
                sensorGroup.Active = true;
                sensorGroup.Name = "Sensors";
                sensorGroup.setComponentType(typeof(Sensor));

                /*Humidity humidity1 = new Humidity();
                humidity1.Id = Component.getComponentId();
                humidity1.Active = true;
                humidity1.Name = "Humidity";
                humidity1.Pin = 22;
                humidity1.Minimum = 0.0f;
                humidity1.Maximum = 100.0f;
                humidity1.Slope = 1.0f;
                humidity1.Intercept = 0.0f;
                humidity1.Postfix = "%";
                humidity1.ReadInterval = 60000;
                humidity1.Logging = true;
                humidity1.LogCapacity = 4096;
                humidity1.LogInterval = 60000;
                sensorGroup.Components.Add(humidity1);*/

                /*Photoresistor photoresistor1 = new Photoresistor();
                photoresistor1.Id = Component.getComponentId();
                photoresistor1.Active = true;
                photoresistor1.Name = "Photoresistor";
                photoresistor1.Pin = 1;
                photoresistor1.Minimum = 0.0f;
                photoresistor1.Maximum = 100.0f;
                photoresistor1.Slope = -0.0976562f;
                photoresistor1.Intercept = 100.0f;
                photoresistor1.Postfix = "%";
                photoresistor1.ReadInterval = 60000;
                photoresistor1.Logging = true;
                photoresistor1.LogCapacity = 4096;
                photoresistor1.LogInterval = 60000;
                sensorGroup.Components.Add(photoresistor1);*/

                /*Thermistor thermistor1 = new Thermistor();
                thermistor1.Id = Component.getComponentId();
                thermistor1.Active = true;
                thermistor1.Name = "Thermistor";
                thermistor1.Pin = 2;
                thermistor1.Minimum = -25.0f;
                thermistor1.Maximum = 125.0f;
                thermistor1.Slope = 1.0f;
                thermistor1.Intercept = 0.0f;
                thermistor1.Postfix = "°C";
                thermistor1.ReadInterval = 60000;
                thermistor1.Logging = true;
                thermistor1.LogCapacity = 4096;
                thermistor1.LogInterval = 60000;
                sensorGroup.Components.Add(thermistor1);*/

                Sonar sonar1 = new Sonar();
                sonar1.Id = Component.getComponentId();
                sonar1.Active = true;
                sonar1.Name = "Sonar";
                sonar1.TriggerPin = 33;
                sonar1.EchoPin = 32;
                sonar1.Minimum = 0.0f;
                sonar1.Maximum = 250.0f;
                sonar1.Slope = 1.0f;
                sonar1.Intercept = 0.0f;
                sonar1.Postfix = "cm";
                sonar1.ReadInterval = 100;
                sonar1.Logging = false;
                sonar1.LogCapacity = 4096;
                sonar1.LogInterval = 1000;
                sensorGroup.Components.Add(sonar1);

                Sonar sonar2 = new Sonar();
                sonar2.Id = Component.getComponentId();
                sonar2.Active = true;
                sonar2.Name = "Sonar";
                sonar2.TriggerPin = 35;
                sonar2.EchoPin = 34;
                sonar2.Minimum = 0.0f;
                sonar2.Maximum = 250.0f;
                sonar2.Slope = 1.0f;
                sonar2.Intercept = 0.0f;
                sonar2.Postfix = "cm";
                sonar2.ReadInterval = 100;
                sonar2.Logging = false;
                sonar2.LogCapacity = 4096;
                sonar2.LogInterval = 1000;
                sensorGroup.Components.Add(sonar2);

                Sonar sonar3 = new Sonar();
                sonar3.Id = Component.getComponentId();
                sonar3.Active = true;
                sonar3.Name = "Sonar";
                sonar3.TriggerPin = 37;
                sonar3.EchoPin = 36;
                sonar3.Minimum = 0.0f;
                sonar3.Maximum = 250.0f;
                sonar3.Slope = 1.0f;
                sonar3.Intercept = 0.0f;
                sonar3.Postfix = "cm";
                sonar3.ReadInterval = 100;
                sonar3.Logging = false;
                sonar3.LogCapacity = 4096;
                sonar3.LogInterval = 1000;
                sensorGroup.Components.Add(sonar3);

                components.Add(sensorGroup);
                #endregion

                #region Servos

                #region Servos (Augenbrauen)
                Component servoGroup1 = new Component();
                servoGroup1.Id = Component.getComponentId();
                servoGroup1.Active = true;
                servoGroup1.Name = "Augenbrauen";
                servoGroup1.setComponentType(typeof(Servo));

                Servo servo11 = new Servo();
                servo11.Id = Component.getComponentId();
                servo11.Active = true;
                servo11.Name = "Servo";
                servo11.Pin = 0;
                servo11.Address = 0x40;
                servo11.Position = 50f;
                servo11.Time = 400;
                servo11.Minimum = 150;
                servo11.Maximum = 600;
                servo11.ViewAxisX = true;
                servoGroup1.Components.Add(servo11);

                Servo servo12 = new Servo();
                servo12.Id = Component.getComponentId();
                servo12.Active = true;
                servo12.Name = "Servo";
                servo12.Pin = 1;
                servo12.Address = 0x40;
                servo12.Position = 50f;
                servo12.Time = 400;
                servo12.Minimum = 150;
                servo12.Maximum = 600;
                servo12.ViewAxisY = true;
                servoGroup1.Components.Add(servo12);

                components.Add(servoGroup1);
                #endregion

                #region Servos (Augen neigen)
                Component servoGroup2 = new Component();
                servoGroup2.Id = Component.getComponentId();
                servoGroup2.Active = true;
                servoGroup2.Name = "Augen";
                servoGroup2.setComponentType(typeof(Servo));

                Servo servo21 = new Servo();
                servo21.Id = Component.getComponentId();
                servo21.Active = true;
                servo21.Name = "Servo";
                servo21.Pin = 2;
                servo21.Address = 0x40;
                servo21.Position = 50f;
                servo21.Time = 400;
                servo21.Minimum = 150;
                servo21.Maximum = 600;
                servo21.ViewAxisX = true;
                servoGroup2.Components.Add(servo21);

                Servo servo22 = new Servo();
                servo22.Id = Component.getComponentId();
                servo22.Active = true;
                servo22.Name = "Servo";
                servo22.Pin = 3;
                servo22.Address = 0x40;
                servo22.Position = 50f;
                servo22.Time = 400;
                servo22.Minimum = 150;
                servo22.Maximum = 600;
                servo22.ViewAxisY = true;
                servoGroup2.Components.Add(servo22);

                components.Add(servoGroup2);
                #endregion

                #region Servos (Kopf neigen)
                Component servoGroup3 = new Component();
                servoGroup3.Id = Component.getComponentId();
                servoGroup3.Active = true;
                servoGroup3.Name = "Kopf 1";
                servoGroup3.setComponentType(typeof(Servo));

                Servo servo31 = new Servo();
                servo31.Id = Component.getComponentId();
                servo31.Active = true;
                servo31.Name = "Servo";
                servo31.Pin = 4;
                servo31.Address = 0x40;
                servo31.Position = 50f;
                servo31.Time = 400;
                servo31.Minimum = 150;
                servo31.Maximum = 600;
                servo31.ViewAxisX = true;
                servoGroup3.Components.Add(servo31);

                Servo servo32 = new Servo();
                servo32.Id = Component.getComponentId();
                servo32.Active = true;
                servo32.Name = "Servo";
                servo32.Pin = 5;
                servo32.Address = 0x40;
                servo32.Position = 50f;
                servo32.Time = 400;
                servo32.Minimum = 150;
                servo32.Maximum = 600;
                servo32.ViewAxisY = true;
                servoGroup3.Components.Add(servo32);

                components.Add(servoGroup3);
                #endregion

                #region Servos (Kopf schwenken)
                Component servoGroup4 = new Component();
                servoGroup4.Id = Component.getComponentId();
                servoGroup4.Active = true;
                servoGroup4.Name = "Kopf 2";
                servoGroup4.setComponentType(typeof(Servo));

                Servo servo41 = new Servo();
                servo41.Id = Component.getComponentId();
                servo41.Active = true;
                servo41.Name = "Servo";
                servo41.Pin = 6;
                servo41.Address = 0x40;
                servo41.Position = 50f;
                servo41.Time = 400;
                servo41.Minimum = 150;
                servo41.Maximum = 600;
                servo41.ViewAxisX = true;
                servoGroup4.Components.Add(servo41);

                components.Add(servoGroup4);
                #endregion

                #region Servos (Hals neigen)
                Component servoGroup5 = new Component();
                servoGroup5.Id = Component.getComponentId();
                servoGroup5.Active = true;
                servoGroup5.Name = "Hals";
                servoGroup5.setComponentType(typeof(Servo));

                Servo servo51 = new Servo();
                servo51.Id = Component.getComponentId();
                servo51.Active = true;
                servo51.Name = "Servo";
                servo51.Pin = 7;
                servo51.Address = 0x40;
                servo51.Position = 50f;
                servo51.Time = 400;
                servo51.Minimum = 150;
                servo51.Maximum = 600;
                servo51.ViewAxisX = true;
                servoGroup5.Components.Add(servo51);

                components.Add(servoGroup5);
                #endregion

                #region Servos (Körper neigen)
                Component servoGroup6 = new Component();
                servoGroup6.Id = Component.getComponentId();
                servoGroup6.Active = true;
                servoGroup6.Name = "Körper";
                servoGroup6.setComponentType(typeof(Servo));

                Servo servo61 = new Servo();
                servo61.Id = Component.getComponentId();
                servo61.Active = true;
                servo61.Name = "Servo";
                servo61.Pin = 8;
                servo61.Address = 0x40;
                servo61.Position = 50f;
                servo61.Time = 400;
                servo61.Minimum = 150;
                servo61.Maximum = 600;
                servo61.ViewAxisX = true;
                servoGroup6.Components.Add(servo61);

                components.Add(servoGroup6);
                #endregion

                #region Servos (Arme neigen)
                Component servoGroup7 = new Component();
                servoGroup7.Id = Component.getComponentId();
                servoGroup7.Active = true;
                servoGroup7.Name = "Arme";
                servoGroup7.setComponentType(typeof(Servo));

                Servo servo71 = new Servo();
                servo71.Id = Component.getComponentId();
                servo71.Active = true;
                servo71.Name = "Servo";
                servo71.Pin = 9;
                servo71.Address = 0x40;
                servo71.Position = 50f;
                servo71.Time = 400;
                servo71.Minimum = 150;
                servo71.Maximum = 600;
                servo71.ViewAxisX = true;
                servoGroup7.Components.Add(servo71);

                Servo servo72 = new Servo();
                servo72.Id = Component.getComponentId();
                servo72.Active = true;
                servo72.Name = "Servo";
                servo72.Pin = 10;
                servo72.Address = 0x40;
                servo72.Position = 50f;
                servo72.Time = 400;
                servo72.Minimum = 150;
                servo72.Maximum = 600;
                servo72.ViewAxisY = true;
                servoGroup7.Components.Add(servo72);

                components.Add(servoGroup7);
                #endregion

                #endregion

                #region Motors
                Component servoGroup9 = new Component();
                servoGroup9.Id = Component.getComponentId();
                servoGroup9.Active = true;
                servoGroup9.Name = "Fahren";
                servoGroup9.setComponentType(typeof(Servo));

                Servo servo91 = new Servo();
                servo91.Id = Component.getComponentId();
                servo91.Active = true;
                servo91.Name = "Servo";
                servo91.Pin = 14;
                servo91.Address = 0x40;
                servo91.Position = 50f;
                servo91.Time = 600;
                servo91.Minimum = 150;
                servo91.Maximum = 600;
                servo91.ViewAxisX = true;
                servo91.ViewRotation = -45f;
                servoGroup9.Components.Add(servo91);

                Servo servo92 = new Servo();
                servo92.Id = Component.getComponentId();
                servo92.Active = true;
                servo92.Name = "Servo";
                servo92.Pin = 15;
                servo92.Address = 0x40;
                servo92.Position = 50f;
                servo92.Time = 400;
                servo92.Minimum = 150;
                servo92.Maximum = 600;
                servo92.ViewAxisY = true;
                servo92.ViewRotation = -45f;
                servoGroup9.Components.Add(servo92);

                components.Add(servoGroup9);
                #endregion

                #endregion

                #endregion
            } else if(type.Equals("ALAN-II")) {
                #region ALAN-II

                #region Arduino
                arduino.Board = Board.Mega;
                #endregion

                #region Identity
                identity.Id = Guid.NewGuid().ToString("N");
                identity.Name = "ALAN-II";
                identity.Revision = "0.1.2";
                #endregion

                #region Network
                udpNetworkServer = new UdpNetworkServer();
                tcpNetworkServer = new TcpNetworkServer();
                rtpNetworkServer = new RtpNetworkServer();
                #endregion

                #region Components

                #region Battery
                Battery battery = new Battery();
                battery.Id = Component.getComponentId();
                battery.Active = true;
                battery.Name = "Battery [12V/10Ah]";
                battery.Pin = 0;
                battery.Minimum = 0.0f;
                battery.Maximum = 15.0f;
                battery.Slope = 0.01742316f;
                battery.Intercept = 0.0505752f;
                battery.Postfix = "V";
                battery.Charging = false;
                battery.CriticalVoltage = 10.5f;
                battery.State = new float[5] { 11.1f, 11.4f, 11.7f, 12.0f, 12.4f };
                battery.ReadInterval = 5000;
                battery.Logging = true;
                battery.LogInterval = 30000;
                components.Add(battery);
                #endregion

                #region GPS
                GPS gps = new GPS();
                gps.Id = Component.getComponentId();
                gps.Active = true;
                gps.Name = "GPS";
                gps.ReadInterval = 1000;
                components.Add(gps);
                #endregion

                #region Cameras
                CameraMono cameraMono1 = new CameraMono();
                cameraMono1.Id = Component.getComponentId();
                cameraMono1.Active = true;
                cameraMono1.Name = "Camera";
                cameraMono1.Resolution = new Resolution(640, 480);
                cameraMono1.Quality = 85;
                cameraMono1.Colour = true;
                cameraMono1.Capturing = true;
                cameraMono1.Streaming = true;
                cameraMono1.CameraIndex = 0;
                components.Add(cameraMono1);

                CameraMono cameraMono2 = new CameraMono();
                cameraMono2.Id = Component.getComponentId();
                cameraMono2.Active = false;
                cameraMono2.Name = "Camera";
                cameraMono2.Resolution = new Resolution(640, 480);
                cameraMono2.Quality = 85;
                cameraMono2.Colour = true;
                cameraMono2.Capturing = true;
                cameraMono2.Streaming = true;
                cameraMono2.CameraIndex = 1;
                components.Add(cameraMono2);

                CameraStereo cameraStereo = new CameraStereo();
                cameraStereo.Id = Component.getComponentId();
                cameraStereo.Active = false;
                cameraStereo.Name = "Camera";
                cameraStereo.Resolution = new Resolution(640, 480);
                cameraStereo.Quality = 85;
                cameraStereo.Colour = true;
                cameraStereo.Capturing = true;
                cameraStereo.Streaming = true;
                cameraStereo.LeftCameraIndex = 0;
                cameraStereo.RightCameraIndex = 1;
                components.Add(cameraStereo);
                #endregion

                #region Infrared
                Component infraredGroup = new Component();
                infraredGroup.Id = Component.getComponentId();
                infraredGroup.Active = true;
                infraredGroup.Name = "Infrared";
                infraredGroup.setComponentType(typeof(Infrared));

                InfraredRx irRx = new InfraredRx();
                irRx.Id = Component.getComponentId();
                irRx.Active = true;
                irRx.Name = "Receiver";
                irRx.Pin = 48;
                irRx.Protocol = (ushort)InfraredProtocol.Amiga;
                infraredGroup.Components.Add(irRx);

                InfraredTx irTx = new InfraredTx();
                irTx.Id = Component.getComponentId();
                irTx.Active = true;
                irTx.Name = "Transceiver";
                irTx.Pin = 5;
                irTx.Protocol = (ushort)InfraredProtocol.Amiga;
                infraredGroup.Components.Add(irTx);

                components.Add(infraredGroup);
                #endregion

                #region Gyroscope
                Gyroscope gyroscope = new Gyroscope();
                gyroscope.Id = Component.getComponentId();
                gyroscope.Active = true;
                gyroscope.Name = "Gyroscope";
                gyroscope.Address = 0x68;
                gyroscope.ReadInterval = 200;
                components.Add(gyroscope);
                #endregion

                #region Sensors
                Component sensorGroup = new Component();
                sensorGroup.Id = Component.getComponentId();
                sensorGroup.Active = true;
                sensorGroup.Name = "Sensors";
                sensorGroup.setComponentType(typeof(Sensor));

                /*Humidity humidity1 = new Humidity();
                humidity1.Id = Component.getComponentId();
                humidity1.Active = true;
                humidity1.Name = "Humidity";
                humidity1.Pin = 22;
                humidity1.Minimum = 0.0f;
                humidity1.Maximum = 100.0f;
                humidity1.Slope = 1.0f;
                humidity1.Intercept = 0.0f;
                humidity1.Postfix = "%";
                humidity1.ReadInterval = 500;
                humidity1.Logging = true;
                humidity1.LogCapacity = 4096;
                humidity1.LogInterval = 60000;
                sensorGroup.Components.Add(humidity1);*/

                Photoresistor photoresistor1 = new Photoresistor();
                photoresistor1.Id = Component.getComponentId();
                photoresistor1.Active = true;
                photoresistor1.Name = "Photoresistor";
                photoresistor1.Pin = 1;
                photoresistor1.Minimum = 0.0f;
                photoresistor1.Maximum = 100.0f;
                photoresistor1.Slope = -0.0976562f;
                photoresistor1.Intercept = 100.0f;
                photoresistor1.Postfix = "%";
                photoresistor1.ReadInterval = 500;
                photoresistor1.Logging = true;
                photoresistor1.LogCapacity = 4096;
                photoresistor1.LogInterval = 60000;
                sensorGroup.Components.Add(photoresistor1);

                Thermistor thermistor1 = new Thermistor();
                thermistor1.Id = Component.getComponentId();
                thermistor1.Active = true;
                thermistor1.Name = "Thermistor";
                thermistor1.Pin = 2;
                thermistor1.Minimum = -25.0f;
                thermistor1.Maximum = 125.0f;
                thermistor1.Slope = 1.0f;
                thermistor1.Intercept = 0.0f;
                thermistor1.Postfix = "°C";
                thermistor1.ReadInterval = 500;
                thermistor1.Logging = true;
                thermistor1.LogCapacity = 4096;
                thermistor1.LogInterval = 60000;
                sensorGroup.Components.Add(thermistor1);

                Sonar sonar1 = new Sonar();
                sonar1.Id = Component.getComponentId();
                sonar1.Active = true;
                sonar1.Name = "Sonar";
                sonar1.TriggerPin = 33;
                sonar1.EchoPin = 32;
                sonar1.Minimum = 0.0f;
                sonar1.Maximum = 250.0f;
                sonar1.Slope = 1.0f;
                sonar1.Intercept = 0.0f;
                sonar1.Postfix = "cm";
                sonar1.ReadInterval = 100;
                sonar1.Logging = false;
                sonar1.LogCapacity = 4096;
                sonar1.LogInterval = 1000;
                sensorGroup.Components.Add(sonar1);

                Sonar sonar2 = new Sonar();
                sonar2.Id = Component.getComponentId();
                sonar2.Active = true;
                sonar2.Name = "Sonar";
                sonar2.TriggerPin = 35;
                sonar2.EchoPin = 34;
                sonar2.Minimum = 0.0f;
                sonar2.Maximum = 250.0f;
                sonar2.Slope = 1.0f;
                sonar2.Intercept = 0.0f;
                sonar2.Postfix = "cm";
                sonar2.ReadInterval = 100;
                sonar2.Logging = false;
                sonar2.LogCapacity = 4096;
                sonar2.LogInterval = 1000;
                sensorGroup.Components.Add(sonar2);

                Sonar sonar3 = new Sonar();
                sonar3.Id = Component.getComponentId();
                sonar3.Active = true;
                sonar3.Name = "Sonar";
                sonar3.TriggerPin = 37;
                sonar3.EchoPin = 36;
                sonar3.Minimum = 0.0f;
                sonar3.Maximum = 250.0f;
                sonar3.Slope = 1.0f;
                sonar3.Intercept = 0.0f;
                sonar3.Postfix = "cm";
                sonar3.ReadInterval = 100;
                sonar3.Logging = false;
                sonar3.LogCapacity = 4096;
                sonar3.LogInterval = 1000;
                sensorGroup.Components.Add(sonar3);

                components.Add(sensorGroup);
                #endregion

                #region Servos
                Component servoGroup1 = new Component();
                servoGroup1.Id = Component.getComponentId();
                servoGroup1.Active = true;
                servoGroup1.Name = "Servos (Head)";
                servoGroup1.setComponentType(typeof(Servo));

                Servo servo11 = new Servo();
                servo11.Id = Component.getComponentId();
                servo11.Active = true;
                servo11.Name = "Servo";
                servo11.Pin = 0;
                servo11.Address = 0x40;
                servo11.Position = 50f;
                servo11.Time = 400;
                servo11.Minimum = 150;
                servo11.Maximum = 600;
                servo11.ViewAxisX = true;
                servoGroup1.Components.Add(servo11);

                Servo servo12 = new Servo();
                servo12.Id = Component.getComponentId();
                servo12.Active = true;
                servo12.Name = "Servo";
                servo12.Pin = 1;
                servo12.Address = 0x40;
                servo12.Position = 50f;
                servo12.Time = 1000;
                servo12.Minimum = 150;
                servo12.Maximum = 600;
                servo12.ViewAxisY = true;
                servoGroup1.Components.Add(servo12);

                Servo servo13 = new Servo();
                servo13.Id = Component.getComponentId();
                servo13.Active = true;
                servo13.Name = "Servo";
                servo13.Pin = 6;
                servo13.Address = 0x40;
                servo13.Position = 50f;
                servo13.Time = 400;
                servo13.Minimum = 150;
                servo13.Maximum = 600;
                servo13.ViewAxisX = true;
                servoGroup1.Components.Add(servo13);

                Servo servo14 = new Servo();
                servo14.Id = Component.getComponentId();
                servo14.Active = true;
                servo14.Name = "Servo";
                servo14.Pin = 7;
                servo14.Address = 0x40;
                servo14.Position = 50f;
                servo14.Time = 400;
                servo14.Minimum = 150;
                servo14.Maximum = 600;
                servo14.ViewAxisY = true;
                servoGroup1.Components.Add(servo14);

                components.Add(servoGroup1);
                #endregion

                #region Servos
                Component servoGroup2 = new Component();
                servoGroup2.Id = Component.getComponentId();
                servoGroup2.Active = true;
                servoGroup2.Name = "Servos (Body)";
                servoGroup2.setComponentType(typeof(Servo));

                Servo servo21 = new Servo();
                servo21.Id = Component.getComponentId();
                servo21.Active = true;
                servo21.Name = "Servo";
                servo21.Pin = 8;
                servo21.Address = 0x40;
                servo21.Position = 50f;
                servo21.Time = 400;
                servo21.Minimum = 150;
                servo21.Maximum = 600;
                servoGroup2.Components.Add(servo21);

                Servo servo22 = new Servo();
                servo22.Id = Component.getComponentId();
                servo22.Active = true;
                servo22.Name = "Servo";
                servo22.Pin = 9;
                servo22.Address = 0x40;
                servo22.Position = 50f;
                servo22.Time = 400;
                servo22.Minimum = 150;
                servo22.Maximum = 600;
                servoGroup2.Components.Add(servo22);

                Servo servo23 = new Servo();
                servo23.Id = Component.getComponentId();
                servo23.Active = true;
                servo23.Name = "Servo";
                servo23.Pin = 10;
                servo23.Address = 0x40;
                servo23.Position = 50f;
                servo23.Time = 400;
                servo23.Minimum = 150;
                servo23.Maximum = 600;
                servoGroup2.Components.Add(servo23);

                Servo servo24 = new Servo();
                servo24.Id = Component.getComponentId();
                servo24.Active = true;
                servo24.Name = "Servo";
                servo24.Pin = 11;
                servo24.Address = 0x40;
                servo24.Position = 50f;
                servo24.Time = 400;
                servo24.Minimum = 150;
                servo24.Maximum = 600;
                servoGroup2.Components.Add(servo24);

                components.Add(servoGroup2);
                #endregion

                #endregion

                #endregion
            } else {
                #region SUPERVISION

                #region Arduino
                arduino.Board = Board.Mega;
                #endregion

                #region Identity
                identity.Id = Guid.NewGuid().ToString("N");
                identity.Name = "SUPERVISION";
                identity.Revision = "1.0.0";
                #endregion

                #region Network
                udpNetworkServer = new UdpNetworkServer();
                tcpNetworkServer = new TcpNetworkServer();
                rtpNetworkServer = new RtpNetworkServer();
                #endregion

                #region Components

                #region Battery
                Battery battery = new Battery();
                battery.Id = Component.getComponentId();
                battery.Active = true;
                battery.Name = "Battery [9V]";
                battery.Pin = 0;
                battery.Minimum = 0.0f;
                battery.Maximum = 10.0f;
                battery.Slope = 0.01742316f;
                battery.Intercept = 0.0505752f;
                battery.Postfix = "V";
                battery.Charging = false;
                battery.CriticalVoltage = 7.0f;
                battery.State = new float[5] { 7.5f, 8.0f, 8.5f, 9.0f, 9.5f };
                battery.ReadInterval = 500;
                battery.Logging = true;
                battery.LogInterval = 30000;
                components.Add(battery);
                #endregion

                #region GPS
                GPS gps = new GPS();
                gps.Id = Component.getComponentId();
                gps.Active = true;
                gps.Name = "GPS";
                gps.ReadInterval = 1000;
                components.Add(gps);
                #endregion

                #region Cameras
                CameraMono cameraMono1 = new CameraMono();
                cameraMono1.Id = Component.getComponentId();
                cameraMono1.Active = true;
                cameraMono1.Name = "Camera";
                cameraMono1.Resolution = new Resolution(640, 480);
                cameraMono1.Quality = 85;
                cameraMono1.Colour = true;
                cameraMono1.Capturing = true;
                cameraMono1.Streaming = true;
                cameraMono1.CameraIndex = 0;
                components.Add(cameraMono1);

                CameraMono cameraMono2 = new CameraMono();
                cameraMono2.Id = Component.getComponentId();
                cameraMono2.Active = false;
                cameraMono2.Name = "Camera";
                cameraMono2.Resolution = new Resolution(640, 480);
                cameraMono2.Quality = 85;
                cameraMono2.Colour = true;
                cameraMono2.Capturing = true;
                cameraMono2.Streaming = true;
                cameraMono2.CameraIndex = 1;
                components.Add(cameraMono2);

                CameraStereo cameraStereo = new CameraStereo();
                cameraStereo.Id = Component.getComponentId();
                cameraStereo.Active = false;
                cameraStereo.Name = "Camera";
                cameraStereo.Resolution = new Resolution(640, 480);
                cameraStereo.Quality = 85;
                cameraStereo.Colour = true;
                cameraStereo.Capturing = true;
                cameraStereo.Streaming = true;
                cameraStereo.LeftCameraIndex = 0;
                cameraStereo.RightCameraIndex = 1;
                components.Add(cameraStereo);
                #endregion

                #region Infrared
                Component infraredGroup = new Component();
                infraredGroup.Id = Component.getComponentId();
                infraredGroup.Active = true;
                infraredGroup.Name = "Infrared";
                infraredGroup.setComponentType(typeof(Infrared));

                InfraredRx irRx = new InfraredRx();
                irRx.Id = Component.getComponentId();
                irRx.Active = true;
                irRx.Name = "Receiver";
                irRx.Pin = 48;
                irRx.Protocol = (ushort)InfraredProtocol.Amiga;
                infraredGroup.Components.Add(irRx);

                InfraredTx irTx = new InfraredTx();
                irTx.Id = Component.getComponentId();
                irTx.Active = true;
                irTx.Name = "Transceiver";
                irTx.Pin = 5;
                irTx.Protocol = (ushort)InfraredProtocol.Amiga;
                infraredGroup.Components.Add(irTx);

                components.Add(infraredGroup);
                #endregion

                #region Gyroscope
                Gyroscope gyroscope = new Gyroscope();
                gyroscope.Id = Component.getComponentId();
                gyroscope.Active = true;
                gyroscope.Name = "Gyroscope";
                gyroscope.Address = 0x68;
                gyroscope.ReadInterval = 200;
                components.Add(gyroscope);
                #endregion

                #region Sensors
                Component sensorGroup = new Component();
                sensorGroup.Id = Component.getComponentId();
                sensorGroup.Active = true;
                sensorGroup.Name = "Sensors";
                sensorGroup.setComponentType(typeof(Sensor));

                /*Humidity humidity1 = new Humidity();
                humidity1.Id = Component.getComponentId();
                humidity1.Active = true;
                humidity1.Name = "Humidity";
                humidity1.Pin = 22;
                humidity1.Minimum = 0.0f;
                humidity1.Maximum = 100.0f;
                humidity1.Slope = 1.0f;
                humidity1.Intercept = 0.0f;
                humidity1.Postfix = "%";
                humidity1.ReadInterval = 1000;
                humidity1.Logging = true;
                humidity1.LogCapacity = 4096;
                humidity1.LogInterval = 60000;
                sensorGroup.Components.Add(humidity1);*/

                Photoresistor photoresistor1 = new Photoresistor();
                photoresistor1.Id = Component.getComponentId();
                photoresistor1.Active = true;
                photoresistor1.Name = "Photoresistor";
                photoresistor1.Pin = 1;
                photoresistor1.Minimum = 0.0f;
                photoresistor1.Maximum = 100.0f;
                photoresistor1.Slope = -0.0976562f;
                photoresistor1.Intercept = 100.0f;
                photoresistor1.Postfix = "%";
                photoresistor1.ReadInterval = 500;
                photoresistor1.Logging = true;
                photoresistor1.LogCapacity = 4096;
                photoresistor1.LogInterval = 60000;
                sensorGroup.Components.Add(photoresistor1);

                Thermistor thermistor1 = new Thermistor();
                thermistor1.Id = Component.getComponentId();
                thermistor1.Active = true;
                thermistor1.Name = "Thermistor";
                thermistor1.Pin = 2;
                thermistor1.Minimum = -25.0f;
                thermistor1.Maximum = 125.0f;
                thermistor1.Slope = 1.0f;
                thermistor1.Intercept = 0.0f;
                thermistor1.Postfix = "°C";
                thermistor1.ReadInterval = 500;
                thermistor1.Logging = true;
                thermistor1.LogCapacity = 4096;
                thermistor1.LogInterval = 60000;
                sensorGroup.Components.Add(thermistor1);

                Sonar sonar1 = new Sonar();
                sonar1.Id = Component.getComponentId();
                sonar1.Active = true;
                sonar1.Name = "Sonar";
                sonar1.TriggerPin = 33;
                sonar1.EchoPin = 32;
                sonar1.Minimum = 0.0f;
                sonar1.Maximum = 250.0f;
                sonar1.Slope = 1.0f;
                sonar1.Intercept = 0.0f;
                sonar1.Postfix = "cm";
                sonar1.ReadInterval = 150;
                sonar1.Logging = false;
                sonar1.LogCapacity = 4096;
                sonar1.LogInterval = 1000;
                sensorGroup.Components.Add(sonar1);

                Sonar sonar2 = new Sonar();
                sonar2.Id = Component.getComponentId();
                sonar2.Active = true;
                sonar2.Name = "Sonar";
                sonar2.TriggerPin = 35;
                sonar2.EchoPin = 34;
                sonar2.Minimum = 0.0f;
                sonar2.Maximum = 250.0f;
                sonar2.Slope = 1.0f;
                sonar2.Intercept = 0.0f;
                sonar2.Postfix = "cm";
                sonar2.ReadInterval = 150;
                sonar2.Logging = false;
                sonar2.LogCapacity = 4096;
                sonar2.LogInterval = 1000;
                sensorGroup.Components.Add(sonar2);

                Sonar sonar3 = new Sonar();
                sonar3.Id = Component.getComponentId();
                sonar3.Active = true;
                sonar3.Name = "Sonar";
                sonar3.TriggerPin = 37;
                sonar3.EchoPin = 36;
                sonar3.Minimum = 0.0f;
                sonar3.Maximum = 250.0f;
                sonar3.Slope = 1.0f;
                sonar3.Intercept = 0.0f;
                sonar3.Postfix = "cm";
                sonar3.ReadInterval = 150;
                sonar3.Logging = false;
                sonar3.LogCapacity = 4096;
                sonar3.LogInterval = 1000;
                sensorGroup.Components.Add(sonar3);

                components.Add(sensorGroup);
                #endregion

                #region Servos
                Component servoGroup1 = new Component();
                servoGroup1.Id = Component.getComponentId();
                servoGroup1.Active = true;
                servoGroup1.Name = "Servos";
                servoGroup1.setComponentType(typeof(Servo));

                Servo servo11 = new Servo();
                servo11.Id = Component.getComponentId();
                servo11.Active = true;
                servo11.Name = "Servo";
                servo11.Pin = 0;
                servo11.Address = 0x40;
                servo11.Position = 50f;
                servo11.Time = 400;
                servo11.Minimum = 200;
                servo11.Maximum = 600;
                servo11.ViewAxisX = true;
                servoGroup1.Components.Add(servo11);

                Servo servo12 = new Servo();
                servo12.Id = Component.getComponentId();
                servo12.Active = true;
                servo12.Name = "Servo";
                servo12.Pin = 1;
                servo12.Address = 0x40;
                servo12.Position = 50f;
                servo12.Time = 400;
                servo12.Minimum = 200;
                servo12.Maximum = 600;
                servo12.ViewAxisY = true;
                servoGroup1.Components.Add(servo12);

                /*Servo servo13 = new Servo();
                servo13.Id = Component.getComponentId();
                servo13.Active = true;
                servo13.Name = "Servo";
                servo13.Pin = 2;
                servo13.Board = 0x40;
                servo13.Position = 50f;
                servo13.Time = 400;
                servo13.Minimum = 200;
                servo13.Maximum = 600;
                servo13.ViewAxisX = true;
                servoGroup1.Components.Add(servo13);

                Servo servo14 = new Servo();
                servo14.Id = Component.getComponentId();
                servo14.Active = true;
                servo14.Name = "Servo";
                servo14.Pin = 3;
                servo14.Board = 0x40;
                servo14.Position = 50f;
                servo14.Time = 400;
                servo14.Minimum = 200;
                servo14.Maximum = 600;
                servo14.ViewAxisY = true;
                servoGroup1.Components.Add(servo14);*/

                components.Add(servoGroup1);
                #endregion

                #endregion

                #endregion
            }
        }
        #endregion

        #region Properties
        public Identity Identity {
            get { return identity; }
            set { identity = value; }
        }

        public Arduino Arduino {
            get { return arduino; }
            set { arduino = value; }
        }

        public UdpNetworkServer UdpNetworkServer {
            get { return udpNetworkServer; }
            set { udpNetworkServer = value; }
        }

        public TcpNetworkServer TcpNetworkServer {
            get { return tcpNetworkServer; }
            set { tcpNetworkServer = value; }
        }

        public RtpNetworkServer RtpNetworkServer {
            get { return rtpNetworkServer; }
            set { rtpNetworkServer = value; }
        }

        public SpeechSyntheziser SpeechSyntheziser {
            get { return syntheziser; }
            set { syntheziser = value; }
        }

        public List<Component> Components {
            get { return components; }
            set { components = value; }
        }

        [XmlIgnore]
        public HwSystem System {
            get { return system; }
        }

        [XmlIgnore]
        public HwWiFi WiFi {
            get { return wifi; }
        }

        [XmlIgnore]
        public List<HwCamera> Cameras {
            get { return cameras; }
        }

        [XmlIgnore]
        public List<string> AtmelConsole {
            get { return atmelConsole; }
        }

        [XmlIgnore]
        public List<string> AgentConsole {
            get { return agentConsole; }
        }
        #endregion

        #region Functions
        private void initWiFiState() {
            #region Logbook
            Logger.Log(Level.INFO, "Initialize Network State ...");
            #endregion
            this.updateWiFiState();
        }

        public void updateWiFiState() {
            try { 
                // agent is connected by wifi
                foreach(WlanClient.WlanInterface ifcace in wlan.Interfaces) {
                    this.wifi = new HwWiFi(ifcace.CurrentConnection.wlanAssociationAttributes);
                    break;
                }
            } catch(Exception) {
                // agent is connected by cable
                this.wifi = new HwWiFi(true);
            }
        }

        private void initCameraDevices() {
            #region Logbook
            Logger.Log(Level.INFO, "Initialize Camera Devices ...");
            #endregion
            this.updateCameraDevices();
        }

        public void updateCameraDevices() {
            this.cameras.Clear();
            DsDevice[] devices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            for(int i = 0; i<devices.Length; i++) {
                HwCamera camera = new HwCamera(i, devices[i]);
                this.cameras.Add(camera);
            }
        }

        private void initArduinoDevice() {

            this.arduino.launch();
            this.arduino.startup(Globals.MAX_LOOP_TIME);

            this.arduino.onRoundTripUpdate += onRoundTripUpdate;
            this.arduino.onGpsUpdate += onGpsUpdate;
            this.arduino.onGyroscopeUpdate += onGyroscopeUpdate;
            this.arduino.onSensorUpdate += onSensorUpdate;
            this.arduino.onInfraredSignalUpdate += onInfraredSignalUpdate;
            
            Logger.onNewLineReported += onConsoleNewLine;
            this.arduino.onNewLineReported += onMonitorNewLine;

        }

        private void initSpeechSynthesizer() {
            #region Logbook
            Logger.Log(Level.INFO, "Initialize Speech Synthesizer ...");
            #endregion
        }

        private void initNetworkServices() {
            #region Logbook
            Logger.Log(Level.INFO, "Initialize Network Services:");
            #endregion
            udpNetworkServer.launch();
            tcpNetworkServer.launch();
            rtpNetworkServer.launch();
        }

        private void initHardwareComponents() {
            #region Logbook
            Logger.Log(Level.INFO, "Initialize Hardware Components ...");
            #endregion
            initHardwareComponents(components);
        }

        private void initHardwareComponents(List<Component> items) {
            foreach(Component item in items) {
                if(!item.isGroup()) {
                    try {
                        if(item is Camera) {
                            Camera camera = (Camera)item;
                            rtpNetworkServer.attachCamera(camera);
                        }
                        item.attach(arduino);
                        item.open();
                        #region Logbook
                        if(item.Active) {
                            Logger.Log(Level.INFO, " - Initialize Component "+item.ToString()+" ...");
                        }
                        #endregion
                    } catch(ComponentInitializationException ex) {
                        #region Logbook
                        Logger.Log(Level.WARNING, "Could not open "+item.GetType().ToString()+" component: "+ex.Message);
                        #endregion
                    }
                } else {
                    initHardwareComponents(item.Components);
                }
            }
        }

        private void closeHardwareComponents(List<Component> items) {
            foreach(Component item in items) {
                if(!item.isGroup()) {
                    if(item.Active) {
                        item.close();
                    }
                } else {
                    closeHardwareComponents(item.Components);
                }
            }
        }

        public HwCamera getCamera(int id) {
            foreach(HwCamera camera in cameras) {
                if(camera.Id == id) {
                    return camera;
                }
            }
            throw new CameraNotFoundException("Camera with ID="+id+" not found.");
        }

        public Type findComponentType(ushort componentId) {
            return findComponentType(componentId, components);
        }

        public Type findComponentType(ushort componentId, List<Component> items) {
            foreach(Component item in items) {
                if(item.Id == componentId) {
                    return item.GetType();
                } else if(item.isGroup()) {
                    if(item.Id == componentId) {
                        return item.GetType();
                    } else {
                        Type found = findComponentType(componentId, item.Components);
                        if(found!=null) {
                            return found;
                        }
                    }
                }
            }
            return null;
        }

        public T findComponent<T>(ushort componentId) where T : Component {
            return findComponent<T>(componentId, components);
        }

        private T findComponent<T>(ushort componentId, List<Component> items) where T : Component {
            foreach(Component item in items) {
                if(item.Id == componentId) {
                    return (T)item;
                } else if(item.isGroup()) {
                    if(item.Id == componentId) {
                        return (T)item;
                    } else {
                        T found = findComponent<T>(componentId, item.Components);
                        if(found!=null) {
                            return found;
                        }
                    }
                }
            }
            return null;
        }

        public List<T> findComponents<T>() where T : Component {
            List<T> result = new List<T>();
            findComponent<T>(result, components);
            return result;
        }

        private void findComponent<T>(List<T> result, List<Component> items) where T : Component {
            foreach(Component item in items) {
                if(item is T) {
                    result.Add((T)item);
                } else if(item.isGroup()) {
                    findComponent<T>(result, item.Components);
                }
            }
        }
        #endregion

        #region Network
        public void networkPacketReceived(NetworkPacket packet) {
            if(packet is RoundTripTime) {
                #region Calculate Round Trip Time
                RoundTripTime parcel = (RoundTripTime)packet;
                if(parcel.Partial) {
                    // do partial rtt measurement: remote<->agent
                    tcpNetworkServer.broadcast(parcel);
                } else {
                    // do full rtt measurement: remote<->agent<->arduino
                    roundTripTimePacket = parcel;
                    tRoundTripTime = Toolkit.CurrentTimeMillis();
                    arduino.measureRoundTripTime();
                }
                #endregion
            } else if(packet is UpdateComponent) {
                #region Update Hardware Component
                UpdateComponent parcel = (UpdateComponent)packet;
                Component component = findComponent<Component>(parcel.ComponentId);
                component.update(parcel.Component);
                #endregion
            } else if(packet is UpdateActionLibrary) {
                #region Update Action Library
                UpdateActionLibrary update = (UpdateActionLibrary)packet;
                Program.ActionLibrary = update.ActionLibrary;
                #endregion
            } else if(packet is SpeechActionCommand) {
                #region Execute Speech Action Command
                SpeechActionCommand cmd = (SpeechActionCommand)packet;
                Program.Controller.SpeechSyntheziser.speak(cmd.SpeechAction);
                #endregion
            } else if(packet is ServoActionCommand) {
                #region Execute Servo Action Command
                ServoActionCommand cmd = (ServoActionCommand)packet;
                ServoActionPlayer player = new ServoActionPlayer(arduino, cmd.ServoAction, findComponents<Servo>());
                player.play(cmd.ServoAction.Speed);
                #endregion
            } else if(packet is ServoPositionCommand) {
                #region Execute Servo Position Command
                ServoPositionCommand cmd = (ServoPositionCommand)packet;
                if(cmd.Position>=0) {
                    Servo servo = findComponent<Servo>(cmd.ComponentId);
                    if(servo!=null) servo.Position = cmd.Position;
                    arduino.setServoPosition(cmd.ComponentId, cmd.Pin, cmd.Board, cmd.Position);
                } else {
                    // value is not stored to the position field, since this is used for calibration only
                    arduino.setServoSignal(cmd.ComponentId, cmd.Pin, cmd.Board, cmd.Signal);
                }
                #endregion
            } else if(packet is ManagementCommand) {
                #region Execute Management Command
                ManagementCommand cmd = (ManagementCommand)packet;
                if(cmd.Restart) {
                    #region Logbook
                    Logger.Log(Level.INFO, "Going to restart agent ...");
                    #endregion
                    Process.Start("shutdown", "/r /f /t 0");
                } else if(cmd.Shutdown) {
                    #region Logbook
                    Logger.Log(Level.INFO, "Going to shutdown agent ...");
                    #endregion
                    Process.Start("shutdown", "/s /f /t 0");
                }
                #endregion
            } else {
                #region Logbook
                Logger.Log(Level.WARNING, "Unknown packet type received on TCP/RTP socket.");
                #endregion
            }
        }
        #endregion

        #region Callbacks
        private void onConsoleNewLine(string line) {
            // cache received output locally and send them with the initial system status
            agentConsole.Add(line);
            // as soon as the tcp connection has been established, begin to send the output
            // directly to the remote controller ...
            if(tcpNetworkServer.Launched) {
                ConsoleOutput packet = new ConsoleOutput(0);
                packet.Origin = false;
                packet.Line = line;
                tcpNetworkServer.broadcast(packet);
            }
        }

        private void onMonitorNewLine(string line) {
            // cache received output locally and send them with the initial system status
            atmelConsole.Add(line);
            // as soon as the tcp connection has been established, begin to send the output
            // directly to the remote controller ...
            if(tcpNetworkServer.Launched) {
                ConsoleOutput packet = new ConsoleOutput(0);
                packet.Origin = true;
                packet.Line = line;
                tcpNetworkServer.broadcast(packet);
            }
        }

        private void onRoundTripUpdate(int loopTime, short freeRam, int bytesSent, int bytesReceived) {
            // return round trip time packet to remote host(s)
            roundTripTimePacket.LoopTime = loopTime;
            roundTripTimePacket.FreeRam = freeRam;
            roundTripTimePacket.BytesSent = arduino.BytesSent;
            roundTripTimePacket.BytesReceived = arduino.BytesReceived;
            roundTripTimePacket.Rtt23 = (int)(Toolkit.CurrentTimeMillis()-tRoundTripTime);
            tcpNetworkServer.broadcast(roundTripTimePacket);
        }

        private void onGpsUpdate(ushort satellites, float latitude, float longitude, float altitude, float speed) {
            GPS gps = findComponents<GPS>()[0];
            gps.Satellites = satellites;
            gps.Latitude = latitude;
            gps.Longitude = longitude;
            gps.Altitude = altitude;
            gps.Speed = speed;
            // send gps update to remote host(s)
            UpdateComponent update = new UpdateComponent(gps.Id);
            update.Component = gps;
            tcpNetworkServer.broadcast(update);
        }

        private void onGyroscopeUpdate(short ax, short ay, short az, short gx, short gy, short gz) {
            Gyroscope gyroscope = findComponents<Gyroscope>()[0];
            gyroscope.AX = ax;
            gyroscope.AY = ay;
            gyroscope.AZ = az;
            gyroscope.GX = gx;
            gyroscope.GY = gy;
            gyroscope.GZ = gz;
            // send gps update to remote host(s)
            UpdateComponent update = new UpdateComponent(gyroscope.Id);
            update.Component = gyroscope;
            tcpNetworkServer.broadcast(update);
        }

        private void onSensorUpdate(ushort componentId, short value) {
            Type type = findComponentType(componentId);
            if(type==typeof(Battery)) {
                #region Update Battery Sensor
                Battery battery = findComponent<Battery>(componentId);
                battery.Data = battery.Slope*value-battery.Intercept;
                battery.Charging = battery.Data>battery.Maximum;
                // update battery log book
                battery.log();
                // send sensor value update to remote host(s)
                UpdateSensorValue update = new UpdateSensorValue(battery.Id);
                update.Data = battery.Data;
                tcpNetworkServer.broadcast(update);
                #endregion
            } else if(type==typeof(Thermistor)) {
                #region Update Thermistor Sensor
                // update component in model
                Thermistor thermistor = findComponent<Thermistor>(componentId);
                // convert the thermal stress value to resistance
                double media = 0.0;
                media = 1023.0 / value - 1;
                media = Globals.SERIESRESISTOR / media;
                // calculate temperature using the beta factor equation
                double temperature;
                temperature = media / Globals.TERMISTORNOMINAL;                 // (R/Ro)
                temperature = Math.Log(temperature);                            // ln(R/Ro)
                temperature /= Globals.BCOEFFICIENT;                            // 1/B * ln(R/Ro)
                temperature += 1.0 / (Globals.TEMPERATURENOMINAL + 273.15);     // + (1/To)
                temperature = 1.0 / temperature;                                // invert the value
                temperature -= 273.15;                                          // convert it to Celsius
                thermistor.Data = (float)temperature;
                // update temperature log book
                thermistor.log();
                // send sensor value update to remote host(s)
                UpdateSensorValue update = new UpdateSensorValue(thermistor.Id);
                update.Data = thermistor.Data;
                tcpNetworkServer.broadcast(update);
                #endregion
            } else if(type==typeof(Photoresistor)) {
                #region Update Photoresistor Sensor
                // update component in model
                Photoresistor photoresistor = findComponent<Photoresistor>(componentId);
                photoresistor.Data = photoresistor.Slope*value+photoresistor.Intercept;
                // update humidity log book
                photoresistor.log();
                // send sensor value update to remote host(s)
                UpdateSensorValue update = new UpdateSensorValue(photoresistor.Id);
                update.Data = photoresistor.Data;
                tcpNetworkServer.broadcast(update);
                #endregion
            } else if(type==typeof(Humidity)) {
                #region Update Humidity Sensor
                // update component in model
                Humidity humidity = findComponent<Humidity>(componentId);
                humidity.Data = humidity.Slope*value-humidity.Intercept;
                // update humidity log book
                humidity.log();
                // send sensor value update to remote host(s)
                UpdateSensorValue update = new UpdateSensorValue(humidity.Id);
                update.Data = humidity.Data;
                tcpNetworkServer.broadcast(update);
                #endregion
            } else if(type==typeof(Sonar)) {
                #region Update Sonar Sensor
                // update component in model
                Sonar sonar = findComponent<Sonar>(componentId);
                sonar.Data = value == -1 ? sonar.Maximum : sonar.Slope*value-sonar.Intercept;
                // send component update to remote host(s)
                UpdateSensorValue update = new UpdateSensorValue(sonar.Id);
                update.Data = sonar.Data;
                tcpNetworkServer.broadcast(update);
                #endregion
            }
        }

        private void onInfraredSignalUpdate(ushort signal, ushort bits) {
            // update component in model
            InfraredRx irRx = findComponents<InfraredRx>()[0];
            irRx.parse(signal);
            // send component update to remote host(s)
            UpdateComponent update = new UpdateComponent(irRx.Id);
            update.Component = irRx;
            tcpNetworkServer.broadcast(update);
        }
        #endregion

    }

}
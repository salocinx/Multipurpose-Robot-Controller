
#region Usings
using System;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public class Agent {

        #region Fields
        private bool initialized;

        private string name;
        private string systemId;
        private string revision;
        private long timestamp;
        private IPAddress address;

        private volatile bool ackFullRtt;
        private volatile bool ackPartialRtt;

        private HwWiFi wifi;
        private HwSystem system;
        private Arduino arduino;
        private List<HwCamera> cameras;
        private List<Component> components;
        private ActionLibrary actionLibrary;

        private List<string> atmelConsole;
        private List<string> agentConsole;

        private TcpNetworkClient tcpNetworkClient;
        private RtpNetworkClient rtpNetworkClient;
        #endregion

        #region View
        private TabControl tabControl;
        private SpeechSynthesizerTool speechSynthesizerTool;
        private ServoActionLibraryTool servoActionLibraryTool;
        private volatile List<Form> openWindows = new List<Form>();
        private volatile List<iLocalUpdate> subscribers = new List<iLocalUpdate>();
        #endregion

        #region Events
        public event OnSystemStatusPacketReceived onSystemStatusPacketReceived;
        public event OnConsoleOutputPacketReceived onConsoleOutputPacketReceived;
        public event OnRoundTripTimePackedReceived onRoundTripTimePackedReceived;
        public event OnNetworkStatusPacketReceived onNetworkStatusPacketReceived;
        public event OnCameraImagePacketReceived onCameraImagePacketReceived;
        #endregion

        #region Threads
        private Thread rttThread;
        private volatile bool measuring = true;
        private readonly object measuringLock = new object();
        #endregion

        #region Lifecycle
        public Agent(BeaconSignal packet) {
            // cache relevant properties
            this.name = packet.Name;
            this.systemId = packet.SystemId;
            this.revision = packet.Revision;
            this.address = IPAddress.Parse(packet.Address);
            this.timestamp = Toolkit.CurrentTimeMillis();
            // initialize round trip measurements
            this.rttThread = new Thread(measureRoundTripTime);
            this.rttThread.Start();
        }
        #endregion

        #region Operators
        public static bool operator == (Agent agent1, Agent agent2) {
            // if both are null, or both are same instance
            if(ReferenceEquals(agent1, agent2)) {
                return true;
            }
            // if one is null, but not both
            if(((object)agent1 == null) || ((object)agent2 == null)) {
                return false;
            }
            // return true if fields match
            return agent1.SystemId.Equals(agent2.SystemId);
        }

        public static bool operator != (Agent agent1, Agent agent2) {
            return !(agent1 == agent2);
        }

        public override bool Equals(Object obj) {
            // if parameter is null return false
            if(obj == null) return false;
            // if parameter cannot be cast to Agent return false
            Agent agent = obj as Agent;
            if((Object)agent == null) return false;
            // return true if the fields match
            return systemId == agent.SystemId;
        }

        public bool Equals(Agent agent) {
            // if parameter is null return false
            if((object)agent == null) return false;
            // return true if the fields match
            return systemId == agent.SystemId;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
        #endregion

        #region Properties
        public bool Initialized {
            get { return initialized; }
            set { initialized = value; }
        }

        public bool Connected {
            get { return tcpNetworkClient!=null; }
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }
        public string SystemId {
            get { return systemId; }
            set { systemId = value; }
        }

        public string Revision {
            get { return revision; }
            set { revision = value; }
        }

        public long Timestamp {
            get { return timestamp; }
            set { timestamp = value; }
        }

        public IPAddress Address {
            get { return address; }
            set { address = value; }
        }

        public HwWiFi WiFi {
            get { return wifi; }
            set { wifi = value; }
        }

        public HwSystem System {
            get { return system; }
            set { system = value; }
        }

        public Arduino Arduino {
            get { return arduino; }
            set { arduino = value; }
        }

        public List<HwCamera> Cameras {
            get { return cameras; }
            set { cameras = value; }
        }

        public List<Component> Components {
            get { return components; }
            set { components = value; }
        }

        public ActionLibrary ActionLibrary {
            get { return actionLibrary; }
            set { actionLibrary = value; }
        }

        public List<string> AtmelConsole {
            get { return atmelConsole; }
        }

        public List<string> AgentConsole {
            get { return agentConsole; }
        }

        public TcpNetworkClient TcpNetworkClient {
            get { return tcpNetworkClient; }
        }

        public RtpNetworkClient RtpNetworkClient {
            get { return rtpNetworkClient; }
        }

        public TabControl TabControl {
            get { return tabControl; }
            set { tabControl = value; }
        }

        public SpeechSynthesizerTool SpeechSynthesizerTool {
            get { return speechSynthesizerTool; }
            set { speechSynthesizerTool = value; }
        }

        public ServoActionLibraryTool ServoActionLibraryTool {
            get { return servoActionLibraryTool; }
            set { servoActionLibraryTool = value; }
        }
        #endregion

        #region Functions
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

        public HwCamera findHardwareCamera(int index) {
            foreach(HwCamera camera in cameras) {
                if(camera.Id == index) {
                    return camera;
                }
            }
            throw new HardwareCameraNotFoundException(index);
        }

        public void terminate() {
            measuring = false;
            lock(measuringLock) {
                Monitor.Pulse(measuringLock);
            }
        }
        #endregion

        #region Network
        public void connect() {
            if(tcpNetworkClient==null) {
                tcpNetworkClient = new TcpNetworkClient(this);
                tcpNetworkClient.connect(address, Globals.NETWORK_TCP_PORT);
                tcpNetworkClient.onNetworkPacketReceived += networkPacketReceived;
            }
            if(rtpNetworkClient==null) {
                rtpNetworkClient = new RtpNetworkClient(this);
                rtpNetworkClient.connect(address, Globals.NETWORK_RTP_PORT);
                rtpNetworkClient.onNetworkPacketReceived += networkPacketReceived;
            }
        }

        public void disconnect() {
            if(tcpNetworkClient != null) {
                tcpNetworkClient.onNetworkPacketReceived -= networkPacketReceived;
                tcpNetworkClient.disconnect();
                tcpNetworkClient = null;
            }
            if(rtpNetworkClient != null) {
                rtpNetworkClient.onNetworkPacketReceived -= networkPacketReceived;
                rtpNetworkClient.disconnect();
                rtpNetworkClient = null;
            }
        }

        public void restart() {
            if(tcpNetworkClient != null) {
                ManagementCommand cmd = new ManagementCommand(0);
                cmd.Restart = true;
                tcpNetworkClient.send(cmd);
            }
        }

        public void shutdown() {
            if(tcpNetworkClient != null) {
                ManagementCommand cmd = new ManagementCommand(0);
                cmd.Shutdown = true;
                tcpNetworkClient.send(cmd);
            }
        }

        public void networkPacketReceived(NetworkPacket packet) {
            if(packet is SystemStatus) {
                #region Initialize Remote Agent
                SystemStatus parcel = (SystemStatus)packet;
                // update internal agent's state
                this.wifi = parcel.WiFi;
                this.system = parcel.System;
                this.arduino = parcel.Arduino;
                this.cameras = parcel.Cameras;
                this.components = parcel.Components;
                this.actionLibrary = parcel.ActionLibrary;
                this.atmelConsole = parcel.AtmelConsole;
                this.agentConsole = parcel.AgentConsole;
                this.initialized = true;
                // inform subscribers about update
                onSystemStatusPacketReceived?.Invoke(parcel);
                #endregion
            } else if(packet is ConsoleOutput) {
                #region Append Console Output
                if(initialized) {
                    ConsoleOutput parcel = (ConsoleOutput)packet;
                    onConsoleOutputPacketReceived?.Invoke(parcel);
                }
                #endregion
            } else if(packet is RoundTripTime) {
                #region Update Round Trip Time
                if(initialized) {
                    RoundTripTime parcel = (RoundTripTime)packet;
                    if(parcel.Partial) {
                        parcel.Rtt12 = (int)(Toolkit.CurrentTimeMillis()-parcel.StartTime);
                        ackPartialRtt = true;
                        onRoundTripTimePackedReceived?.Invoke(parcel);
                    } else {
                        parcel.Rtt13 = (int)(Toolkit.CurrentTimeMillis()-parcel.StartTime);
                        ackFullRtt = true;
                        onRoundTripTimePackedReceived?.Invoke(parcel);
                    }
                    onRoundTripTimePackedReceived?.Invoke(parcel);
                }
                #endregion
            } else if(packet is NetworkStatus) {
                #region Update Remote Network State Only
                if(initialized) {
                    NetworkStatus parcel = (NetworkStatus)packet;
                    // update internal agent's state
                    this.wifi = parcel.WiFi;
                    // inform subscribers about update
                    onNetworkStatusPacketReceived?.Invoke(parcel);
                }
                #endregion
            } else if(packet is UpdateComponent) {
                #region Update Remote Component
                if(initialized) {
                    UpdateComponent update = (UpdateComponent)packet;
                    Component component = findComponent<Component>(update.ComponentId);
                    component.update(update.Component);
                    this.doLocalUpdate(component);
                }
                #endregion
            } else if(packet is UpdateSensorValue) {
                #region Update Sensor Value
                if(initialized) {
                    UpdateSensorValue parcel = (UpdateSensorValue)packet;
                    Sensor sensor = findComponent<Sensor>(parcel.ComponentId);
                    sensor.Data = parcel.Data;
                    sensor.log();
                    this.doLocalUpdate(sensor);
                }
                #endregion
            } else if(packet is CameraImage) {
                #region Forward Camera Image to Gui
                if(initialized) {
                    CameraImage image = (CameraImage)packet;
                    // find camera component for statistics update
                    Camera camera = findComponent<Camera>(image.ComponentId);
                    camera.FramesReceived++;
                    camera.BytesReceived += image.CompressedImageSize;
                    // inform subscribers about update directly
                    onCameraImagePacketReceived?.Invoke(image);
                }
                #endregion
            } else {
                #region Logbook
                Logger.Log(Level.WARNING, "Unknown packet type received on TCP/RTP socket.");
                #endregion
            }
        }
        #endregion

        #region View

        #region Controller
        public void createView() {
            createTabCtrl();
            createPanels();
            createTools();
        }

        private void createTabCtrl() {
            this.tabControl = new TabControl();
            this.tabControl.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right);
            this.tabControl.Location = new Point(0, 0);
            this.tabControl.Name = "tabCtrl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new Size(854, 530);
            this.tabControl.TabIndex = 7;
        }

        private void createPanels() {
            // add general panel
            TabPage generalPage = new TabPage("General");
            GeneralPanel generalPanel = new GeneralPanel(this);
            generalPage.Controls.Add(generalPanel);
            tabControl.TabPages.Add(generalPage);
            // add system panel
            TabPage systemPage = new TabPage("System");
            SystemPanel systemPanel = new SystemPanel(this);
            systemPage.Controls.Add(systemPanel);
            tabControl.TabPages.Add(systemPage);
            // add console panel
            TabPage consolePage = new TabPage("Consoles");
            ConsolePanel consolePanel = new ConsolePanel(this);
            consolePage.Controls.Add(consolePanel);
            tabControl.TabPages.Add(consolePage);
            // add component panels
            foreach(Component component in components) {
                if(component.Active) {
                    if(component is GPS) {
                        TabPage page = new TabPage(component.Name);
                        GpsPanel panel = new GpsPanel(this, (GPS)component);
                        page.Controls.Add(panel);
                        tabControl.TabPages.Add(page);
                    } else if(component is Gyroscope) {
                        TabPage page = new TabPage(component.Name);
                        GyroscopePanel panel = new GyroscopePanel(this, (Gyroscope)component);
                        page.Controls.Add(panel);
                        tabControl.TabPages.Add(page);
                    } else if(component is CameraMono) {
                        TabPage page = new TabPage(component.Name);
                        CameraPanel panel = new CameraPanel(this, (CameraMono)component);
                        page.Controls.Add(panel);
                        tabControl.TabPages.Add(page);
                    } else if(component is CameraStereo) {
                        TabPage page = new TabPage(component.Name);
                        CameraPanel panel = new CameraPanel(this, (CameraStereo)component);
                        page.Controls.Add(panel);
                        tabControl.TabPages.Add(page);
                    } else if(component.isGroup()) {
                        if(component.getComponentType() == typeof(Infrared)) {
                            TabPage page = new TabPage(component.Name);
                            InfraredPanel panel = new InfraredPanel(this, component);
                            page.Controls.Add(panel);
                            tabControl.TabPages.Add(page);
                        } else if(component.getComponentType() == typeof(Sensor)) {
                            TabPage page = new TabPage(component.Name);
                            SensorPanel panel = new SensorPanel(this, component);
                            page.Controls.Add(panel);
                            tabControl.TabPages.Add(page);
                        } else if(component.getComponentType() == typeof(Servo)) {
                            TabPage page = new TabPage(component.Name);
                            ServoPanel panel = new ServoPanel(this, component);
                            page.Controls.Add(panel);
                            tabControl.TabPages.Add(page);
                        }
                    }
                }
            }
        }

        private void createTools() {
            // initialize speech synthesizer tool
            speechSynthesizerTool = new SpeechSynthesizerTool(this);
            // initialize servo action manipulation tool
            servoActionLibraryTool = new ServoActionLibraryTool(this);
        }
        #endregion

        #region Local Update
        public void subscribeLocalUpdate(iLocalUpdate gui) {
            if(!subscribers.Contains(gui)) {
                subscribers.Add(gui);
            }
        }

        public void unsubscribeLocalUpdate(iLocalUpdate gui) {
            subscribers.Remove(gui);
        }

        public void doLocalUpdate(iComponent update) {
            for(int i = 0; i<subscribers.Count; i++) {
                if(subscribers[i].getInterest()!=null) {
                    // update controls with single dependency
                    if(subscribers[i].getInterest() == update) {
                        subscribers[i].onLocalUpdate();
                    }
                } else if(subscribers[i].getInterests()!=null) {
                    // update controls with multiple dependencies
                    for(int j = 0; j<subscribers[i].getInterests().Count; j++) {
                        if(subscribers[i].getInterests()[j] == update) {
                            subscribers[i].onLocalUpdate();
                        }
                    }
                }
            }
        }
        #endregion

        #region Window Handling
        public void registerWindow(Form form) {
            if(!openWindows.Contains(form)) {
                openWindows.Add(form);
            }
        }

        public void closeWindows() {
            // close visible windows
            foreach(Form window in openWindows) {
                if(window.Visible) {
                    window.Close();
                }
            }
            // close additional tool windows
            if(speechSynthesizerTool.Visible) {
                speechSynthesizerTool.Close();
            }
            if(servoActionLibraryTool.Visible) {
                servoActionLibraryTool.Close();
            }
        }
        #endregion

        #endregion

        #region Threading
        private void measureRoundTripTime() {
            // wait until everything is set up correctly
            Thread.Sleep(5000);
            // start measuring round trip times and connectivity
            while(measuring) {
                // check if previous pings timed-out
                RoundTripTime packet = new RoundTripTime(0);
                packet.Indicator = true;
                if(ackPartialRtt && !ackFullRtt) {
                    packet.Connectivity12 = true;
                    packet.Connectivity13 = false;
                } else if(!ackPartialRtt && !ackFullRtt) {
                    packet.Connectivity12 = false;
                    packet.Connectivity13 = false;
                } else {
                    packet.Connectivity12 = true;
                    packet.Connectivity13 = true;
                }
                onRoundTripTimePackedReceived?.Invoke(packet);
                // send partial and complete round trip requests
                if(tcpNetworkClient!=null) {
                    // send partial round trip time measurement
                    RoundTripTime packet1 = new RoundTripTime(0);
                    packet1.Partial = true;
                    packet1.StartTime = Toolkit.CurrentTimeMillis();
                    tcpNetworkClient.send(packet1);
                    ackPartialRtt = false;
                    // send complete round trip time measurement
                    RoundTripTime packet2 = new RoundTripTime(0);
                    packet2.Partial = false;
                    packet2.StartTime = Toolkit.CurrentTimeMillis();
                    tcpNetworkClient.send(packet2);
                    ackFullRtt = false;
                }
                // wait for some seconds
                lock(measuringLock) {
                    Monitor.Wait(measuringLock, TimeSpan.FromSeconds(2));
                }
            }
        }
        #endregion

    }

}
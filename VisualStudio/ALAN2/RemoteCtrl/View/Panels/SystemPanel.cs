
#region Usings
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public partial class SystemPanel : UserControl, iLocalUpdate {

        #region Fields
        private Agent agent;
        private Battery battery;
        private Dictionary<Sensor, SensorWindow> logbooks = new Dictionary<Sensor, SensorWindow>();
        #endregion

        #region Constants
        private int EMPTY_RESOURCE;
        private int EMPTY_COMPONENT;
        #endregion

        #region Lifecycle
        public SystemPanel(Agent agent) {
            this.agent = agent;
            avoidViewFlickering();
            InitializeComponent();
            initializeGui();
            agent.onNetworkStatusPacketReceived += onNetworkStatusPacketReceived;
            agent.subscribeLocalUpdate(this);
        }

        private void avoidViewFlickering() {
            int style = NativeWinAPI.GetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE);
            style |= NativeWinAPI.WS_EX_COMPOSITE;
            NativeWinAPI.SetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE, style);
        }

        private void initializeGui() {
            this.UIThreadInvoke(delegate {
                this.styleResourcesTreeView();
                this.styleComponentsTreeView();
                this.initializeResourceTree();
                this.initializeComponentTree();
                this.initializeLocalUpdate();
            });
        }

        private void styleResourcesTreeView() {
            treResources.HideSelection = false;
            treResources.FullRowSelect = true;
            ImageList icons = new ImageList();
            icons.ImageSize = new Size(24, 24);
            icons.Images.Add((Image)Properties.Resources.ResourceManager.GetObject("os_win_24"));
            icons.Images.Add((Image)Properties.Resources.ResourceManager.GetObject("cpu_24"));
            icons.Images.Add((Image)Properties.Resources.ResourceManager.GetObject("gpu_24"));
            icons.Images.Add((Image)Properties.Resources.ResourceManager.GetObject("hdd_24"));
            icons.Images.Add((Image)Properties.Resources.ResourceManager.GetObject("dashes_24"));
            treResources.ImageList = icons;
            EMPTY_RESOURCE = icons.Images.Count-1;
        }

        private void styleComponentsTreeView() {
            treComponents.HideSelection = false;
            treComponents.FullRowSelect = true;
            ImageList icons = new ImageList();
            icons.ImageSize = new Size(24, 24);
            icons.Images.Add((Image)Properties.Resources.ResourceManager.GetObject("unknown_24"));
            icons.Images.Add((Image)Properties.Resources.ResourceManager.GetObject("sensor_24"));
            icons.Images.Add((Image)Properties.Resources.ResourceManager.GetObject("battery_24"));
            icons.Images.Add((Image)Properties.Resources.ResourceManager.GetObject("cam_24"));
            icons.Images.Add((Image)Properties.Resources.ResourceManager.GetObject("gps_24"));
            icons.Images.Add((Image)Properties.Resources.ResourceManager.GetObject("sonar_24"));
            icons.Images.Add((Image)Properties.Resources.ResourceManager.GetObject("light_24"));
            icons.Images.Add((Image)Properties.Resources.ResourceManager.GetObject("humidity_24"));
            icons.Images.Add((Image)Properties.Resources.ResourceManager.GetObject("temperature_24"));
            icons.Images.Add((Image)Properties.Resources.ResourceManager.GetObject("servo_24"));
            icons.Images.Add((Image)Properties.Resources.ResourceManager.GetObject("infrared_24"));
            icons.Images.Add((Image)Properties.Resources.ResourceManager.GetObject("gyro_24"));
            treComponents.ImageList = icons;
            EMPTY_COMPONENT = icons.Images.Count-1;
        }

        private void initializeResourceTree() {
            try {

                treResources.BeginUpdate();
                treResources.Nodes.Clear();

                TreeNode node_os = new TreeNode("Operating System (OS)", 0, 0);
                node_os.Nodes.Add(agent.System.OperatingSystem);

                TreeNode node_cpus = new TreeNode("Central Processing Units (CPUs)", 1, 1);
                node_cpus.ImageIndex = 1;
                List<HwCpu> cpus = agent.System.CPUs;
                for(int i = 0; i<cpus.Count; i++) {
                    node_cpus.Nodes.Add("", cpus[i].Description, 1, 1);
                    node_cpus.Nodes[i].Nodes.Add("", "Processors: "+cpus[i].ProcessorCount, EMPTY_RESOURCE, EMPTY_RESOURCE);
                    node_cpus.Nodes[i].Nodes.Add("", "Architecture: "+cpus[i].Architecture+" bit", EMPTY_RESOURCE, EMPTY_RESOURCE);
                    node_cpus.Nodes[i].Nodes.Add("", "Current Clock Speed: "+cpus[i].CurrentClockSpeed+" MHz", EMPTY_RESOURCE, EMPTY_RESOURCE);
                    node_cpus.Nodes[i].Nodes.Add("", "Maximum Clock Speed: "+cpus[i].MaxClockSpeed+" MHz", EMPTY_RESOURCE, EMPTY_RESOURCE);
                    node_cpus.Nodes[i].Nodes.Add("", "CPU Data Width: "+cpus[i].DataWidth, EMPTY_RESOURCE, EMPTY_RESOURCE);
                    node_cpus.Nodes[i].Nodes.Add("", "CPU Address Width: "+cpus[i].AddressWidth, EMPTY_RESOURCE, EMPTY_RESOURCE);
                }

                TreeNode node_gpus = new TreeNode("Graphics Processing Units (GPUs)", 2, 2);
                node_gpus.ImageIndex = 2;
                List<HwGpu> gpus = agent.System.GPUs;
                for(int i = 0; i<gpus.Count; i++) {
                    node_gpus.Nodes.Add("", gpus[i].Description, 2, 2);
                    node_gpus.Nodes[i].Nodes.Add("", "Type: "+gpus[i].Type, EMPTY_RESOURCE, EMPTY_RESOURCE);
                    node_gpus.Nodes[i].Nodes.Add("", "RAM: "+(gpus[i].Ram/1024/1024)+" MB", EMPTY_RESOURCE, EMPTY_RESOURCE);
                    node_gpus.Nodes[i].Nodes.Add("", "Mode: "+gpus[i].VideoMode, EMPTY_RESOURCE, EMPTY_RESOURCE);
                }

                TreeNode node_disks = new TreeNode("Logical Disk Drives (HDD/CD)", 3, 3);
                node_disks.ImageIndex = 3;
                List<HwDisk> disks = agent.System.Disks;
                for(int i = 0; i<disks.Count; i++) {
                    node_disks.Nodes.Add("", disks[i].Description, 3, 3);
                    node_disks.Nodes[i].Nodes.Add("", "Volume Name: "+disks[i].VolumeName, EMPTY_RESOURCE, EMPTY_RESOURCE);
                    node_disks.Nodes[i].Nodes.Add("", "Volume Serial: "+disks[i].VolumeSerialNumber, EMPTY_RESOURCE, EMPTY_RESOURCE);
                    node_disks.Nodes[i].Nodes.Add("", "File System: "+disks[i].FileSystem, EMPTY_RESOURCE, EMPTY_RESOURCE);
                    node_disks.Nodes[i].Nodes.Add("", "Entire Space: "+(disks[i].Size/1024/1024)+" MB", EMPTY_RESOURCE, EMPTY_RESOURCE);
                    node_disks.Nodes[i].Nodes.Add("", "Free Space: "+(disks[i].FreeSpace/1024/1024)+" MB", EMPTY_RESOURCE, EMPTY_RESOURCE);
                }

                treResources.Nodes.Add(node_os);
                treResources.Nodes.Add(node_cpus);
                treResources.Nodes.Add(node_gpus);
                treResources.Nodes.Add(node_disks);

                // expand first level nodes
                for(int i=0; i<treResources.Nodes.Count-1; i++) {
                    treResources.Nodes[i].Expand();
                }

            } finally {
                treResources.EndUpdate();
            }
        }

        private void initializeComponentTree() {
            try {
                treComponents.BeginUpdate();
                treComponents.Nodes.Clear();
                createComponentTreeEntry(agent.Components, null, treComponents);
            } finally {
                treComponents.EndUpdate();
            }
        }

        private int getImageIndex(Component component) {
            if(component.getComponentType() == typeof(Sensor)) {
                return 1;
            } else if(component.getComponentType() == typeof(Battery)) {
                return 2;
            } else if(component.getComponentType() == typeof(Camera) || component.getComponentType() == typeof(CameraMono) || component.getComponentType() == typeof(CameraStereo)) {
                return 3;
            } else if(component.getComponentType() == typeof(GPS)) {
                return 4;
            } else if(component.getComponentType() == typeof(Sonar)) {
                return 5;
            } else if(component.getComponentType() == typeof(Photoresistor)) {
                return 6;
            } else if(component.getComponentType() == typeof(Humidity)) {
                return 7;
            } else if(component.getComponentType() == typeof(Thermistor)) {
                return 8;
            } else if(component.getComponentType() == typeof(Servo)) {
                return 9;
            } else if(component.getComponentType() == typeof(Infrared) || component.getComponentType() == typeof(InfraredRx) || component.getComponentType() == typeof(InfraredTx)) {
                return 10;
            } else if(component.getComponentType() == typeof(Gyroscope)) {
                return 11;
            } else {
                return 0;
            }
        }

        private void createComponentTreeEntry(List<Component> items, TreeNode parent, TreeView tree) {
            foreach(Component item in items) {
                if(item.Active) {
                    if(item.isGroup()) {
                        // create group node
                        int img_index = getImageIndex(item);
                        TreeNode node = new TreeNode(item.ToString(), img_index, img_index);
                        node.Tag = item;
                        if(parent==null) {
                            tree.Nodes.Add(node);
                        } else {
                            parent.Nodes.Add(node);
                        }
                        // dig deeper into the tree
                        createComponentTreeEntry(item.Components, node, tree);
                    } else {
                        // create single node
                        int img_index = getImageIndex(item);
                        TreeNode node = new TreeNode(item.ToString(), img_index, img_index);
                        node.Tag = item;
                        if(parent==null) {
                            tree.Nodes.Add(node);
                        } else {
                            parent.Nodes.Add(node);
                        }
                    }
                }
            }
        }
        #endregion

        #region Functions
        public void onNetworkStatusPacketReceived(NetworkStatus packet) {
            this.UIThreadInvoke(delegate {
                HwWiFi wifi = packet.WiFi;
                if(wifi.LAN) {
                    this.txtWifiSsid.Text = "SSID: Local Area Network (LAN)";
                    this.txtWifiTxRate.Text = "TX-Rate: 100/1000 mbps";
                    this.txtWifiRxRate.Text = "RX-Rate: 100/1000 mbps";
                    #region Set Signal Strength Image
                    this.imgWiFi.Image = Properties.Resources.lan_24;
                    #endregion
                } else {
                    this.txtWifiSsid.Text = "SSID: "+wifi.SSID;
                    this.txtWifiTxRate.Text = "TX-Rate: "+(wifi.TxRate/1000)+" mbps";
                    this.txtWifiRxRate.Text = "RX-Rate: "+(wifi.RxRate/1000)+" mbps";
                    #region Set Signal Strength Image
                    if(wifi.SignalQuality<=0) {
                        this.imgWiFi.Image = Properties.Resources.WiFi_0;
                    } else if(wifi.SignalQuality>0 && wifi.SignalQuality<20) {
                        this.imgWiFi.Image = Properties.Resources.WiFi_1;
                    } else if(wifi.SignalQuality>=20 && wifi.SignalQuality<40) {
                        this.imgWiFi.Image = Properties.Resources.WiFi_2;
                    } else if(wifi.SignalQuality>=40 && wifi.SignalQuality<60) {
                        this.imgWiFi.Image = Properties.Resources.WiFi_3;
                    } else if(wifi.SignalQuality>=60 && wifi.SignalQuality<80) {
                        this.imgWiFi.Image = Properties.Resources.WiFi_4;
                    } else if(wifi.SignalQuality>=80) {
                        this.imgWiFi.Image = Properties.Resources.WiFi_5;
                    } else {
                        this.imgWiFi.Image = Properties.Resources.WiFi_0;
                    }
                    #endregion
                }
            });
        }

        private void configureComponent(Component component) {
            if(!component.isGroup()) {
                if(component is Battery) {
                    Battery battery = (Battery)component;
                    BatteryConfigWindow config = new BatteryConfigWindow(agent, battery);
                    config.ShowDialog();
                } else if(component is Camera) {
                    Camera camera = (Camera)component;
                    CameraConfigWindow config = new CameraConfigWindow(agent, camera);
                    config.ShowDialog();
                } else if(component is GPS) {
                    GPS gps = (GPS)component;
                    GpsConfigWindow config = new GpsConfigWindow(agent, gps);
                    config.ShowDialog();
                } else if(component is Gyroscope) {
                    Gyroscope gyroscope = (Gyroscope)component;
                    GyroscopeConfigWindow config = new GyroscopeConfigWindow(agent, gyroscope);
                    config.ShowDialog();
                } else if(component is InfraredRx) {
                    InfraredRx infrared = (InfraredRx)component;
                    InfraredRxConfigWindow config = new InfraredRxConfigWindow(agent, infrared);
                    config.ShowDialog();
                } else if(component is InfraredTx) {
                    InfraredTx infrared = (InfraredTx)component;
                    InfraredTxConfigWindow config = new InfraredTxConfigWindow(agent, infrared);
                    config.ShowDialog();
                } else if(component is Sonar) {
                    Sonar sonar = (Sonar)component;
                    SonarConfigWindow config = new SonarConfigWindow(agent, sonar);
                    config.ShowDialog();
                } else if(component is Humidity) {
                    Humidity humidity = (Humidity)component;
                    HumidityConfigWindow config = new HumidityConfigWindow(agent, humidity);
                    config.ShowDialog();
                } else if(component is Thermistor) {
                    Thermistor thermistor = (Thermistor)component;
                    ThermistorConfigWindow config = new ThermistorConfigWindow(agent, thermistor);
                    config.ShowDialog();
                } else if(component is Photoresistor) {
                    Photoresistor photoresistor = (Photoresistor)component;
                    PhotoresistorConfigWindow config = new PhotoresistorConfigWindow(agent, photoresistor);
                    config.ShowDialog();
                } else if(component is Servo) {
                    Servo servo = (Servo)component;
                    ServoConfigWindow config = new ServoConfigWindow(agent, servo);
                    config.ShowDialog();
                }
            }
        }

        private void showLogbook(Component component) {
            if(component is Sensor) {
                SensorWindow window = null;
                Sensor sensor = (Sensor)component;
                try {
                    window = logbooks[sensor];
                } catch(KeyNotFoundException) {
                    window = new SensorWindow(agent, sensor);
                    logbooks[sensor] = window;
                }
                window.Show();
            }
        }
        #endregion

        #region Local Update
        public void initializeLocalUpdate() {
            List<Battery> batteries = agent.findComponents<Battery>();
            if(batteries.Count>0) {
                battery = batteries[0];
                onLocalUpdate();
            }
        }

        public iComponent getInterest() {
            return battery;
        }

        public List<iComponent> getInterests() {
            return null;
        }

        public void onLocalUpdate() {
            this.UIThreadInvoke(delegate {
                if(battery!=null) {
                    txtBatteryState.Text = "Current Voltage: "+battery.Data.ToString("0.00")+" [V]";
                    pgsBatteryState.Minimum = 0;
                    pgsBatteryState.Maximum = (int)(battery.Maximum*10f);
                    pgsBatteryState.Value = Toolkit.clamp((int)(battery.Data*10f), 0, (int)(battery.Maximum*10f));
                    #region Set Battery Icon
                    if(battery.Data<battery.State[0]) {
                        imgBatteryState.Image = Properties.Resources.battery_0;
                    } else if(battery.Data>=battery.State[0] && battery.Data<battery.State[1]) {
                        imgBatteryState.Image = Properties.Resources.battery_1;
                    } else if(battery.Data>=battery.State[1] && battery.Data<battery.State[2]) {
                        imgBatteryState.Image = Properties.Resources.battery_2;
                    } else if(battery.Data>=battery.State[2] && battery.Data<battery.State[3]) {
                        imgBatteryState.Image = Properties.Resources.battery_3;
                    } else if(battery.Data>=battery.State[3] && battery.Data<battery.State[4]) {
                        imgBatteryState.Image = Properties.Resources.battery_4;
                    } else if(battery.Data>=battery.State[4] && battery.Data<battery.Maximum) {
                        imgBatteryState.Image = Properties.Resources.battery_5;
                    } else {
                        imgBatteryState.Image = Properties.Resources.battery_6;
                    }
                    #endregion
                } else {
                    txtBatteryState.Text = "Current Voltage: n/a [V]";
                    pgsBatteryState.Value = 0;
                    imgBatteryState.Image = Properties.Resources.battery_x;
                }
            });
        }
        #endregion

        #region Event-Handling
        /* This is an overload instead of attaching the Load(*) event manually.
         * Just copy and paste this code to other user-control classes. */
        protected override void OnLoad(EventArgs evt) {
            this.AutoSize = false;
            this.Dock = DockStyle.Fill;
            base.OnLoad(evt);
        }

        private void itmConfigure_Click(object sender, EventArgs evt) {
            Component component = (Component)treComponents.SelectedNode.Tag;
            this.configureComponent(component);
        }

        private void itmLogbook_Click(object sender, EventArgs evt) {
            Component component = (Component)treComponents.SelectedNode.Tag;
            this.showLogbook(component);
        }

        private void treComponents_MouseClick(object sender, MouseEventArgs evt) {
            if(evt.Button == MouseButtons.Right) {
                if(treComponents.SelectedNode!=null) {
                    Component component = (Component)treComponents.SelectedNode.Tag;
                    if(component is Sensor) {
                        Sensor sensor = (Sensor)component;
                        ctxComponents.Items[0].Enabled = true;
                        ctxComponents.Items[1].Enabled = sensor.Logging;
                    } else if(component is Actuator) {
                        ctxComponents.Items[0].Enabled = true;
                        ctxComponents.Items[1].Enabled = false;
                    } else if(component is Camera) {
                        ctxComponents.Items[0].Enabled = true;
                        ctxComponents.Items[1].Enabled = false;
                    } else if(component is GPS) {
                        ctxComponents.Items[0].Enabled = true;
                        ctxComponents.Items[1].Enabled = false;
                    } else if(component is Gyroscope) {
                        ctxComponents.Items[0].Enabled = true;
                        ctxComponents.Items[1].Enabled = false;
                    } else if(component is InfraredRx || component is InfraredTx) {
                        ctxComponents.Items[0].Enabled = true;
                        ctxComponents.Items[1].Enabled = false;
                    } else {
                        ctxComponents.Items[0].Enabled = false;
                        ctxComponents.Items[1].Enabled = false;
                    }
                    ctxComponents.Show(treComponents.PointToScreen(evt.Location));
                }
            }
        }

        private void treComponents_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs evt) {
            Component component = (Component)evt.Node.Tag;
            this.configureComponent(component);
        }
        #endregion

    }
}


#region Usings
using System;
using System.Threading;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public partial class RemoteGui : Form {

        #region Singleton
        private static volatile RemoteGui instance;

        public static RemoteGui getInstance() {
            if(instance==null) {
                instance = new RemoteGui();
            }
            return instance;
        }
        #endregion

        #region Fields
        private volatile Agent selectedAgent;
        private volatile List<Agent> agents = new List<Agent>();
        #endregion

        #region Threads
        private Thread agentsAliveThread;
        private bool agentsAliveRunning = true;
        #endregion

        #region Lifecycle
        private RemoteGui() {
            // avoid flickering of tree and list views
            avoidViewFlickering();
            // initialize graphical user interface
            InitializeComponent();
            // style main agent list view
            styleAgentListView();
            // configure frame properties
            this.Text = "Remote Controller @ "+Toolkit.getNetworkAdress(true).ToString();
            // register for agent beacon signals
            UdpNetworkClient.getInstance().onBeaconSignalPacketReceived += onBeaconSignalPacketReceived;
            // launch agent check alive thread
            this.agentsAliveThread = new Thread(checkAgentsAliveStatus);
            this.agentsAliveThread.Name = "Agent Validation Thread";
            this.agentsAliveThread.Start();
        }
        #endregion

        #region Styling
        private void avoidViewFlickering() {
            int style = NativeWinAPI.GetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE);
            style |= NativeWinAPI.WS_EX_COMPOSITE;
            NativeWinAPI.SetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE, style);
        }

        private void styleAgentListView() {
            lstAgents.View = View.Details;
            lstAgents.Columns.Add("Currently Available Agents", lstAgents.Width, HorizontalAlignment.Left);
            lstAgents.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lstAgents.HideSelection = false;
            lstAgents.FullRowSelect = true;
            ImageList icons = new ImageList();
            icons.ImageSize = new Size(24, 24);
            icons.Images.Add((Image)Properties.Resources.ResourceManager.GetObject("agent_24"));
            lstAgents.SmallImageList = icons;
        }
        #endregion

        #region Network
        private void onBeaconSignalPacketReceived(BeaconSignal packet) {
            if(isAgentRegistered(packet.SystemId) < 0) {
                // avoid async problems by disabling agent list selections
                this.UIThreadInvoke(delegate { lstAgents.Enabled = false; });
                // add a new agent to the list of available agents
                Agent agent = new Agent(packet);
                agents.Add(agent);
                agent.connect();
                // register for intial system information
                agent.onSystemStatusPacketReceived += onSystemStatusPacketReceived;
                // register for disconnection events
                agent.TcpNetworkClient.onNetworkClientDisconnected += onNetworkClientDisconnected;
                agent.RtpNetworkClient.onNetworkClientDisconnected += onNetworkClientDisconnected;
            } else {
                // just update timestamp if agent is already registered
                Agent agent = findAgent(packet.SystemId);
                agent.Timestamp = Toolkit.CurrentTimeMillis();
            }
        }

        private void onSystemStatusPacketReceived(SystemStatus packet) {
            this.UIThreadInvoke(delegate {
                try {
                    Agent agent = findAgent(packet.SystemId);
                    // create all panels and tool windows
                    agent.createView();
                    // add the newly added agent to the agent list on the gui
                    addAgentToList(agent);
                    // enable agent list selections after successful connection establishment
                    this.UIThreadInvoke(delegate { lstAgents.Enabled = true; });
                } catch(AgentNotFoundException) {
                    #region Logbook
                    Logger.Log(Level.WARNING, "Could not find agent with ID = "+packet.SystemId);
                    #endregion
                }
            });
        }

        private void onNetworkClientDisconnected(string systemId) {
            try {
                Agent agent = findAgent(systemId);
                agent.disconnect();
                removeAgentFromList(agent);
                agents.Remove(agent);
            } catch(AgentNotFoundException) {
                #region Logbook
                Logger.Log(Level.WARNING, "Could not find agent with ID = "+systemId, Debug.GENERIC);
                #endregion
            } catch(ArgumentOutOfRangeException) {
                #region Logbook
                Logger.Log(Level.WARNING, "Could not remove agent with ID = "+systemId, Debug.GENERIC);
                #endregion
            }
        }
        #endregion

        #region Properties
        public List<Agent> Agents {
            get { return agents; }
            set { agents = value; }
        }

        public Agent SelectedAgent {
            get { return selectedAgent; }
            set { selectedAgent = value; }
        }
        #endregion

        #region Agent Handling
        private Agent findAgent(string systemId) {
            foreach(Agent agent in agents) {
                if(systemId.Equals(agent.SystemId)) {
                    return agent;
                }
            }
            throw new AgentNotFoundException();
        }

        private int isAgentRegistered(string systemId) {
            for(int i = 0; i<agents.Count; i++) {
                if(agents[i].SystemId.Equals(systemId)) {
                    return i;
                }
            }
            return -1;
        }

        public void addAgentToList(Agent agent) {
            this.UIThreadInvoke(delegate {
                lstAgents.BeginUpdate();
                try {
                    if(!isAgentOnList(agent)) {
                        ListViewItem item = new ListViewItem(agent.Name+" @ "+agent.Address.ToString());
                        item.Tag = agent;
                        item.ImageIndex = 0;
                        lstAgents.Items.Add(item);
                    }
                } finally {
                    lstAgents.EndUpdate();
                    #region Select Agent
                    if(lstAgents.SelectedIndices.Count==0) {
                        if(lstAgents.Items.Count>0) {
                            lstAgents.Items[0].Selected = true;
                        }
                    }
                    #endregion
                }
            });
        }

        public void removeAgentFromList(Agent agent) {
            this.UIThreadInvoke(delegate {
                lstAgents.BeginUpdate();
                try {
                    for(int i = lstAgents.Items.Count-1; i>=0; i--) {
                        Agent item = (Agent)lstAgents.Items[i].Tag;
                        item.terminate();
                        if(item.SystemId==agent.SystemId) {
                            lstAgents.Items.RemoveAt(i);
                            break;
                        }
                    }
                } finally {
                    lstAgents.EndUpdate();
                    #region Select Agent
                    if(lstAgents.SelectedIndices.Count==0) {
                        if(lstAgents.Items.Count>0) {
                            lstAgents.Items[0].Selected = true;
                        }
                    }
                    #endregion
                }
            });
        }

        private bool isAgentOnList(Agent agent) {
            foreach(ListViewItem item in lstAgents.Items) {
                Agent listAgent = (Agent)item.Tag;
                if(agent==listAgent) {
                    return true;
                }
            }
            return false;
        }

        private void checkAgentsAliveStatus() {
            // periodically checks if agents are still alive
            while(agentsAliveRunning) {
                for(int i=agents.Count-1; i>=0; i--) {
                    if(Toolkit.CurrentTimeMillis()-agents[i].Timestamp > Globals.AGENT_ALIVE_TIMEOUT) {
                        removeAgentFromList(agents[i]);
                        agents.Remove(agents[i]);
                    }
                }
                Thread.Sleep(256);
            }
        }
        #endregion

        #region Event-Handling
        private void lstAgents_MouseClick(object sender, MouseEventArgs evt) {
            if(evt.Button == MouseButtons.Right) {
                if(lstAgents.SelectedItems.Count > 0) {
                    Agent agent = (Agent)lstAgents.SelectedItems[0].Tag;
                    if(agent.Connected) {
                        ctxAgents.Items[0].Enabled = false;
                        ctxAgents.Items[1].Enabled = false;
                        ctxAgents.Items[3].Enabled = true;
                        ctxAgents.Items[4].Enabled = true;
                    } else {
                        ctxAgents.Items[0].Enabled = false;
                        ctxAgents.Items[1].Enabled = false;
                        ctxAgents.Items[3].Enabled = false;
                        ctxAgents.Items[4].Enabled = false;
                    }
                    ctxAgents.Show(lstAgents.PointToScreen(evt.Location));
                }
            }
        }

        private void lstAgents_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs evt) {
            if(lstAgents.SelectedIndices.Count>0) {
                Agent agent = (Agent)lstAgents.SelectedItems[0].Tag;
                // close all open windows
                if(selectedAgent!=null) {
                    selectedAgent.closeWindows();
                }
                // remove previous tab control
                if(pnlTabControl.Controls.Count>0) {
                    pnlTabControl.Controls.RemoveAt(0);
                }
                // assign current tab control
                pnlTabControl.Controls.Add(agent.TabControl);
                // change currently selected agent
                this.selectedAgent = agent;
            } else {
                // close all open windows
                if(selectedAgent!=null) {
                    selectedAgent.closeWindows();
                }
                // remove previous tab control
                if(pnlTabControl.Controls.Count>0) {
                    pnlTabControl.Controls.RemoveAt(0);
                }
                // reset selected agent
                this.selectedAgent = null;
            }
            // handle menu entries
            itmSpeechSynthesizerTool.Enabled = lstAgents.SelectedIndices.Count>0;
            itmServoTimeLineTool.Enabled = lstAgents.SelectedIndices.Count>0;
        }

        private void ctxConnectAgent_Click(object sender, EventArgs evt) {
            /*if(lstAgents.SelectedItems.Count > 0) {
                selectedAgent.connect();
            }*/
        }

        private void ctxDisconnectAgent_Click(object sender, EventArgs evt) {
            /*if(lstAgents.SelectedItems.Count > 0) {
                selectedAgent.disconnect();
            }*/
        }

        private void ctxRestartAgent_Click(object sender, EventArgs evt) {
            if(lstAgents.SelectedItems.Count > 0) {
                Agent agent = (Agent)lstAgents.SelectedItems[0].Tag;
                agent.restart();
            }
        }

        private void ctxShutdownAgent_Click(object sender, EventArgs evt) {
            if(lstAgents.SelectedItems.Count > 0) {
                Agent agent = (Agent)lstAgents.SelectedItems[0].Tag;
                agent.shutdown();
            }
        }

        private void itmDetachControllerViews_Click(object sender, EventArgs evt) {
            if(selectedAgent!=null) {
                foreach(TabPage page in selectedAgent.TabControl.TabPages) {
                    try {
                        iDetachableView view = getDetachableView(page);
                        view.detachView();
                    } catch(Exception) { }
                }
            }
        }

        private void itmDetachCameraControllerViews_Click(object sender, EventArgs evt) {
            if(selectedAgent!=null) {
                foreach(TabPage page in selectedAgent.TabControl.TabPages) {
                    try {
                        if(isDetachableViewType<CameraPanel>(page)) {
                            iDetachableView view = getDetachableView(page);
                            view.detachView();
                        }
                    } catch(Exception) { }
                }
            }
        }

        private void itmDetachServoControllerViews_Click(object sender, EventArgs evt) {
            if(selectedAgent!=null) {
                foreach(TabPage page in selectedAgent.TabControl.TabPages) {
                    try {
                        if(isDetachableViewType<ServoPanel>(page)) {
                            iDetachableView view = getDetachableView(page);
                            view.detachView();
                        }
                    } catch(Exception) { }
                }
            }
        }

        private iDetachableView getDetachableView(TabPage page) {
            foreach(Control ctrl in page.Controls) {
                if(ctrl is iDetachableView) {
                    return (iDetachableView)ctrl;
                }
            }
            throw new NoDetachableViewFoundException();
        }

        private bool isDetachableViewType<T>(TabPage page) where T : UserControl {
            foreach(Control ctrl in page.Controls) {
                if(ctrl is T) {
                    return true;
                }
            }
            return false;
        }

        private void itmSpeechSynthesizerTool_Click(object sender, EventArgs evt) {
            if(selectedAgent!=null) {
                selectedAgent.SpeechSynthesizerTool.ShowDialog();
            }
        }

        private void itmServoTimeLineTool_Click(object sender, EventArgs evt) {
            if(selectedAgent!=null) {
                selectedAgent.ServoActionLibraryTool.ShowDialog();
            }
        }
        #endregion

        #region Termination
        private void terminate() {
            // try to let threads run out
            this.agentsAliveRunning = false;
            // unregister from beacon events and terminate udp listener
            UdpNetworkClient.getInstance().onBeaconSignalPacketReceived -= onBeaconSignalPacketReceived;
            UdpNetworkClient.getInstance().terminate();
            // terminate all agents
            foreach(Agent agent in agents) {
                agent.disconnect();
            }
            agents.Clear();
        }

        private void frmMain_Closing(object sender, FormClosingEventArgs evt) {
            this.exit(0, true);
        }

        private void itmQuit_Click(object sender, EventArgs evt) {
            this.exit(0, true);
        }

        private void exit(int exitCode, bool terminate) {
            this.terminate();
            if(terminate) Environment.Exit(0);
        }
        #endregion

    }

    #region Native WinAPI
    internal static class NativeWinAPI {

        internal static readonly int GWL_EXSTYLE = -20;
        internal static readonly int WS_EX_COMPOSITE = 0x02000000;

        [DllImport("user32")]
        internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32")]
        internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, long dwNewLong);

    }
    #endregion

    #region Cross Thread Calls
    internal static class ControlExtensions {

        #region Weblink
        // https://www.codeproject.com/Articles/37642/Avoiding-InvokeRequired#UIThread
        #endregion

        static public void UIThread(this Control control, Action code) {
            if(control.InvokeRequired) {
                control.BeginInvoke(code);
                return;
            }
            code.Invoke();
        }

        static public void UIThreadInvoke(this Control control, Action code) {
            if(control.InvokeRequired) {
                control.Invoke(code);
                return;
            }
            code.Invoke();
        }

    }
    #endregion

}
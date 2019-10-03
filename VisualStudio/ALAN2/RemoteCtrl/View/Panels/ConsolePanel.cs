
#region Usings
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public partial class ConsolePanel : UserControl {

        #region Fields
        private Agent agent;
        #endregion

        #region Lifecycle
        public ConsolePanel(Agent agent) {
            this.agent = agent;
            avoidViewFlickering();
            InitializeComponent();
            initializeGui();
            agent.onConsoleOutputPacketReceived += onConsoleOutputPacketReceived;
        }

        private void avoidViewFlickering() {
            int style = NativeWinAPI.GetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE);
            style |= NativeWinAPI.WS_EX_COMPOSITE;
            NativeWinAPI.SetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE, style);
        }

        private void initializeGui() {
            txtAtmelConsole.Clear();
            txtAgentConsole.Clear();
            foreach(string line in agent.AtmelConsole) {
                txtAtmelConsole.Text += line+Environment.NewLine;
            }
            foreach(string line in agent.AgentConsole) {
                txtAgentConsole.Text += line+Environment.NewLine;
            }
        }
        #endregion

        #region Properties

        #endregion

        #region Functions
        public void onConsoleOutputPacketReceived(ConsoleOutput packet) {
            this.UIThreadInvoke(delegate {
                if(packet.Origin) {
                    txtAtmelConsole.AppendText(packet.Line+Environment.NewLine);
                } else {
                    txtAgentConsole.AppendText(packet.Line+Environment.NewLine);
                }
            });
        }
        #endregion

        #region Event-Handling
        /*  This is an overload instead of attaching the Load(*) event manually.
         * Just copy and paste this code to other user-control classes. */
        protected override void OnLoad(EventArgs evt) {
            this.AutoSize = false;
            this.Dock = DockStyle.Fill;
            base.OnLoad(evt);
        }

        private void cmdAgentClear_Click(object sender, EventArgs evt) {
            txtAgentConsole.Clear();
        }

        private void cmdAtmelClear_Click(object sender, EventArgs evt) {
            txtAtmelConsole.Clear();
        }
        #endregion

        
    }

}

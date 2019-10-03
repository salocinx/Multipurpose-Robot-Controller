
#region Usings
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public partial class SpeechSynthesizerTool : Form {

        #region Fields
        private Agent agent;
        #endregion

        #region Lifecycle
        public SpeechSynthesizerTool(Agent agent) {
            this.agent = agent;
            InitializeComponent();
            styleActionListView();
            initializeGui();
        }

        private void initializeGui() {
            List<SpeechAction> actions = agent.ActionLibrary.SpeechActions;
            // disable properties group if no actions available
            if(actions.Count==0) setPropertiesControlsEnabled(false);
            // initialize servo action list view
            foreach(SpeechAction action in actions) {
                ListViewItem item = new ListViewItem(action.ToString());
                item.Tag = action;
                item.ImageIndex = 0;
                lstSpeechActions.Items.Add(item);
            }
            #region Select First Action
            if(lstSpeechActions.Items.Count>0) {
                lstSpeechActions.Items[0].Selected = true;
            }
            #endregion
        }
        #endregion

        #region Styling
        private void styleActionListView() {
            lstSpeechActions.View = System.Windows.Forms.View.Details;
            lstSpeechActions.Columns.Add("Speech Actions", lstSpeechActions.Width, HorizontalAlignment.Left);
            lstSpeechActions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lstSpeechActions.HideSelection = false;
            lstSpeechActions.FullRowSelect = true;
            ImageList icons = new ImageList();
            icons.ImageSize = new Size(24, 24);
            icons.Images.Add((Image)Properties.Resources.ResourceManager.GetObject("sentence_24"));
            lstSpeechActions.SmallImageList = icons;
        }
        #endregion

        #region Functions
        private int generateActionId() {
            int id = 0;
            while(true) {
                if(isActionIdAvailable(id)) {
                    return id;
                }
                id++;
            }
        }

        private bool isActionIdAvailable(int id) {
            foreach(ListViewItem item in lstSpeechActions.Items) {
                SpeechAction action = (SpeechAction)item.Tag;
                if(action.Id==id) {
                    return false;
                }
            }
            return true;
        }

        private void setPropertiesControlsEnabled(bool enabled) {
            foreach(Control ctrl in grpSynthesizerProperties.Controls) {
                ctrl.Enabled = enabled;
            }
            #region Exclusive Controls
            txtId.Enabled = false;
            #endregion
        }

        private void sendSpeechCommand() {
            if(lstSpeechActions.SelectedItems.Count > 0) {
                SpeechActionCommand command = new SpeechActionCommand(0);
                command.SpeechAction = (SpeechAction)lstSpeechActions.SelectedItems[0].Tag; ;
                agent.TcpNetworkClient.send(command);
            }
        }

        private void sendLibraryChanged() {
            UpdateActionLibrary update = new UpdateActionLibrary(0);
            update.ActionLibrary = agent.ActionLibrary;
            agent.TcpNetworkClient.send(update);
        }
        #endregion

        #region Event-Handling
        private void lstSpeechActions_SelectedIndexChanged(object sender, EventArgs evt) {
            if(lstSpeechActions.SelectedItems.Count > 0) {
                SpeechAction action = (SpeechAction)lstSpeechActions.SelectedItems[0].Tag;
                // update action properties
                txtId.Text = action.Id.ToString();
                txtText.Text = action.Text;
                trkAmplitude.Value = action.Amplitude;
                trkPitch.Value = action.Pitch;
                trkSpeed.Value = action.Speed;
                trkWordGap.Value = action.WordGap;
                // enable controls
                setPropertiesControlsEnabled(true);
            } else {
                txtId.Text = "";
                // disable controls
                setPropertiesControlsEnabled(false);
            }
        }

        private void trkAmplitude_ValueChanged(object sender, EventArgs evt) {
            if(lstSpeechActions.SelectedItems.Count > 0) {
                SpeechAction action = (SpeechAction)lstSpeechActions.SelectedItems[0].Tag;
                action.Amplitude = trkAmplitude.Value;
                txtAmplitude.Text = "Voice Amplitude: "+action.Amplitude+" [0, 200]";
            }
        }

        private void trkPitch_ValueChanged(object sender, EventArgs evt) {
            if(lstSpeechActions.SelectedItems.Count > 0) {
                SpeechAction action = (SpeechAction)lstSpeechActions.SelectedItems[0].Tag;
                action.Pitch = trkPitch.Value;
                txtPitch.Text = "Voice Pitch: "+action.Pitch+" [0, 99]";
            }
        }

        private void trkSpeed_ValueChanged(object sender, EventArgs evt) {
            if(lstSpeechActions.SelectedItems.Count > 0) {
                SpeechAction action = (SpeechAction)lstSpeechActions.SelectedItems[0].Tag;
                action.Speed = trkSpeed.Value;
                txtSpeed.Text = "Voice Speed: "+action.Speed+" [80, 450]";
            }
        }

        private void trkWordGap_ValueChanged(object sender, EventArgs evt) {
            if(lstSpeechActions.SelectedItems.Count > 0) {
                SpeechAction action = (SpeechAction)lstSpeechActions.SelectedItems[0].Tag;
                action.WordGap = trkWordGap.Value;
                txtWordGap.Text = "Voice Word Gap: "+action.WordGap+" [10, 1000]";
            }
        }

        private void cmdSpeak_Click(object sender, EventArgs evt) {
            if(lstSpeechActions.SelectedItems.Count > 0) {
                SpeechAction action = (SpeechAction)lstSpeechActions.SelectedItems[0].Tag;
                // send speech command to agent
                if(txtText.Text.Length>0) sendSpeechCommand();
                // clear text after executed
                if(boxClear.Checked) txtText.Clear();
            }
        }

        private void txtText_KeyUp(object sender, KeyEventArgs evt) {
            if(evt.KeyCode==Keys.Enter || evt.KeyCode==Keys.Return) {
                if(lstSpeechActions.SelectedItems.Count > 0) {
                    SpeechAction action = (SpeechAction)lstSpeechActions.SelectedItems[0].Tag;
                    // update model
                    action.Text = txtText.Text;
                    // update view
                    lstSpeechActions.SelectedItems[0].Text = action.ToString();
                    // send speech command to agent
                    sendSpeechCommand();
                    // clear text after executed
                    if(boxClear.Checked) txtText.Clear();
                }
            }
        }

        private void txtText_Leave(object sender, EventArgs evt) {
            if(lstSpeechActions.SelectedItems.Count > 0) {
                SpeechAction action = (SpeechAction)lstSpeechActions.SelectedItems[0].Tag;
                // update model
                action.Text = txtText.Text;
                // update view
                lstSpeechActions.SelectedItems[0].Text = action.ToString();
            }
        }

        private void lstSpeechActions_MouseUp(object sender, MouseEventArgs evt) {
            if(evt.Button == MouseButtons.Right) {
                if(lstSpeechActions.SelectedItems.Count > 0) {
                    ctxSpeechActions.Items[0].Enabled = true;
                    ctxSpeechActions.Items[1].Enabled = false;
                    ctxSpeechActions.Items[3].Enabled = true;
                } else {
                    ctxSpeechActions.Items[0].Enabled = true;
                    ctxSpeechActions.Items[1].Enabled = false;
                    ctxSpeechActions.Items[3].Enabled = false;
                }
                ctxSpeechActions.Show(lstSpeechActions.PointToScreen(evt.Location));
            }
        }

        private void itmNewAction_Click(object sender, EventArgs e) {
            SpeechAction action = new SpeechAction(generateActionId());
            // add to model
            agent.ActionLibrary.SpeechActions.Add(action);
            // add to view
            ListViewItem item = new ListViewItem(action.ToString());
            item.Tag = action;
            item.ImageIndex = 0;
            lstSpeechActions.Items.Add(item);
            #region Select Last Entry
            if(lstSpeechActions.Items.Count>0) {
                lstSpeechActions.Items[lstSpeechActions.Items.Count-1].Selected = true;
            }
            #endregion
            // put focus to text field
            txtText.Focus();
        }

        private void itmDuplicateAction_Click(object sender, EventArgs e) {
            // TODO: duplicate speech action ...
        }

        private void itmDeleteAction_Click(object sender, EventArgs e) {
            if(lstSpeechActions.SelectedItems.Count > 0) {
                SpeechAction action = (SpeechAction)lstSpeechActions.SelectedItems[0].Tag;
                // remove from model
                agent.ActionLibrary.SpeechActions.Remove(action);
                // remove from view
                lstSpeechActions.Items.Remove(lstSpeechActions.SelectedItems[0]);
                #region Select First Entry
                if(lstSpeechActions.SelectedIndices.Count==0) {
                    if(lstSpeechActions.Items.Count>0) {
                        lstSpeechActions.Items[0].Selected = true;
                    }
                }
                #endregion
            }
        }

        private void itmSave_Click(object sender, EventArgs e) {
            sendLibraryChanged();
        }

        private void itmExit_Click(object sender, EventArgs e) {
            sendLibraryChanged();
            this.Hide();
        }

        private void BatteryManagementTool_FormClosing(object sender, FormClosingEventArgs evt) {
            if(evt.CloseReason == CloseReason.UserClosing) {
                sendLibraryChanged();
                evt.Cancel = true;
                Hide();
            }
        }
        #endregion

    }

}


#region Usings
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public partial class ServoActionLibraryTool : Form {

        #region Fields
        private Agent agent;
        private List<Servo> servos;
        private ServoLayer selectedServoLayer;
        private ServoLayerControl selectedServoLayerControl;
        #endregion

        #region Lifecycle
        public ServoActionLibraryTool(Agent agent) {
            this.agent = agent;
            InitializeComponent();
            styleActionListView();
            initializeGui();
        }
        #endregion

        #region Styling
        private void styleActionListView() {
            lstServoActions.View = System.Windows.Forms.View.Details;
            lstServoActions.Columns.Add("Servo Sequence Actions", lstServoActions.Width, HorizontalAlignment.Left);
            lstServoActions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lstServoActions.HideSelection = false;
            lstServoActions.FullRowSelect = true;
            ImageList icons = new ImageList();
            icons.ImageSize = new Size(24, 24);
            icons.Images.Add((Image)Properties.Resources.ResourceManager.GetObject("action_24"));
            lstServoActions.SmallImageList = icons;
        }
        #endregion

        #region Functions
        private void initializeGui() {
            // collect all available servos
            servos = agent.findComponents<Servo>();
            tlcServoLayers.setServos(servos);
            // initialize servo combo box
            foreach(Servo servo in servos) {
                cbxServo.Items.Add(servo);
            }
            // initialize servo action list view
            foreach(ServoAction action in agent.ActionLibrary.ServoActions) {
                ListViewItem item = new ListViewItem(action.ToString());
                item.Tag = action;
                item.ImageIndex = 0;
                lstServoActions.Items.Add(item);
            }
            #region Select First Action
            if(lstServoActions.Items.Count>0) {
                lstServoActions.Items[0].Selected = true;
            }
            #endregion
        }

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
            foreach(ListViewItem item in lstServoActions.Items) {
                ServoAction action = (ServoAction)item.Tag;
                if(action.Id==id) {
                    return false;
                }
            }
            return true;
        }

        private Servo findServo(ushort servoId) {
            foreach(Servo servo in servos) {
                if(servo.Id==servoId) {
                    return servo;
                }
            }
            return null;
        }

        private void addLayerControlToList(ServoLayer layer) {
            ServoLayerControl layerCtrl = new ServoLayerControl(layer);
            layerCtrl.Location = new Point(0, lstServoLayers.Controls.Count*layerCtrl.Height);
            layerCtrl.Width = lstServoLayers.Width-20;
            layerCtrl.onMouseClick += lstServoLayers_MouseClick;
            layerCtrl.onServoLayerPropertyChanged += lstServoLayers_PropertyValueChanged;
            layerCtrl.onServoLayerSelectionChanged += lstServoLayers_SelectedIndexChanged;
            lstServoLayers.Controls.Add(layerCtrl);
        }

        private bool isLayerSelected() {
            foreach(ServoLayerControl ctrl in lstServoLayers.Controls) {
                if(ctrl.selected()) {
                    return true;
                }
            }
            return false;
        }

        private void restoreLayerSelection() {
            // restore previous layer selection
            foreach(ServoLayerControl ctrl in lstServoLayers.Controls) {
                if(ctrl.selected()) {
                    ctrl.select();
                    return;
                }
            }
            // select first layer if no selection available
            if(lstServoLayers.Controls.Count>0) {
                ServoLayerControl ctrl = (ServoLayerControl)lstServoLayers.Controls[0];
                ctrl.select();
            }
        }

        private void sendLibraryChanged() {
            UpdateActionLibrary update = new UpdateActionLibrary(0);
            update.ActionLibrary = agent.ActionLibrary;
            agent.TcpNetworkClient.send(update);
        }
        #endregion

        #region Event-Handling (List Views)
        private void lstServoActions_SelectedIndexChanged(object sender, EventArgs evt) {
            // clear previous layer entries
            tlcServoLayers.clear();
            lstServoLayers.Controls.Clear();
            // update new layer entries
            if(lstServoActions.SelectedItems.Count > 0) {
                ServoAction action = (ServoAction)lstServoActions.SelectedItems[0].Tag;
                // update properties
                txtId.Text = action.Id.ToString();
                trkZoom.Value = action.Zoom;
                trkSpeed.Value = action.Speed;
                // update layer list
                foreach(ServoLayer layer in action.ServoLayers) {
                    addLayerControlToList(layer);
                }
                // update time line control
                tlcServoLayers.setServoLayers(action.ServoLayers);
                // restore previous layer selection
                restoreLayerSelection();
                // set action name
                txtActionName.Text = action.Name;
                // enable controls
                #region Enable Controls
                txtActionName.Enabled = true;
                trkZoom.Enabled = true;
                trkSpeed.Enabled = true;
                cmdPlay.Enabled = true;
                cmdReset.Enabled = true;
                #endregion
            } else {
                txtId.Text = "";
                // disable controls
                #region Disable Controls
                txtActionName.Text = "";
                txtActionName.Enabled = false;
                cbxServo.Enabled = false;
                trkZoom.Enabled = false;
                trkSpeed.Enabled = false;
                cmdPlay.Enabled = false;
                cmdReset.Enabled = false;
                #endregion
            }
        }

        private void lstServoLayers_SelectedIndexChanged(ServoLayerControl control, ServoLayer selection) {
            if(control==null && selection==null) {
                selectedServoLayer = null;
                selectedServoLayerControl = null;
                // deselect all entries in layer list if clicked anywhere in the list
                foreach(ServoLayerControl ctrl in lstServoLayers.Controls) {
                    ctrl.deselect();
                }
                // disable servo combo box and delete command
                cbxServo.Enabled = false;
                // set selection for assigning new key points etc.
                tlcServoLayers.setSelectedLayer(null);
                // repaint time line control
                tlcServoLayers.Invalidate();
            } else {
                selectedServoLayer = selection;
                selectedServoLayerControl = control;
                // enable servo combo box and delete command
                cbxServo.Enabled = true;
                // select appropriate servo in combo box
                cbxServo.SelectedIndexChanged -= cbxServo_SelectedIndexChanged;
                #region Select Appropriate Combobox Entry
                for(int i = 0; i<cbxServo.Items.Count; i++) {
                    Servo servo = (Servo)cbxServo.Items[i];
                    if(servo.Id==selection.ServoId) {
                        cbxServo.SelectedIndex = i;
                        break;
                    }
                }
                #endregion
                cbxServo.SelectedIndexChanged += cbxServo_SelectedIndexChanged;
                // set selection for assigning new key points etc.
                tlcServoLayers.setSelectedLayer(selection);
                // repaint time line control
                tlcServoLayers.Invalidate();
            }
        }

        private void lstServoActions_MouseUp(object sender, MouseEventArgs evt) {
            if(evt.Button == MouseButtons.Right) {
                if(lstServoActions.SelectedItems.Count > 0) {
                    ctxServoActions.Items[0].Enabled = true;
                    ctxServoActions.Items[1].Enabled = true;
                    ctxServoActions.Items[3].Enabled = true;
                } else {
                    ctxServoActions.Items[0].Enabled = true;
                    ctxServoActions.Items[1].Enabled = false;
                    ctxServoActions.Items[3].Enabled = false;
                }
                ctxServoActions.Show(lstServoActions.PointToScreen(evt.Location));
            }
        }

        private void lstServoLayers_MouseClick(object sender, MouseEventArgs evt) {
            if(sender is Panel) {
                // deselect all layers if clicked into panel
                lstServoLayers_SelectedIndexChanged(null, null);
            }
            // show context menu for servo layers
            if(evt.Button == MouseButtons.Right) {
                if(lstServoActions.SelectedItems.Count > 0) {
                    if(selectedServoLayer != null) {
                        ctxServoLayers.Items[0].Enabled = true;
                        ctxServoLayers.Items[1].Enabled = true;
                        ctxServoLayers.Items[3].Enabled = true;
                    } else {
                        ctxServoLayers.Items[0].Enabled = true;
                        ctxServoLayers.Items[1].Enabled = false;
                        ctxServoLayers.Items[3].Enabled = false;
                    }
                    ctxServoLayers.Show(lstServoLayers.PointToScreen(evt.Location));
                }
            }
        }

        private void lstServoLayers_PropertyValueChanged(bool visible, bool locked) {
            // repaint panel if any property changed
            tlcServoLayers.Invalidate();
        }

        private void cbxServo_SelectedIndexChanged(object sender, EventArgs evt) {
            if(tlcServoLayers.getSelectedLayer()!=null) {
                Servo servo = (Servo)cbxServo.SelectedItem;
                tlcServoLayers.getSelectedLayer().ServoId = servo.Id;
                tlcServoLayers.getSelectedLayer().ServoName = servo.Name;
                #region Refresh Layer Controls
                foreach(ServoLayerControl ctrl in lstServoLayers.Controls) {
                    ctrl.updateGui();
                }
                #endregion
            }
        }
        #endregion

        #region Event-Handling (Commands)
        private void itmNewAction_Click(object sender, EventArgs evt) {
            if(servos.Count > 0) {
                ServoAction action = new ServoAction(generateActionId(), "Servo Action");
                // add to model
                agent.ActionLibrary.ServoActions.Add(action);
                // add to view
                ListViewItem item = new ListViewItem(action.ToString());
                item.Tag = action;
                item.ImageIndex = 0;
                lstServoActions.Items.Add(item);
                #region Select Last Entry
                if(lstServoActions.Items.Count>0) {
                    lstServoActions.Items[lstServoActions.Items.Count-1].Selected = true;
                }
                #endregion
            } else {
                MessageBox.Show("There are no servos available.\nCheck the agent's configuration.", "No Servos Available", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void itmDuplicateAction_Click(object sender, EventArgs evt) {
            if(lstServoActions.SelectedItems.Count > 0) {
                ServoAction selected_action = (ServoAction)lstServoActions.SelectedItems[0].Tag;
                ServoAction copied_action = selected_action.copy(generateActionId());
                // add to model
                agent.ActionLibrary.ServoActions.Add(copied_action);
                // add to view
                ListViewItem item = new ListViewItem(copied_action.ToString());
                item.Tag = copied_action;
                item.ImageIndex = 0;
                lstServoActions.Items.Add(item);
                #region Select Last Entry
                if(lstServoActions.Items.Count>0) {
                    lstServoActions.Items[lstServoActions.Items.Count-1].Selected = true;
                }
                #endregion
            }
        }

        private void itmDeleteAction_Click(object sender, EventArgs evt) {
            if(lstServoActions.SelectedItems.Count > 0) {
                ServoAction action = (ServoAction)lstServoActions.SelectedItems[0].Tag;
                // remove from model
                agent.ActionLibrary.ServoActions.Remove(action);
                // remove from view
                lstServoActions.Items.Remove(lstServoActions.SelectedItems[0]);
                // select first entry if available
                if(lstServoActions.Items.Count>0) {
                    lstServoActions.Items[0].Selected = true;
                }
                // finally repaint time line control
                tlcServoLayers.Invalidate();
            }
        }

        private void itmNewLayer_Click(object sender, EventArgs evt) {
            if(servos.Count > 0 && lstServoActions.SelectedItems.Count > 0) {
                ServoAction action = (ServoAction)lstServoActions.SelectedItems[0].Tag;
                ServoLayer layer = new ServoLayer(servos[0].Id, servos[0].Name);
                action.ServoLayers.Add(layer);
                addLayerControlToList(layer);
            }
        }

        private void itmDuplicateLayer_Click(object sender, EventArgs evt) {
            if(servos.Count > 0 && lstServoActions.SelectedItems.Count > 0 && selectedServoLayerControl!=null) {
                ServoAction action = (ServoAction)lstServoActions.SelectedItems[0].Tag;
                ServoLayer layer = selectedServoLayerControl.ServoLayer.copy();
                action.ServoLayers.Add(layer);
                addLayerControlToList(layer);
            }
        }

        private void itmDeleteLayer_Click(object sender, EventArgs evt) {
            if(lstServoActions.SelectedItems.Count > 0 && selectedServoLayerControl!=null) {
                ServoAction action = (ServoAction)lstServoActions.SelectedItems[0].Tag;
                // remove layer from model
                action.ServoLayers.Remove(selectedServoLayer);
                // remove event listeners
                selectedServoLayerControl.onMouseClick -= lstServoLayers_MouseClick;
                selectedServoLayerControl.onServoLayerPropertyChanged -= lstServoLayers_PropertyValueChanged;
                selectedServoLayerControl.onServoLayerSelectionChanged -= lstServoLayers_SelectedIndexChanged;
                // remove layer from view
                lstServoLayers.Controls.Remove(selectedServoLayerControl);
                // re-arange list entries
                for(int i = 0; i<lstServoLayers.Controls.Count; i++) {
                    lstServoLayers.Controls[i].Location = new Point(0, i*lstServoLayers.Controls[i].Height);
                }
                // disable delete command if deleted entry was last one, otherwise select first entry
                if(lstServoLayers.Controls.Count==0) {
                    lstServoLayers_SelectedIndexChanged(null, null);
                } else {
                    ServoLayerControl ctrl = (ServoLayerControl)lstServoLayers.Controls[0];
                    ctrl.select();
                }
                // refresh time line control
                tlcServoLayers.Invalidate();
            }
        }

        private void cmdPlay_Click(object sender, EventArgs evt) {
            if(lstServoActions.SelectedItems.Count > 0) {
                ServoActionCommand command = new ServoActionCommand(0);
                command.ServoAction = (ServoAction)lstServoActions.SelectedItems[0].Tag;
                agent.TcpNetworkClient.send(command);
            }
        }

        private void cmdReset_Click(object sender, EventArgs evt) {
            if(lstServoActions.SelectedItems.Count > 0) {
                ServoAction action = (ServoAction)lstServoActions.SelectedItems[0].Tag;
                foreach(ServoLayer layer in action.ServoLayers) {
                    if(layer.ServoKeyPoints.Count>0) {
                        Servo servo = findServo(layer.ServoId);
                        if(servo!=null) {
                            ServoPositionCommand command = new ServoPositionCommand(servo.Id);
                            command.Pin = servo.Pin;
                            command.Board = servo.Address;
                            command.Position = layer.ServoKeyPoints[0].Y;
                            agent.TcpNetworkClient.send(command);
                        }
                    }
                }
            }
        }
        #endregion

        #region Event-Handling (Miscellaneous)
        private void itmSave_Click(object sender, EventArgs evt) {
            sendLibraryChanged();
        }

        private void txtActionName_KeyUp(object sender, KeyEventArgs evt) {
            if(evt.KeyCode==Keys.Enter || evt.KeyCode==Keys.Return) {
                txtActionName_Leave(sender, evt);
            }
        }

        private void txtActionName_Leave(object sender, EventArgs evt) {
            if(lstServoActions.SelectedItems.Count > 0) {
                ServoAction action = (ServoAction)lstServoActions.SelectedItems[0].Tag;
                action.Name = txtActionName.Text;
                lstServoActions.SelectedItems[0].Text = action.ToString();
            }
        }

        private void trkZoom_ValueChanged(object sender, EventArgs evt) {
            if(lstServoActions.SelectedItems.Count > 0) {
                ServoAction action = (ServoAction)lstServoActions.SelectedItems[0].Tag;
                action.Zoom = trkZoom.Value;
                lblZoom.Text = "Zoom ["+trkZoom.Value+"%]: ";
                tlcServoLayers.setZoom(trkZoom.Value);
                tlcServoLayers.Width = trkZoom.Value*(Globals.SERVO_LIBRARY_WORKSPACE*400/100);
            }
        }

        private void trkSpeed_ValueChanged(object sender, EventArgs evt) {
            if(lstServoActions.SelectedItems.Count > 0) {
                ServoAction action = (ServoAction)lstServoActions.SelectedItems[0].Tag;
                action.Speed = trkSpeed.Value;
                lblSpeed.Text = "Speed ["+trkSpeed.Value+"%]: ";
            }
        }

        private void ServoTimeLineApplication_FormClosing(object sender, FormClosingEventArgs evt) {
            if(evt.CloseReason == CloseReason.UserClosing) {
                sendLibraryChanged();
                evt.Cancel = true;
                Hide();
            }
        }

        private void itmExit_Click(object sender, EventArgs evt) {
            sendLibraryChanged();
            this.Hide();
        }
        #endregion

    }

}

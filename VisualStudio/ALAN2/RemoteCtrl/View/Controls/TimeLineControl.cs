
#region Usings
using System;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public partial class TimeLineControl : UserControl {

        #region Fields

        private List<Servo> servos;

        /* logic fields */
        private int zoom = 100;
        private float fzoom = 0.5f;
        private bool multiSelection = false;
        private bool showMultiSelection = false;
        private ServoLayer selectedLayer = null;
        private List<ServoLayer> servoLayers = new List<ServoLayer>();
        private List<ServoKeyPoint> cselection = new List<ServoKeyPoint>();

        /* drawing fields */
        private Point prevLocation;
        private Point wcenter;
        private Point multiSelectionStart;
        private Point multiSelectionFinish;
        private Rectangle multiSelectionRect;

        #endregion

        #region Constants
        // selection range in pixels
        private float RANGE = 18f;
        // key point drawing size
        private Size KEYSIZE = new Size(6, 6);
        #endregion

        #region Lifecycle
        public TimeLineControl() {
            Paintkit.init();
            InitializeComponent();
            prevLocation = new Point(int.MaxValue, int.MaxValue);
        }

        /* receive key events independent from focused control */
        protected override bool ProcessDialogKey(Keys keyData) {
            return true;
        }
        #endregion

        #region Functions
        public void setServos(List<Servo> servos) {
            this.servos = servos;
        }

        private Servo findServo(ushort servoId) {
            foreach(Servo servo in servos) {
                if(servo.Id==servoId) {
                    return servo;
                }
            }
            return null;
        }

        public void move(ServoKeyPoint key, int dx, int dy) {
            key.X += Guikit.v2m4x(dx);
            key.Y += Guikit.v2m4y(dy);
            key.X = Toolkit.clamp(key.X, 0, int.MaxValue);
            key.Y = Toolkit.clamp(key.Y, 0f, 100f);
        }

        private bool isWithinRectangle(ServoKeyPoint key, ref Rectangle rectangle) {
            return key.ViewX>=rectangle.X &&
                   key.ViewX<=rectangle.X+rectangle.Width &&
                   key.ViewY>=rectangle.Y &&
                   key.ViewY<=rectangle.Y+rectangle.Height;
        }

        private bool isAnyWithinRectangle(ref Rectangle rectangle) {
            if(servoLayers!=null) {
                foreach(ServoLayer layer in servoLayers) {
                    if(layer.Visible && !layer.Locked) {
                        foreach(ServoKeyPoint key in layer.ServoKeyPoints) {
                            if(isWithinRectangle(key, ref multiSelectionRect)) {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public void clear() {
            cselection.Clear();
        }

        public void clearAll() {
            servoLayers = null;
            selectedLayer = null;
            cselection.Clear();
        }

        public void setZoom(int zoom) {
            this.zoom = zoom;
            this.TimeLineControl_Update(null, null);
        }

        public void setServoLayers(List<ServoLayer> servoLayers) {
            this.servoLayers = servoLayers;
            Invalidate();
        }

        public void setSelectedLayer(ServoLayer selectedLayer) {
            this.selectedLayer = selectedLayer;
            Invalidate();
        }

        public ServoLayer getSelectedLayer() {
            return selectedLayer;
        }

        private bool isKeyPointInSelectionRange(Point mouse) {
            if(servoLayers!=null) {
                foreach(ServoLayer layer in servoLayers) {
                    if(layer.Visible && !layer.Locked) {
                        foreach(ServoKeyPoint key in layer.ServoKeyPoints) {
                            if(Toolkit.distance(key.ViewPosition, mouse) <= RANGE) {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private ServoKeyPoint getNearestKeyPointInSelectionRange(Point mouse) {
            ServoKeyPoint selected = null;
            if(servoLayers!=null) {
                foreach(ServoLayer layer in servoLayers) {
                    if(layer.Visible && !layer.Locked) {
                        foreach(ServoKeyPoint key in layer.ServoKeyPoints) {
                            if(selected == null) {
                                if(Toolkit.distance(key.ViewPosition, mouse) <= RANGE) {
                                    selected = key;
                                    continue;
                                }
                            } else {
                                if(Toolkit.distance(key.ViewPosition, mouse) < Toolkit.distance(selected.ViewPosition, mouse)) {
                                    selected = key;
                                }
                            }
                        }
                    }
                }
            }
            return selected;
        }

        private void clearSelection() {
            if(servoLayers!=null) {
                foreach(ServoLayer layer in servoLayers) {
                    foreach(ServoKeyPoint keyPoint in layer.ServoKeyPoints) {
                        keyPoint.Selected = false;
                    }
                }
            }
            cselection.Clear();
            Invalidate();
        }
        #endregion

        #region Painting
        private void TimeLineControl_Paint(object sender, PaintEventArgs evt) {
            #region Paint Coordinate System
            // draw dashed horizontal lines [25%, 50%, 75%]
            evt.Graphics.DrawLine(Paintkit.PenFineDashedDarkGray, new Point(0, Height/4), new Point(Width, Height/4));
            evt.Graphics.DrawLine(Paintkit.PenFineDashedDarkGray, new Point(0, Height/2), new Point(Width, Height/2));
            evt.Graphics.DrawLine(Paintkit.PenFineDashedDarkGray, new Point(0, Height/4*3), new Point(Width, Height/4*3));
            // draw fat dashed line every second
            for(int x=0; x<Width; x+=zoom) {
                if(x%(zoom*4)==0) {
                    evt.Graphics.DrawLine(Paintkit.PenFineDashedDarkGray, new Point(x, 0), new Point(x, Height));
                } else {
                    evt.Graphics.DrawLine(Paintkit.PenFineDashedLightGray, new Point(x, 0), new Point(x, Height));
                }
            }
            #endregion
            #region Paint Multiselection
            if(showMultiSelection) {
                int largeX = multiSelectionFinish.X > multiSelectionStart.X ? multiSelectionFinish.X : multiSelectionStart.X;
                int smallX = multiSelectionFinish.X < multiSelectionStart.X ? multiSelectionFinish.X : multiSelectionStart.X;
                int largeY = multiSelectionFinish.Y > multiSelectionStart.Y ? multiSelectionFinish.Y : multiSelectionStart.Y;
                int smallY = multiSelectionFinish.Y < multiSelectionStart.Y ? multiSelectionFinish.Y : multiSelectionStart.Y;
                Size msize = new Size(largeX-smallX, largeY-smallY);
                multiSelectionRect = new Rectangle(new Point(smallX, smallY), msize);
                evt.Graphics.FillRectangle(Paintkit.BrushSolidLightGray, multiSelectionRect);
                evt.Graphics.DrawRectangle(Paintkit.PenFineDashedDarkGray, multiSelectionRect);
            }
            #endregion
            #region Paint Connections
            if(servoLayers!=null) {
                foreach(ServoLayer layer in servoLayers) {
                    if(layer.Visible) {
                        if(layer.ServoKeyPoints.Count>1) {
                            Pen pen;
                            Servo servo = findServo(layer.ServoId);
                            layer.ServoKeyPoints.Sort(delegate (ServoKeyPoint n1, ServoKeyPoint n2) { return n1.X.CompareTo(n2.X); });
                            for(int i=1; i<layer.ServoKeyPoints.Count; i++) {
                                Point p1 = new Point(layer.ServoKeyPoints[i-1].ViewX, (int)layer.ServoKeyPoints[i-1].ViewY);
                                Point p2 = new Point(layer.ServoKeyPoints[i].ViewX, (int)layer.ServoKeyPoints[i].ViewY);
                                #region Validation & Colours
                                if(layer.Locked) {
                                    if(layer.Selected) {
                                        pen = Paintkit.PenFatDarkGray;
                                    } else {
                                        pen = Paintkit.PenFineDarkGray;
                                    }
                                } else {
                                    int x1 = layer.ServoKeyPoints[i].X;
                                    int x2 = layer.ServoKeyPoints[i-1].X;
                                    float y1 = layer.ServoKeyPoints[i].Y;
                                    float y2 = layer.ServoKeyPoints[i-1].Y;
                                    if(servo.validate(x1, x2, y1, y2)) {
                                        if(layer.Selected) {
                                            pen = Paintkit.PenFatBrown;
                                        } else {
                                            pen = Paintkit.PenFineBrown;
                                        }
                                    } else {
                                        if(layer.Selected) {
                                            pen = Paintkit.PenFatRed;
                                        } else {
                                            pen = Paintkit.PenFineRed;
                                        }
                                    }
                                }
                                #endregion
                                evt.Graphics.DrawLine(pen, p1, p2);
                            }
                        }
                    }
                }
            }
            #endregion
            #region Paint Key Points
            if(servoLayers!=null) {
                foreach(ServoLayer layer in servoLayers) {
                    if(layer.Visible) {
                        foreach(ServoKeyPoint key in layer.ServoKeyPoints) {
                            Pen pen = key.Selected ? Paintkit.PenFineOrange : Paintkit.PenFineBlack;
                            Brush brush = key.Selected ? Paintkit.BrushSolidDarkOrange : Paintkit.BrushSolidDarkGray;
                            // x-axis: 1 px = 2 ms; y-axis: ?px = Height/100%
                            Rectangle rect = new Rectangle(new Point(key.ViewX-KEYSIZE.Width/2,
                                                                     (int)key.ViewY-KEYSIZE.Height/2),
                                                                     KEYSIZE);
                            evt.Graphics.FillRectangle(brush, rect);
                            evt.Graphics.DrawRectangle(pen, rect);
                            if(key.Selected) {
                                evt.Graphics.DrawString("(x: "+key.X+" y: "+key.Y.ToString("0.0")+")", Paintkit.FontHelvetica8, Paintkit.BrushSolidDarkGray, new Point(key.ViewX+10, (int)key.ViewY-10));
                            }
                        }
                    }
                }
            }
            #endregion
        }
        #endregion

        #region Event-Handling

        /* called at startup and when coordinate system needs update */
        private void TimeLineControl_Update(object sender, EventArgs evt) {
            this.fzoom = ((float)zoom)*0.01f;
            this.wcenter = new Point(Width/2, Height/2);
            Guikit.ViewFactor = new PointF(fzoom, Height/100f);
            Invalidate();
        }

        private void TimeLineControl_Scroll(object sender, ScrollEventArgs evt) {
            Invalidate();
        }

        /* adding new key point nodes */
        private void TimeLineControl_MouseClick(object sender, MouseEventArgs evt) {
            if(evt.Button == MouseButtons.Right) {
                if(selectedLayer!=null) {
                    if(!selectedLayer.Locked) {
                        // finally create new node
                        ServoKeyPoint key = new ServoKeyPoint(Guikit.v2m4x(evt.Location.X), Guikit.v2m4y(evt.Location.Y));
                        selectedLayer.ServoKeyPoints.Add(key);
                        // create start node if not defined yet
                        if(!selectedLayer.hasStartNode()) {
                            ServoKeyPoint start = new ServoKeyPoint(Guikit.v2m4x(0), Guikit.v2m4y(wcenter.Y));
                            start.setStartNode();
                            selectedLayer.ServoKeyPoints.Add(start);
                        }
                        Invalidate();
                    }
                }
            }
        }

        private void TimeLineControl_MouseDown(object sender, MouseEventArgs evt) {
            if(evt.Button == MouseButtons.Left) {
                if(isKeyPointInSelectionRange(evt.Location)) {
                    multiSelection = false;
                    showMultiSelection = false;
                    // add node to selection if there's any within selection range
                    ServoKeyPoint selected = getNearestKeyPointInSelectionRange(evt.Location);
                    selected.Selected = true;
                    // add key point to current selection
                    if(!cselection.Contains(selected)) {
                        cselection.Add(selected);
                    }
                } else {
                    // change to multi selection mode if no node is currently selected, otherwise move selected nodes
                    if(cselection.Count==0) {
                        multiSelection = true;
                        showMultiSelection = true;
                        multiSelectionStart = evt.Location;
                        multiSelectionFinish = evt.Location;
                    } else {
                        if(!isKeyPointInSelectionRange(evt.Location)) {
                            clearSelection();
                            multiSelectionRect = new Rectangle();
                        }
                    }
                }
                // update gui
                Invalidate();
            }
        }

        private void TimeLineControl_MouseMove(object sender, MouseEventArgs evt) {
            if(evt.Button == MouseButtons.Left) {
                // move every selected node according to the mouse movement
                if(cselection.Count>0) {
                    if(prevLocation != new Point(int.MaxValue, int.MaxValue)) {
                        foreach(ServoKeyPoint key in cselection) {
                            if(key.isStartNode()) {
                                // don't move start node in x-axis
                                move(key, 0, evt.Location.Y-prevLocation.Y);
                            } else {
                                // move all other nodes freely
                                move(key, evt.Location.X-prevLocation.X, evt.Location.Y-prevLocation.Y);
                            }
                        }
                    }
                    prevLocation = evt.Location;
                }
                // update multi selection rectangle
                if(multiSelection) {
                    multiSelectionFinish = evt.Location;
                }
                // update gui
                Invalidate();
            }
        }

        private void TimeLineControl_MouseUp(object sender, MouseEventArgs evt) {
            if(evt.Button == MouseButtons.Left) {
                // select all nodes within rectangle if multi selection was active
                if(multiSelection) {
                    if(isAnyWithinRectangle(ref multiSelectionRect)) {
                        clearSelection();
                        #region Select All Key Points within Selection Rectangle
                        if(servoLayers!=null) {
                            foreach(ServoLayer layer in servoLayers) {
                                if(layer.Visible && !layer.Locked) {
                                    foreach(ServoKeyPoint key in layer.ServoKeyPoints) {
                                        if(isWithinRectangle(key, ref multiSelectionRect)) {
                                            key.Selected = true;
                                            // add key point to current selection
                                            if(!cselection.Contains(key)) {
                                                cselection.Add(key);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        #endregion
                    } else {
                        clearSelection();
                    }
                }
                // snap all x coordinates to a multiple of 10
                foreach(ServoKeyPoint key in cselection) {
                    key.snap();
                }
                // reset previous position to start next selection
                prevLocation = new Point(int.MaxValue, int.MaxValue);
                // hide multi selection rectangle
                showMultiSelection = false;
                // update gui
                Invalidate();
            }
        }

        private void TimeLineControl_KeyUp(object sender, KeyEventArgs evt) {
            #region Shift Modifier
            int multiplier = evt.Modifiers == Keys.Shift ? 10 : 1;
            #endregion
            if(evt.KeyCode == Keys.Delete) {
                if(servoLayers!=null && cselection.Count>0) {
                    foreach(ServoKeyPoint key in cselection) {
                        if(!key.isStartNode()) {
                            for(int l=servoLayers.Count-1; l>=0; l--) {
                                for(int k=servoLayers[l].ServoKeyPoints.Count-1; k>=0; k--) {
                                    if(key==servoLayers[l].ServoKeyPoints[k]) {
                                        servoLayers[l].ServoKeyPoints.Remove(key);
                                    }
                                }
                            }
                        }
                    }
                }
            } else if(evt.KeyCode == Keys.Up) {
                foreach(ServoKeyPoint key in cselection) {
                    move(key, 0, multiplier*-1);
                }
            } else if(evt.KeyCode == Keys.Down) {
                foreach(ServoKeyPoint key in cselection) {
                    move(key, 0, multiplier);
                }
            } else if(evt.KeyCode == Keys.Left) {
                foreach(ServoKeyPoint key in cselection) {
                    move(key, multiplier*-Globals.DEFAULT_SERVO_RESOLUTION_X, 0);
                    key.snap();
                }
            } else if(evt.KeyCode == Keys.Right) {
                foreach(ServoKeyPoint key in cselection) {
                    move(key, multiplier*Globals.DEFAULT_SERVO_RESOLUTION_X, 0);
                    key.snap();
                }
            }
            // update gui
            Invalidate();
        }
        #endregion

    }

}

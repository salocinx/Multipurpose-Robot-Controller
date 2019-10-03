
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

    #region Delegates (Network)
    public delegate void OnLogbookEntrySelection(string timestamp, string value);
    #endregion

    public partial class SensorLogbookView : UserControl {

        #region Fields
        private Sensor sensor;
        private float zoom;
        private int currentX;
        private LogbookEntry selection;
        #endregion

        #region Constants
        private Size SIZE = new Size(4, 4);
        private float RANGE = 25;
        #endregion

        #region Events
        public event OnLogbookEntrySelection onLogbookEntrySelection;
        #endregion

        #region Lifecycle
        public SensorLogbookView() {
            InitializeComponent();
        }
        #endregion

        #region Functions
        public void setSensor(Sensor sensor) {
            this.sensor = sensor;
        }

        public void setZoom(int zoom) {
            this.zoom = zoom*0.2f;
        }

        public void setCurrentX(int currentX) {
            this.currentX = currentX;
        }

        private LogbookEntry getNearestEntryInSelectionRange(Point mouse) {
            LogbookEntry selected = null;
            foreach(LogbookEntry entry in sensor.Logbook.Entries) {
                if(selected == null) {
                    if(Toolkit.distance(entry.Position, mouse) <= RANGE) {
                        selected = entry;
                        continue;
                    }
                } else {
                    if(Toolkit.distance(entry.Position, mouse) < Toolkit.distance(selected.Position, mouse)) {
                        selected = entry;
                    }
                }
            }
            return selected;
        }
        #endregion

        #region Painting
        private void SensorLogbookView_Paint(object sender, PaintEventArgs evt) {
            #region Paint Coordinate System
            // draw dashed horizontal lines [25%, 50%, 75%]
            evt.Graphics.DrawLine(Paintkit.PenFineDashedDarkGray, new Point(0, Height/4*3), new Point(Width, Height/4*3));
            evt.Graphics.DrawLine(Paintkit.PenFineDashedDarkGray, new Point(0, Height/2), new Point(Width, Height/2));
            evt.Graphics.DrawLine(Paintkit.PenFineDashedDarkGray, new Point(0, Height/4), new Point(Width, Height/4));
            #endregion
            #region Paint Coordinate Values
            float delta = Math.Abs(sensor.Maximum-sensor.Minimum);
            evt.Graphics.DrawString(sensor.Maximum.ToString("0.0")+" ["+sensor.Postfix+"]", Paintkit.FontHelvetica8, Paintkit.BrushSolidDarkGray, new Point(currentX, 0));
            evt.Graphics.DrawString((sensor.Minimum+delta/4f).ToString("0.0")+" ["+sensor.Postfix+"]", Paintkit.FontHelvetica8, Paintkit.BrushSolidDarkGray, new Point(currentX, Height/4*3));
            evt.Graphics.DrawString((sensor.Minimum+delta/2f).ToString("0.0")+" ["+sensor.Postfix+"]", Paintkit.FontHelvetica8, Paintkit.BrushSolidDarkGray, new Point(currentX, Height/2));
            evt.Graphics.DrawString((sensor.Minimum+delta/4f*3f).ToString("0.0")+" ["+sensor.Postfix+"]", Paintkit.FontHelvetica8, Paintkit.BrushSolidDarkGray, new Point(currentX, Height/4));
            #endregion
            if(sensor.Logbook.Entries!=null) {
                #region Pre-Calculate Positions
                for(int i=0; i<sensor.Logbook.Entries.Count; i++) {
                    sensor.Logbook.Entries[i].Position = new Point((int)(zoom*i),
                                                                    Height-(int)((sensor.Logbook.Entries[i].Data+Math.Abs(sensor.Minimum))*Height/delta));
                }
                #endregion
                #region Paint Connections
                for(int i=1; i<sensor.Logbook.Entries.Count; i++) {
                    LogbookEntry e1 = sensor.Logbook.Entries[i-1];
                    LogbookEntry e2 = sensor.Logbook.Entries[i];
                    evt.Graphics.DrawLine(Paintkit.PenFineBrown, new Point(e1.Position.X, e1.Position.Y), new Point(e2.Position.X, e2.Position.Y));
                }
                #endregion
                #region Paint Sensor Values
                for(int i=0; i<sensor.Logbook.Entries.Count; i++) {
                    LogbookEntry entry = sensor.Logbook.Entries[i];
                    Rectangle rect = new Rectangle(new Point(entry.Position.X-SIZE.Width/2, entry.Position.Y-SIZE.Height/2), SIZE);
                    if(entry.Selected) {
                        evt.Graphics.FillEllipse(Paintkit.BrushSolidDarkOrange, rect);
                        evt.Graphics.DrawEllipse(Paintkit.PenFineOrange, rect);
                    } else {
                        evt.Graphics.FillEllipse(Paintkit.BrushSolidDarkGray, rect);
                        evt.Graphics.DrawEllipse(Paintkit.PenFineBlack, rect);
                    }
                }
                #endregion
            }
        }
        #endregion

        #region Event-Handling
        /* called at startup and when coordinate system needs update */
        private void SensorLogbookView_Update(object sender, EventArgs evt) {
            Invalidate();
        }

        private void SensorLogbookView_Scroll(object sender, ScrollEventArgs evt) {
            Invalidate();
        }

        private void SensorLogbookView_MouseClick(object sender, MouseEventArgs evt) {
            // deselect previous selection
            if(selection!=null) {
                selection.Selected = false;
            }
            // find closest value within range
            selection = getNearestEntryInSelectionRange(evt.Location);
            // clear text fields if no selection was made
            if(selection!=null) {
                selection.Selected = true;
                onLogbookEntrySelection?.Invoke(Toolkit.toDateTime(selection.Timestamp).ToString("dd.MM.yyyy    HH:mm:ss"), selection.Data.ToString("0.0"));
            } else {
                onLogbookEntrySelection?.Invoke(null, null);
            }
            // re-paint entire diagram
            Invalidate();
        }
        #endregion

    }

}
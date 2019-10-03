
#region Usings
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonCtrl;
#endregion

#region Delegates
public delegate void OnPositionUpdate(Vector2 position);
#endregion

namespace RemoteCtrl {

    public partial class ServoControlView : UserControl {

        #region Fields
        private Timer timer;

        private Font font;
        private Brush brush;

        private Pen pen1;
        private Pen pen2;
        private Pen pen3;

        private Point center;
        private Rectangle pointer;

        private float rotation = 0f;
        private Vector2 position = Vector2.Zero;
        private Vector2 previous = Vector2.Zero;
        #endregion

        #region Events
        public event OnPositionUpdate onPositionUpdate;
        #endregion

        #region Lifecycle
        public ServoControlView() {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.initializeTools();
            this.initializeTimer();
        }
        #endregion

        #region Properties
        public int Interval {
            get { return timer.Interval; }
            set { timer.Interval = value; }
        }

        public float Rotation {
            get { return rotation; }
            set { rotation = value; }
        }

        public Vector2 Position {
            get { return position; }
            set { position = value; }
        }
        #endregion

        #region Functions
        private void initializeTools() {
            this.font = new Font("Helvetica", 8, FontStyle.Regular);
            this.brush = new SolidBrush(Color.DarkGray);
            this.pen1 = new Pen(Color.Black, 1);
            this.pen2 = new Pen(Color.Red, 2);
            pen2.DashStyle = DashStyle.Dot;
            this.pen3 = new Pen(Color.DarkGray, 2);
            pen3.DashStyle = DashStyle.Dot;
        }

        private void initializeTimer() {
            this.timer = new Timer();
            this.timer.Tick += new EventHandler(timerElapsed);
            this.timer.Interval = 20;
            this.timer.Start();
        }

        private void timerElapsed(Object obj, EventArgs evt) {
            if(previous!=position) {
                onPositionUpdate?.Invoke(position);
                previous = position;
            }
        }
        #endregion

        #region Event-Handling (Gui)
        private void ServoControlPanel_SizeChanged(object sender, EventArgs e) {
            this.center = new Point(Size.Width/2, Size.Height/2);
            this.pointer = new Rectangle(center.X-8, center.Y-8, 16, 16);
            this.Invalidate();
        }

        private void ServoControlPanel_Paint(object sender, PaintEventArgs evt) {
            // print current position text
            if(font!=null && brush!=null) {
                evt.Graphics.DrawString("x: "+position.X.ToString("0.00")+" y: "+position.Y.ToString("0.00"), font, brush, 10, 10);
            }
            // paint horizontal center line
            evt.Graphics.DrawLine(pen3, new Point(0, center.Y), new Point(Size.Width, center.Y));
            // paint vertical center line
            evt.Graphics.DrawLine(pen3, new Point(center.X, 0), new Point(center.X, Size.Height));
            // paint mouse pointer
            evt.Graphics.DrawEllipse(pen2, pointer);
        }

        private void ServoControlPanel_MouseMove(object sender, MouseEventArgs evt) {
            if(evt.Button == MouseButtons.Left) {
                pointer = new Rectangle(evt.Location.X-8, evt.Location.Y-8, 16, 16);
                float posX = (float)(evt.Location.X-center.X)/center.X;
                float posY = (float)((evt.Location.Y-center.Y)*-1)/center.Y;
                position = new Vector2(Toolkit.clamp(posX, -1.0f, 1.0f), Toolkit.clamp(posY, -1.0f, 1.0f));
                if(rotation!=0f) {
                    // rotate current position
                    position = Toolkit.rotatePoint(position, rotation);
                    // stretch value to reach 100%
                    position.X = -(float)(position.X*(1.0/Math.Sin(Toolkit.toRadians(rotation))));
                    position.Y = -(float)(position.Y*(1.0/Math.Sin(Toolkit.toRadians(rotation))));
                    // clamp to interval 0-100%
                    position = Toolkit.clamp(position, -1f, 1f);
                }
                this.Invalidate();
            }
        }
        #endregion

    }

}
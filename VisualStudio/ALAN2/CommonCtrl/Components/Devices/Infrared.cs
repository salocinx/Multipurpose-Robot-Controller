
#region Usings
using System;
using System.Xml.Serialization;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class Infrared : Component {

        #region Fields      
        protected ushort protocol;                  // infrared protocol type (defined in Globals.cs)

        protected bool joystick;

        protected bool a;
        protected bool b;

        protected bool up;
        protected bool down;
        protected bool left;
        protected bool right;

        protected bool num0;
        protected bool num1;
        protected bool num2;
        protected bool num3;
        protected bool num4;
        protected bool num5;
        protected bool num6;
        protected bool num7;
        protected bool num8;
        protected bool num9;
        protected bool escape;
        protected bool enter;

        protected bool genlock;
        protected bool cdtv;
        protected bool power;
        protected bool rewind;
        protected bool play;
        protected bool forward;
        protected bool stop;
        protected bool volumePlus;
        protected bool volumeMinus;
        #endregion

        #region Constants
        protected const int CODE_B01 = 0x1;           // 1st bit: set if numeric keys is pressed => {[0-9], ENTER, ESC}
        protected const int CODE_B02 = 0x2;           // 2nd bit: set if media key is pressed => {VOL+, VOL-, REW, PLAY, STOP, FF, GENLOCK, CD/TV, POWER}
        protected const int CODE_B03 = 0x4;           // 3rd bit: right direction pad pressed (mouse & joystick)
        protected const int CODE_B04 = 0x8;           // 4th bit: left direction pad pressed (mouse & joystick)
        protected const int CODE_B05 = 0x10;          // 5th bit: down direction pad pressed (mouse & joystick)
        protected const int CODE_B06 = 0x20;          // 6th bit: up direction pad pressed (mouse & joystick)
        protected const int CODE_B07 = 0x40;          // 7th bit: B button pressed (mouse & joystick)
        protected const int CODE_B08 = 0x80;          // 8th bit: A button pressed (mouse & joystick)
        protected const int CODE_B09 = 0x100;         // 9th bit: not used
        protected const int CODE_B10 = 0x200;         // 10th bit: not used
        protected const int CODE_B11 = 0x400;         // 11th bit: not used
        protected const int CODE_B12 = 0x800;         // 12th bit: set if joy/mouse switch is set to "joy", otherwise not set
        #endregion

        #region Properties
        [XmlIgnore]
        public bool Joystick {
            get { return joystick; }
            set { joystick = value; }
        }

        [XmlIgnore]
        public bool A {
            get { return a; }
            set { a = value; }
        }

        [XmlIgnore]
        public bool B {
            get { return b; }
            set { b = value; }
        }

        [XmlIgnore]
        public bool Up {
            get { return up; }
            set { up = value; }
        }

        [XmlIgnore]
        public bool Down {
            get { return down; }
            set { down = value; }
        }

        [XmlIgnore]
        public bool Left {
            get { return left; }
            set { left = value; }
        }

        [XmlIgnore]
        public bool Right {
            get { return right; }
            set { right = value; }
        }

        [XmlIgnore]
        public bool Num0 {
            get { return num0; }
            set { num0 = value; }
        }

        [XmlIgnore]
        public bool Num1 {
            get { return num1; }
            set { num1 = value; }
        }

        [XmlIgnore]
        public bool Num2 {
            get { return num2; }
            set { num2 = value; }
        }

        [XmlIgnore]
        public bool Num3 {
            get { return num3; }
            set { num3 = value; }
        }

        [XmlIgnore]
        public bool Num4 {
            get { return num4; }
            set { num4 = value; }
        }

        [XmlIgnore]
        public bool Num5 {
            get { return num5; }
            set { num5 = value; }
        }

        [XmlIgnore]
        public bool Num6 {
            get { return num6; }
            set { num6 = value; }
        }

        [XmlIgnore]
        public bool Num7 {
            get { return num7; }
            set { num7 = value; }
        }

        [XmlIgnore]
        public bool Num8 {
            get { return num8; }
            set { num8 = value; }
        }

        [XmlIgnore]
        public bool Num9 {
            get { return num9; }
            set { num9 = value; }
        }

        [XmlIgnore]
        public bool Escape {
            get { return escape; }
            set { escape = value; }
        }

        [XmlIgnore]
        public bool Enter {
            get { return enter; }
            set { enter = value; }
        }

        [XmlIgnore]
        public bool Genlock {
            get { return genlock; }
            set { genlock = value; }
        }

        [XmlIgnore]
        public bool CDTV {
            get { return cdtv; }
            set { cdtv = value; }
        }

        [XmlIgnore]
        public bool Power {
            get { return power; }
            set { power = value; }
        }

        [XmlIgnore]
        public bool Rewind {
            get { return rewind; }
            set { rewind = value; }
        }

        [XmlIgnore]
        public bool Play {
            get { return play; }
            set { play = value; }
        }

        [XmlIgnore]
        public bool Forward {
            get { return forward; }
            set { forward = value; }
        }

        [XmlIgnore]
        public bool Stop {
            get { return stop; }
            set { stop = value; }
        }

        [XmlIgnore]
        public bool VolumePlus {
            get { return volumePlus; }
            set { volumePlus = value; }
        }

        [XmlIgnore]
        public bool VolumeMinus {
            get { return volumeMinus; }
            set { volumeMinus = value; }
        }

        public ushort Protocol {
            get { return protocol; }
            set { protocol=value; }
        }
        #endregion

    }

}

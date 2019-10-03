
#region Usings
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class InfraredRx : Infrared {

        #region Fields
        private ushort pin = 2;                   // pin for timer-based receiving of ir signals
        #endregion

        #region Lifecycle
        public InfraredRx() {
            // used for xml serialization ...
        }
        #endregion

        #region Properties
        public ushort Pin {
            get { return pin; }
            set { pin=value; }
        }
        #endregion

        #region Functions
        public override void open() {
            if(active) {
                arduino.initInfraredRx(pin);
            }
        }

        public override void close() {
            if(active) {
                // nothing to do yet ...
            }
        }

        public void parse(ushort  code) {
            reset();
            // is joystick bit set ?
            joystick = (code & CODE_B12) > 0;
            // handle numeric and media keys separately
            if((code & CODE_B01)==0 && (code & CODE_B02)==0) {
                #region Joystick & Mouse
                a = (code & CODE_B08)>0;
                b = (code & CODE_B07)>0;
                if((code & CODE_B03)>0) {
                    right = true;
                } else if((code & CODE_B04)>0) {
                    left = true;
                }
                if((code & CODE_B06)>0) {
                    up = true;
                } else if((code & CODE_B05)>0) {
                    down = true;
                }
                #endregion
            } else if((code & CODE_B01)>0 && (code & CODE_B02)==0) {
                #region Numeric Keys
                num0 = code == Convert.ToUInt32("000000111001", 2);
                num1 = code == Convert.ToUInt32("000000000001", 2);
                num2 = code == Convert.ToUInt32("000000100001", 2);
                num3 = code == Convert.ToUInt32("000000010001", 2);
                num4 = code == Convert.ToUInt32("000000001001", 2);
                num5 = code == Convert.ToUInt32("000000101001", 2);
                num6 = code == Convert.ToUInt32("000000011001", 2);
                num7 = code == Convert.ToUInt32("000000000101", 2);
                num8 = code == Convert.ToUInt32("000000100101", 2);
                num9 = code == Convert.ToUInt32("000000010101", 2);
                escape = code == Convert.ToUInt32("000000110001", 2);
                enter = code == Convert.ToUInt32("000000110101", 2);
                #endregion
            } else if((code & CODE_B01)==0 && (code & CODE_B02)>0) {
                #region Media Keys
                volumePlus = code == Convert.ToUInt32("000000000110", 2);
                volumeMinus = code == Convert.ToUInt32("000000111010", 2);
                rewind = code == Convert.ToUInt32("000000110010", 2);
                play = code == Convert.ToUInt32("000000001010", 2);
                stop = code == Convert.ToUInt32("000000101010", 2);
                forward = code == Convert.ToUInt32("000000011010", 2);
                genlock = code == Convert.ToUInt32("000000100010", 2);
                cdtv = code == Convert.ToUInt32("000000000010", 2);
                power = code == Convert.ToUInt32("000000010010", 2);
                #endregion
            }
        }

        private void reset() {
            joystick = false;
            a = false;
            b = false;
            up = false;
            down = false;
            left = false;
            right = false;
            num0 = false;
            num1 = false;
            num2 = false;
            num3 = false;
            num4 = false;
            num5 = false;
            num6 = false;
            num7 = false;
            num8 = false;
            num9 = false;
            escape = false;
            enter = false;
            genlock = false;
            cdtv = false;
            power = false;
            rewind = false;
            play = false;
            forward = false;
            stop = false;
            volumePlus = false;
            volumeMinus = false;
        }

        public override string ToString() {
            return name+" [D"+pin+"]";
        }
        #endregion

        #region Update
        public override void update(Component component) {
            if(GetType() == component.GetType()) {
                InfraredRx c = (InfraredRx)component;
                #region Update Properties
                this.active = c.Active;
                this.name = c.Name;
                this.protocol = c.Protocol;
                #endregion
                #region Update Key States
                this.joystick = c.Joystick;
                this.a = c.A;
                this.b = c.B;
                this.up = c.Up;
                this.down = c.Down;
                this.left = c.Left;
                this.right = c.Right;
                this.num0 = c.Num0;
                this.num1 = c.Num1;
                this.num2 = c.Num2;
                this.num3 = c.Num3;
                this.num4 = c.Num4;
                this.num5 = c.Num5;
                this.num6 = c.Num6;
                this.num7 = c.Num7;
                this.num8 = c.Num8;
                this.num9 = c.Num9;
                this.escape = c.Escape;
                this.enter = c.Enter;
                this.genlock = c.Genlock;
                this.cdtv = c.CDTV;
                this.power = c.Power;
                this.rewind = c.Rewind;
                this.play = c.Play;
                this.forward = c.Forward;
                this.stop = c.Stop;
                this.volumePlus = c.VolumePlus;
                this.volumeMinus = c.VolumeMinus;
                #endregion
            }
        }
        #endregion

    }

}

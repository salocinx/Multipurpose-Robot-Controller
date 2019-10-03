
#region Usings
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using CommonCtrl;
#endregion

namespace CommonCtrl {

    public class Paintkit {

        #region Fields
        private static bool initialized;

        private static Color colorListViewSelection = Color.FromArgb(255, 240, 136);

        private static Font helvetica8 = new Font("Helvetica", 8);

        private static Pen penFineBlack = new Pen(Color.Black, 1.0f);
        private static Pen penFineBrown = new Pen(Color.RoyalBlue, 1.0f);
        private static Pen penFineRed = new Pen(Color.Red, 1.0f);
        private static Pen penFineGray = new Pen(Color.Gray, 1.0f);
        private static Pen penFineDarkGray = new Pen(Color.DarkGray, 1.0f);
        private static Pen penFatBlack = new Pen(Color.Black, 2.0f);
        private static Pen penFatBrown = new Pen(Color.RoyalBlue, 2.0f);
        private static Pen penFatRed = new Pen(Color.Red, 2.0f);
        private static Pen penFatDarkGray = new Pen(Color.DarkGray, 2.0f);
        private static Pen penFineOrange = new Pen(Color.Orange, 1.0f);
        private static Pen penFineDashedLightGray = new Pen(Color.LightGray, 1.0f);
        private static Pen penFineDashedMediumGray = new Pen(Color.Gray, 1.0f);
        private static Pen penFineDashedDarkGray = new Pen(Color.DarkGray, 1.0f);
        private static Pen penFatDashedDarkGray = new Pen(Color.DarkGray, 2.0f);
        private static Pen penFatDashedLightGray = new Pen(Color.LightGray, 2.0f);

        private static Brush brushSolidDarkGray = new SolidBrush(Color.DarkGray);
        private static Brush brushSolidDarkOrange = new SolidBrush(Color.DarkOrange);
        private static Brush brushSolidLightGray = new SolidBrush(Color.FromArgb(128, Color.LightGray.R, Color.LightGray.G, Color.LightGray.B));
        #endregion

        #region Lifecycle
        public static void init() {
            if(!initialized) {
                penFineDashedDarkGray.DashStyle = DashStyle.Dash;
                penFineDashedLightGray.DashStyle = DashStyle.Dash;
                penFatDashedDarkGray.DashStyle = DashStyle.Dash;
                penFatDashedLightGray.DashStyle = DashStyle.Dash;
                initialized = true;
            }
        }
        #endregion

        #region Colors
        public static Color ColorListViewSelection {
            get { return colorListViewSelection; }
        }
        #endregion

        #region Fonts
        public static Font FontHelvetica8 {
            get { return helvetica8; }
        }
        #endregion

        #region Pens
        public static Pen PenFineBlack {
            get { return penFineBlack; }
        }

        public static Pen PenFineBrown {
            get { return penFineBrown; }
        }

        public static Pen PenFineRed {
            get { return penFineRed; }
        }

        public static Pen PenFatBrown {
            get { return penFatBrown; }
        }

        public static Pen PenFatRed {
            get { return penFatRed; }
        }

        public static Pen PenFatDarkGray {
            get { return penFatDarkGray; }
        }

        public static Pen PenFineGray {
            get { return penFineGray; }
        }

        public static Pen PenFineDarkGray {
            get { return penFineDarkGray; }
        }

        public static Pen PenFatBlack {
            get { return penFatBlack; }
        }

        public static Pen PenFineOrange {
            get { return penFineOrange; }
        }

        public static Pen PenFineDashedLightGray {
            get { return penFineDashedLightGray; }
        }

        public static Pen PenFineDashedMediumGray {
            get { return penFineDashedMediumGray; }
        }

        public static Pen PenFineDashedDarkGray {
            get { return penFineDashedDarkGray; }
        }

        public static Pen PenFatDashedDarkGray {
            get { return penFatDashedDarkGray; }
        }

        public static Pen PenFatDashedLightGray {
            get { return penFatDashedLightGray; }
        }
        #endregion

        #region Brushes
        public static Brush BrushSolidDarkGray {
            get { return brushSolidDarkGray; }
        }

        public static Brush BrushSolidLightGray {
            get { return brushSolidLightGray; }
        }

        public static Brush BrushSolidDarkOrange {
            get { return brushSolidDarkOrange; }
        }
        #endregion


    }

}
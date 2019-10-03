
#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class SpeechAction {

        #region Fields
        private int id;
        private string text;
        private string language;
        private int amplitude;                  // amplitude equals the volume of the voice [0, 200]; default = 100
        private int pitch;                      // pitch adjustment [0, 99]; default 50
        private int speed;                      // speed of the voice in 'words per minute' [80, 450]; default = 175
        private int wordGap;                    // gap between words (1=10ms, 10=100ms, etc.)
        #endregion

        #region Lifecycle
        public SpeechAction() {
            // used for xml serialization ...
        }

        public SpeechAction(int id) {
            this.id = id;
            this.text = "";
            this.language = "de";
            this.pitch = 50;
            this.speed = 175;
            this.amplitude = 100;
            this.wordGap = 10;
        }
        #endregion

        #region Properties
        public int Id {
            get { return id; }
            set { id = value; }
        }

        public string Text {
            get { return text; }
            set { text = value; }
        }

        public string Language {
            get { return language; }
            set { language = value; }
        }

        public int Amplitude {
            get { return amplitude; }
            set { amplitude = value; }
        }

        public int Pitch {
            get { return pitch; }
            set { pitch = value; }
        }

        public int Speed {
            get { return speed; }
            set { speed = value; }
        }

        public int WordGap {
            get { return wordGap; }
            set { wordGap = value; }
        }
        #endregion

        #region Functions
        public override string ToString() {
            return text;
        }
        #endregion

    }

}
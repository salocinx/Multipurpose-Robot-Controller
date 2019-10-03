
#region Usings
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Collections.Generic;
using CommonCtrl;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class SpeechSyntheziser {

        #region Fields
        private string executablePath;

        [NonSerialized]
        private Process process = null;
        #endregion

        #region Lifecycle
        public SpeechSyntheziser() {
            this.executablePath = @"eSpeak.exe";
        }
        #endregion

        #region Functions
        public void speak(SpeechAction action) {
            if(process == null) {
                process = new Process();
                process.EnableRaisingEvents = true;
                process.Exited += new EventHandler(ProcessExited);
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.FileName = executablePath;
                process.StartInfo.Arguments = string.Format(@"-v {0} -p {1} -s {2} -g {3} -a {4} ""{5}""", action.Language, action.Pitch, action.Speed, action.WordGap/10, action.Amplitude, action.Text);
                process.Start();
            }
        }

        public void speak(string text, string language, int pitch, int speed, int gap, int amplitude) {
            if(process == null) {
                process = new Process();
                process.EnableRaisingEvents = true;
                process.Exited += new EventHandler(ProcessExited);
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.FileName = executablePath;
                process.StartInfo.Arguments = string.Format(@"-v {0} -p {1} -s {2} -g {3} -a {4} ""{5}""", language, pitch, speed, gap/10, amplitude, text);
                process.Start();
            }
        }

        private void ProcessExited(object sender, EventArgs evt) {
            if(process != null) {
                process = null;
            }
        }
        #endregion

    }

}
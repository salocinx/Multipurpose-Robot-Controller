
#region Usings
using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Collections.Concurrent;
#endregion

namespace CommonCtrl {

    [Serializable]
    #region Xml Definitions
    [XmlRoot("Logbook")]
    [XmlInclude(typeof(LogbookEntry))]
    #endregion
    public class Logbook {

        #region Fields
        private uint capacity;
        private string filepath;
        private List<LogbookEntry> entries = new List<LogbookEntry>();
        private readonly object syncobj = new object();
        #endregion

        #region Lifecycle
        public Logbook() {
            // used for xml serialization ...
        }

        public Logbook(string filepath, uint capacity) {
            this.filepath = filepath;
            this.capacity = capacity;
        }
        #endregion

        #region Properties
        public uint Capacity {
            get { return capacity; }
            set { capacity = value; }
        }

        public string Filepath {
            get { return filepath; }
            set { filepath = value; }
        }

        public List<LogbookEntry> Entries {
            get { return entries; }
            set { entries = value; }
        }
        #endregion

        #region Functions
        public void store() {
            try {
                using(TextWriter writer = new StreamWriter(filepath)) {
                    XmlSerializer serializer = new XmlSerializer(typeof(Logbook));
                    serializer.Serialize(writer, this);
                }
            } catch(Exception ex) {
                #region Logbook
                Logger.Log(Level.WARNING, " Could not store sensor log book: "+filepath, ex);
                #endregion
            }
        }

        public static string getFilepath(string filename) {
            // construct log directory
            string logdir = Directory.GetCurrentDirectory()+"/Logbooks";
            // create directory if not existent
            if(!Directory.Exists(logdir)) Directory.CreateDirectory(logdir);
            // create file if not existent, otherwise read-in to local field
            return logdir+"/"+filename+".xml";
        }

        public void append(LogbookEntry entry) {
            lock(syncobj) {
                #region Keep Log Capacity
                if(entries.Count>=capacity) {
                    entries.RemoveAt(0);
                }
                #endregion
                entries.Add(entry);
            }
        }
        #endregion

    }

    #region Class: Logbook Entry
    [Serializable]
    public class LogbookEntry {

        #region Fields
        private long timestamp;
        private float data;
        [NonSerialized]
        private bool selected;
        [NonSerialized]
        private Point position;
        #endregion

        #region Lifecycle
        public LogbookEntry() {
            // used for xml serialization ...
        }
        
        #endregion

        #region Properties
        public long Timestamp {
            get { return timestamp; }
            set { timestamp=value; }
        }

        public float Data {
            get { return data; }
            set { data = value; }
        }

        [XmlIgnore]
        public bool Selected {
            get { return selected; }
            set { selected = value; }
        }

        [XmlIgnore]
        public Point Position {
            get { return position; }
            set { position = value; }
        }

        #endregion

    }
    #endregion

}
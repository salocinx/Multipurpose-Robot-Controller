
#region Usings
using System;
using System.IO;
#endregion

namespace CommonCtrl {

    public static class Logger {

        private static Level fileLevel;
        private static Level consoleLevel;

        private static readonly TextWriter tw;
        private static readonly object syncobj = new object();

        public static event OnNewLineReported onNewLineReported;

        static Logger() { 
            try {
                fileLevel = Level.WARNING;
                consoleLevel = Level.INFO;
                tw = TextWriter.Synchronized(File.AppendText("log.txt"));
            } catch(Exception ex) {
                Logger.Log(Level.WARNING, "Could not open log file.", ex);
            }
        }

        public static void Log(Level level, String message) {
            if(message!=null) {
                Logger.Log(level, message, null, true);
            }
        }

        public static void Log(Level level, String message, bool condition) {
            if(message!=null && condition) {
                Logger.Log(level, message, null, condition);
            }
        }

        public static void Log(Level level, Exception exception) {
            if(exception!=null && exception.Message!=null) {
                Logger.Log(level, exception.Message, exception, true);
            }
        }

        public static void Log(Level level, Exception exception, bool condition) {
            if(exception!=null && exception.Message!=null && condition) {
                Logger.Log(level, exception.Message, exception, condition);
            }
        }

        public static void Log(Level level, String message, Exception exception) {
            if(exception!=null && message!=null && exception.Message!=null) {
                Logger.Log(level, message, exception, true);
            }
        }

        public static void Log(Level level, String message, Exception exception, bool condition) {
            if(condition) {
                lock(syncobj) {
                    if(exception==null) {
                        String line1 = String.Format("{0}: {1} {2}: {3}", level.ToString(), DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString(), message);
                        if(level>=consoleLevel) {
                            Console.WriteLine(line1);
                            onNewLineReported?.Invoke(line1);
                        }
                        if(level>=fileLevel) {
                            if(tw!=null) {
                                tw.WriteLine(line1);
                                tw.Flush();
                            }
                        }
                    } else {
                        String line1 = String.Format("{0}: {1} {2}: {3}", level.ToString(), DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString(), message);
                        String line2 = String.Format("  {0}\n", exception.ToString());
                        if(level>=consoleLevel) {
                            Console.WriteLine(line1);
                            Console.WriteLine(line2);
                            onNewLineReported?.Invoke(line1);
                            onNewLineReported?.Invoke(line2);
                        }
                        if(level>=fileLevel) {
                            if(tw!=null) {
                                tw.WriteLine(line1);
                                tw.WriteLine(line2);
                                tw.Flush();
                            }
                        }
                    }
                }
            }
        }

        public static Level FileLevel {
            get { return fileLevel; }
            set { fileLevel = value; }
        }

        public static Level ConsoleLevel {
            get { return consoleLevel; }
            set { consoleLevel = value; }
        }

        public static void Close() {
            if(tw!=null) {
                tw.Close();
            }
        }

    }

}
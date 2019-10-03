
#region Usings
using System;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Management;
using System.Xml;
using System.Xml.Serialization;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using CommonCtrl;
#endregion

namespace AgentCtrl {

    public class Program {

        #region Fields
        private static volatile bool launched = false;
        private static volatile Controller controller;
        private static volatile ActionLibrary actionLibrary;

        private static Thread autosaveThread;
        private static volatile bool autosaving = true;
        private static readonly object autosaveLock = new object();
        #endregion

        #region Events
        // redirect exit event to custom clean-up function
        // keeps it from getting garbage collected: pinvoke
        private static ConsoleEventDelegate handler;
        private delegate bool ConsoleEventDelegate(int eventType);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);
        #endregion

        #region Construction
        public static void Main(string[] args) {
            
            // configure logger levels
            Logger.FileLevel = Level.WARNING;
            Logger.ConsoleLevel = Level.INFO;

            // set formatting style
            Program.setCultureInfo();
            // register for exit event
            Program.initExitHandler();

            // initialize hardware and components
            Program.initController();
            Program.initActionLibrary();
            Program.Controller.launch();

            // initialize auto saving
            autosaveThread = new Thread(autosave);
            autosaveThread.Start();

            // notify components
            Program.Launched = true;

        }

        private static void setCultureInfo() {
            // set float decimal separator for uniform network exchange floating point numbers
            CultureInfo customCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = customCulture;
            CultureInfo.DefaultThreadCurrentCulture = customCulture;
        }

        private static void initExitHandler() {
            Program.handler = new ConsoleEventDelegate(ConsoleEventCallback);
            SetConsoleCtrlHandler(handler, true);
        }

        private static void initController() {
            // create or load settings from xml file
            if(File.Exists(@"Settings.xml")) {
                #region Load Settings
                try {
                    using(FileStream stream = new FileStream(@"Settings.xml", FileMode.Open)) {
                        XmlSerializer serializer = new XmlSerializer(typeof(Controller));
                        XmlReader reader = XmlReader.Create(stream);
                        Program.Controller = (Controller)serializer.Deserialize(reader);
                    }
                } catch(Exception ex) {
                    #region Logbook
                    Logger.Log(Level.WARNING, " Could not load agent controller settings.", ex);
                    #endregion
                }
                #endregion
            } else {
                #region Create Settings
                Program.Controller = new Controller();
                Program.Controller.defaults(askConfigurationType());
                Program.Controller.store();
                #endregion
            }
        }

        private static string askConfigurationType() {
            Console.WriteLine("");
            Console.Write("Select default configuration {0: EMPTY; 1: WALL-E; 2: ALAN-II; 3: SUPERVISION}: ");
            string input = Console.ReadLine();
            Console.WriteLine("");
            if(input!=null && input.ToCharArray().Length==1) {
                int type;
                if(int.TryParse(input, out type)) {
                    switch(type) {
                        case 0:
                            return "EMPTY";
                        case 1:
                            return "WALL-E";
                        case 2:
                            return "ALAN-II";
                        case 3:
                            return "SUPERVISION";
                        default:
                            return "EMPTY";
                    }
                }
            }
            return "EMPTY";
        }

        private static void initActionLibrary() {
            // create or load library from xml file
            if(File.Exists(@"Library.xml")) {
                #region Load Library
                try {
                    using(FileStream stream = new FileStream(@"Library.xml", FileMode.Open)) {
                        XmlSerializer serializer = new XmlSerializer(typeof(ActionLibrary));
                        XmlReader reader = XmlReader.Create(stream);
                        Program.ActionLibrary = (ActionLibrary)serializer.Deserialize(reader);
                    }
                } catch(Exception ex) {
                    #region Logbook
                    Logger.Log(Level.WARNING, " Could not load action library.", ex);
                    #endregion
                }
                #endregion
            } else {
                #region Create Library
                Program.ActionLibrary = new ActionLibrary();
                Program.ActionLibrary.defaults();
                Program.ActionLibrary.store();
                #endregion
            }
        }
        #endregion

        #region Destruction
        private static void exitWithUserInteraction(string message) {
            Console.WriteLine("\n"+message);
            Console.WriteLine("\nPress any key to exit.");
            Console.Read();
            Environment.Exit(1);
        }

        public static bool ConsoleEventCallback(int eventType) {
            if(eventType == 2) {
                Program.terminate();
                Thread.Sleep(256);
            }
            return false;
        }

        public static void terminate() {
            // autosaving settings every minute, 
            // also called shortly before the
            // application is terminated
            Program.terminateAutosave();
            // close network resources
            Program.Controller.terminate();
            // close logger resources
            Logger.Close();
            // avoid anything from being started again
            Program.Launched = false;
        }
        #endregion

        #region Properties
        public static bool Launched {
            get { return launched; }
            set { launched = value; }
        }

        public static Controller Controller {
            get { return controller; }
            set { controller = value; }
        }

        public static ActionLibrary ActionLibrary {
            get { return actionLibrary; }
            set { actionLibrary = value; }
        }
        #endregion

        #region Autosave
        private static void autosave() {
            while(autosaving) {
                lock(autosaveLock) {
                    Monitor.Wait(autosaveLock, TimeSpan.FromMinutes(1));
                }
                controller.store();
                actionLibrary.store();
            }
        }

        private static void terminateAutosave() {
            autosaving = false;
            lock(autosaveLock) {
                Monitor.Pulse(autosaveLock);
            }
        }
        #endregion

    }

}

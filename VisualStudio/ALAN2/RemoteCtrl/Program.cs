
#region Usings
using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public static class Program {

        [STAThread]
        static void Main() {
            // configure logger
            Logger.FileLevel = Level.WARNING;
            Logger.ConsoleLevel = Level.INFO;
            // show splash screen
            SplashScreen.ShowSplashScreen();
            Thread.Sleep(2500);
            SplashScreen.CloseForm();
            Thread.Sleep(250);
            // launch udp listener
            UdpNetworkClient.getInstance().launch();
            // initialize graphical user interface
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(RemoteGui.getInstance());
            // don't call anything here,
            // it will not be executed ...
        }

    }

}
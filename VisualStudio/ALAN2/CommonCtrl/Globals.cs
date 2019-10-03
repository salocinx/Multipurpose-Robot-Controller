
#region Usings
using System;
using Emgu.CV;
using Emgu.CV.Structure;
using CommonCtrl;
#endregion

#region Enumerations
public enum Level {
    FINE, INFO, WARNING, ERROR, FATAL, NONE
};

public enum InfraredProtocol {
    Amiga, Aiwa, Denon, NEC, JVC, LG, RC56, Lego, Sharp, Sony, Sanyo, Samsung, Panasonic
};
#endregion

#region Delegates (Camera)
public delegate void OnCameraImageCaptured(Camera camera, Mat frame);
public delegate void OnStereoImageCaptured(Camera camera, Mat leftFrame, Mat rightFrame, Mat stereoFrame);
#endregion

#region Delegates (Network)

public delegate void OnNetworkStatisticsUpdated();
public delegate void OnNetworkPacketReceived(NetworkPacket packet);

public delegate void OnConsoleOutputPacketReceived(ConsoleOutput packet);
public delegate void OnBeaconSignalPacketReceived(BeaconSignal packet);
public delegate void OnSystemStatusPacketReceived(SystemStatus packet);
public delegate void OnRoundTripTimePackedReceived(RoundTripTime packet);
public delegate void OnNetworkStatusPacketReceived(NetworkStatus packet);
public delegate void OnActionLibraryPacketReceived(ActionLibrary packet);
public delegate void OnCameraImagePacketReceived(CameraImage packet);

public delegate void OnNetworkClientDisconnected(string systemId);

#endregion

#region Delegates (Arduino)

public delegate void OnNewLineReported(string line);
public delegate void OnRoundTripUpdate(int loopTime, short freeRam, int bytesSent, int bytesReceived);

public delegate void OnGpsUpdate(ushort satellites, float latitude, float longitude, float altitude, float speed);
public delegate void OnGyroscopeUpdate(short ax, short ay, short az, short gx, short gy, short gz);
public delegate void OnSensorUpdate(ushort componentId, short value);
public delegate void OnInfraredSignalUpdate(ushort signal, ushort bits);

#endregion

public static class Globals {

    #region Constants (Arduino)
    public const string CONTROLLER = "[c#0]";
    public const string MONITORING = "[m#3]";

    public const int MAX_LOOP_TIME = 750;                 // maximal loop time in [us] before warning is displayed
    public const int DEFAULT_SERVO_RESOLUTION_X = 20;     // lowest resolution in [ms] for defining servo actions in the gui
    public const int DEFAULT_SERVO_INTERVAL = 10;         // default rate in [ms] to update servo motors on the Arduino when automatic targeting is enabled (10ms=100Hz)
    public const int DEFAULT_SONAR_INTERVAL = 150;        // keep this value above or equal to 32ms, since an ultrasonic sensor needs for an RTT on ~3m at least 32ms to be reflected
    #endregion

    #region Constants (Network)
    public const int kB = 1024;
    public const int MB = 1024*kB;

    public const char STX = '\x02';
    public const char ETX = '\x03';
    public static char[] delimiter = { '#' };

    public const int AGENT_ALIVE_TIMEOUT = 5000;
    public const int NETWORK_UDP_PORT = 19630;
    public const int NETWORK_TCP_PORT = 19650;
    public const int NETWORK_RTP_PORT = 19680;

    public const int BUFFER_SIZE_UDP = 512;
    public const int BUFFER_SIZE_TCP = 8*kB;
    public const int BUFFER_SIZE_RTP = 128*kB;
    #endregion

    #region Constants (Thermistor)
    // nominal temperature value for the thermistor
    public const double TERMISTORNOMINAL = 10000;
    // nominl temperature depicted on the datasheet
    public const double TEMPERATURENOMINAL = 25;
    // beta value for our thermistor
    public const double BCOEFFICIENT = 3977;
    // value of the series resistor
    public const double SERIESRESISTOR = 10000;
    #endregion

    #region Constants (GUI)
    // maximal time a single servo action may consume [sec]
    public const int SERVO_LIBRARY_WORKSPACE = 120;
    #endregion

}
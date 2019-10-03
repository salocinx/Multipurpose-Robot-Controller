
#region Usings
using System;
using System.Net;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using NativeWifi;
using DirectShowLib;
#endregion

namespace CommonCtrl {

    public class Toolkit {

        #region Fields
        private static readonly Random random = new Random();
        private static readonly DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        #endregion

        #region Time
        public static long CurrentTimeMillis() {
            return (long)(DateTime.UtcNow-Jan1st1970).TotalMilliseconds;
        }

        public static DateTime toDateTime(long timestamp) {
            return Jan1st1970.AddMilliseconds(timestamp);
        }
        #endregion

        #region Strings
        public static byte[] toFixedByteArray(string input, int length) {
            return Encoding.UTF8.GetBytes(input.PadRight(length, ' '));
        }

        public static string fromFixedByteArray(byte[] input) {
            return Encoding.UTF8.GetString(input).Trim();
        }

        public static string toHexFormat(byte value) {
            string str = value.ToString("X4");
            StringBuilder sb = new StringBuilder(str);
            sb[1] = 'x';
            return sb.ToString();
        }
        public static string toHexFormat(ushort value) {
            string str = value.ToString("X4");
            StringBuilder sb = new StringBuilder(str);
            sb[1] = 'x';
            return sb.ToString();
        }

        public static string toHexFormat(uint value) {
            string str = value.ToString("X4");
            StringBuilder sb = new StringBuilder(str);
            sb[1] = 'x';
            return sb.ToString();
        }
        #endregion

        #region Integers
        public static int round(int value, int interval) {
            return ((int)Math.Round(value/((float)interval)))*interval;
        }
        #endregion

        #region Random
        public static int getRandomInt(int minimum, int maximum) {
            return random.Next(minimum, maximum);
        }

        public static float getRandomFloat(float minimum, float maximum) {
            return (float)random.NextDouble()*(maximum-minimum)+minimum;
        }
        #endregion

        #region Network
        public static bool isNetworkAvailable(bool first) {
            IPAddress ipv4 = getNetworkAdress(first);
            return !ipv4.ToString().Equals("127.0.0.1");
        }

        public static IPAddress getNetworkAdress(bool first) {
            if(first) {
                foreach(IPAddress address in Dns.GetHostAddresses(Dns.GetHostName())) {
                    if(address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
                        return address;
                    }
                }
                return null;
            } else {
                bool firstAddressFound = false;
                foreach(IPAddress address in Dns.GetHostAddresses(Dns.GetHostName())) {
                    if(address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
                        if(firstAddressFound) {
                            return address;
                        } else {
                            firstAddressFound = true;
                        }
                    }
                }
                return getNetworkAdress(true);
            }
        }

        public static IPAddress getBroadcastAddress(bool first) {
            IPAddress ipv4 = getNetworkAdress(first);
            if(ipv4==null) {
                return IPAddress.Loopback;
            } else {
                byte[] bytes = ipv4.GetAddressBytes();
                bytes[3] = 255;
                return new IPAddress(bytes);
            }
        }
        #endregion

        #region Geometry
        public static float PI {
            get { return (float)Math.PI; }
        }

        public static float PI2 {
            get { return (float)(Math.PI*2.0); }
        }

        public static float Pi(float multiplicator) {
            return (float)(Math.PI*multiplicator);
        }

        public static float Pi2(float multiplicator) {
            return (float)(Math.PI*2.0*multiplicator);
        }

        public static float toDegrees(float angle) {
            return angle*(180.0f/PI);
        }

        public static float toRadians(float angle) {
            return angle*(PI/180.0f);
        }

        public static float addAngle(float angle, float value) {
            angle += value;
            return Toolkit.normalizeAngle(angle);
        }

        public static float subtractAngle(float angle, float value) {
            angle -= value;
            return Toolkit.normalizeAngle(angle);
        }

        public static float normalizeAngle(float angle) {
            if (angle>Toolkit.PI2) {
                angle -= Toolkit.PI2;
            } else if (angle<0f) {
                angle = Toolkit.PI2+angle;
            }
            return angle;
        }

        public static int clamp(int value, int min, int max) {
            if (value<min) {
                value = min;
            } else if (value>max) {
                value = max;
            }
            return value;
        }

        public static float clamp(float value, float min, float max) {
            if (value<min) {
                value = min;
            } else if (value>max) {
                value = max;
            }
            return value;
        }

        public static Vector2 clamp(Vector2 value, float min, float max) {
            if(value.X<min) {
                value.X = min;
            } else if(value.X>max) {
                value.X = max;
            }
            if(value.Y<min) {
                value.Y = min;
            } else if(value.Y>max) {
                value.Y = max;
            }
            return value;
        }

        public static float distance(Vector2 point1, Vector2 point2) {
            if (point1.isNan() || point2.isNan()) {
                return 0;
            } else {
                return (float)Math.Sqrt(Math.Pow(point1.X-point2.X, 2)+Math.Pow(point1.Y-point2.Y, 2));
            }
        }

        public static float distance(Point point1, Point point2) {
            return (float)Math.Sqrt(Math.Pow(point1.X-point2.X, 2)+Math.Pow(point1.Y-point2.Y, 2));
        }

        public static float distance(PointF point1, PointF point2) {
            return (float)Math.Sqrt(Math.Pow(point1.X-point2.X, 2)+Math.Pow(point1.Y-point2.Y, 2));
        }

        public static float distance(float x1, float y1, float x2, float y2) {
            return (float)Math.Sqrt(Math.Pow(x1-x2, 2)+Math.Pow(y1-y2, 2));
        }

        public static Vector2 createRadialPoint(float centerX, float centerY, float angle, float length) {
            float x = (float)(length*Math.Sin(angle)+centerX);
            float y = (float)(-length*Math.Cos(angle)+centerY);
            return new Vector2(x, y);
        }

        public static Vector2 rotatePoint(Vector2 point, float angle) {
            return rotatePoint(point.X, point.Y, angle);
        }

        public static Vector2 rotatePoint(float pointX, float pointY, float angle) {
            angle = Toolkit.toRadians(angle);
            double newX = Math.Cos((float)angle)*pointX-Math.Sin((float)angle)*pointY;
            double newY = Math.Cos((float)angle)*pointY+Math.Sin((float)angle)*pointX;
            return new Vector2((float)newX, (float)newY);
        }

        public static bool isAngleWithinTolerance(float cangle, float tangle, float tolerance) {
            float aminus = tangle-tolerance;
            float aplus = tangle+tolerance;
            if (aminus<0) {
                aminus = Toolkit.PI2-aminus;
            } else if (aplus>Toolkit.PI2) {
                aplus = Toolkit.PI2-aplus;
            }
            return cangle>=aminus && cangle<=aplus;
        }

        public static float differenceBetweenAngles(float current, float target) {
            float diff = (float)Math.Abs(current-target)%Toolkit.PI2;
            if (diff > Toolkit.PI) {
                diff = Toolkit.PI2 - diff;
            }
            return Math.Abs(diff);
        }

        public static float angleBetweenThreePoints(Vector2 center, Vector2 point1, Vector2 point2) {
            return (float)(Math.Atan2(point2.Y-center.Y, point2.X-center.X) - Math.Atan2(point1.Y-center.Y, point1.X-center.X));
        }

        public static float angleToAxis(Vector2 currentRobotPosition, Vector2 targetRobotPosition) {
            Vector2 vector1 = new Vector2(0f, 1f);
            Vector2 vector2 = new Vector2(targetRobotPosition.X-currentRobotPosition.X, targetRobotPosition.Y-currentRobotPosition.Y);
            double angle = Math.Atan2(vector2.Y, vector2.X)-Math.Atan2(vector1.Y, vector1.X);
            angle += Math.PI;
            if (angle<0) {
                angle += Math.PI*1.5+Math.PI/2.0;
            }
            return Toolkit.normalizeAngle(((float)angle));
        }

        public static bool isClockwise(float currentRobotRotation, Vector2 currentRobotPosition, Vector2 targetRobotPosition) {
            float angleToAxis = Toolkit.angleToAxis(currentRobotPosition, targetRobotPosition);
            float angle = angleToAxis-currentRobotRotation;
            if (angle<0) {
                angle = Toolkit.PI2+angle;
            }
            return angle>=0 && angle<=Toolkit.PI;
        }

        public static Vector2 findLineLineIntersection(Vector2 pstart1, Vector2 pend1, Vector2 pstart2, Vector2 pend2) {
            // get A,B,C of first line - points : ps1 to pe1
            float A1 = pend1.Y-pstart1.Y;
            float B1 = pstart1.X-pend1.X;
            float C1 = A1*pstart1.X+B1*pstart1.Y;
            // get A,B,C of second line - points : ps2 to pe2
            float A2 = pend2.Y-pstart2.Y;
            float B2 = pstart2.X-pend2.X;
            float C2 = A2*pstart2.X+B2*pstart2.Y;
            // get delta and check if the lines are parallel
            float delta = A1*B2 - A2*B1;
            if (delta == 0) return Vector2.NaN;
            // now return the Vector2 intersection point
            return new Vector2((B2*C1 - B1*C2)/delta, (A1*C2 - A2*C1)/delta);
        }

        public static int findLineCircleIntersections(float cx, float cy, float radius, Vector2 point1, Vector2 point2, out Vector2 intersection1, out Vector2 intersection2) {

            float dx, dy, A, B, C, det, t;

            dx = point2.X - point1.X;
            dy = point2.Y - point1.Y;

            A = dx * dx + dy * dy;
            B = 2 * (dx * (point1.X - cx) + dy * (point1.Y - cy));
            C = (point1.X - cx) * (point1.X - cx) + (point1.Y - cy) * (point1.Y - cy) - radius * radius;

            det = B * B - 4 * A * C;
            if ((A <= 0.0000001) || (det < 0)) {
                // No real solutions.
                intersection1 = Vector2.NaN;
                intersection2 = Vector2.NaN;
                return 0;
            } else if (det == 0) {
                // One solution.
                t = -B / (2 * A);
                intersection1 = new Vector2(point1.X + t * dx, point1.Y + t * dy);
                intersection2 = Vector2.NaN;
                return 1;
            } else {
                // Two solutions.
                t = (float)((-B + Math.Sqrt(det)) / (2 * A));
                intersection1 = new Vector2(point1.X + t * dx, point1.Y + t * dy);
                t = (float)((-B - Math.Sqrt(det)) / (2 * A));
                intersection2 = new Vector2(point1.X + t * dx, point1.Y + t * dy);
                return 2;
            }

        }
        #endregion

    }

}

#region Usings
using System;
using System.Drawing;
#endregion

namespace CommonCtrl {

    public class Vector2 {

        private float x;
        private float y;

        public Vector2() { }

        public Vector2(float x, float y) {
            this.x = x;
            this.y = y;
        }

        public float X {
            get { return x; }
            set { this.x = value; }
        }

        public float Y {
            get { return y; }
            set { this.y = value; }
        }

        public Vector2 copy() {
            return new Vector2(x, y);
        }

        public static bool operator ==(Vector2 v1, Vector2 v2) {
            // if both are null or both are same instance
            if (System.Object.ReferenceEquals(v1, v2)) {
                return true;
            }
            // if one is null, but not both, return false
            if (((object)v1 == null) || ((object)v2 == null)) {
                return false;
            }
            // return true if the fields match
            return (v1.x == v2.x && v1.y == v2.y) || (v1.isNan() && v2.isNan());
        }

        public static bool operator !=(Vector2 a, Vector2 b) {
            return !(a == b);
        }

        public static Vector2 operator +(Vector2 v1, float scalar) {
            Vector2 result = new Vector2();
            result.x = v1.x + scalar;
            result.y = v1.y + scalar;
            return result;
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2) {
            Vector2 result = new Vector2();
            result.x = v1.x + v2.x;
            result.y = v1.y + v2.y;
            return result;
        }

        public static Vector2 operator -(Vector2 v1, float scalar) {
            Vector2 result = new Vector2();
            result.x = v1.x - scalar;
            result.y = v1.y - scalar;
            return result;
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2) {
            Vector2 result = new Vector2();
            result.x = v1.x - v2.x;
            result.y = v1.y - v2.y;
            return result;
        }

        public static Vector2 operator *(Vector2 v1, float scalar) {
            Vector2 result = new Vector2();
            result.x = v1.x * scalar;
            result.y = v1.y * scalar;
            return result;
        }

        public static Vector2 operator *(Vector2 v1, Vector2 v2) {
            Vector2 result = new Vector2();
            result.x = v1.x * v2.x;
            result.y = v1.y * v2.y;
            return result;
        }

        public static Vector2 operator /(Vector2 v1, float scalar) {
            Vector2 result = new Vector2();
            result.x = v1.x / scalar;
            result.y = v1.y / scalar;
            return result;
        }

        public static Vector2 operator /(Vector2 v1, Vector2 v2) {
            Vector2 result = new Vector2();
            result.x = v1.x / v2.x;
            result.y = v1.y / v2.y;
            return result;
        }

        public bool isNan() {
            return float.IsNaN(x) && float.IsNaN(y);
        }

        public PointF toPointF() {
            return new PointF(x, y);
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override bool Equals(object obj) {
            return base.Equals(obj);
        }

        public override string ToString() {
            return "{x="+x+", y="+y+"}";
        }

        public static Vector2 NaN {
            get { return new Vector2(float.NaN, float.NaN); }
        }

        public static Vector2 Zero {
            get { return new Vector2(0, 0); }
        }

    }

}

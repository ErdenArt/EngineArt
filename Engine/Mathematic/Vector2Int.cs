using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;

namespace Engine.Mathematic
{
    public struct Vector2Int
    {
        public int X { get; set; }
        public int Y { get; set; }
        /// <summary>
        /// Returns X.
        /// </summary>
        public int Width => X;
        /// <summary>
        /// Returns Y.
        /// </summary>
        public int Height => Y;
        /// <summary>
        /// Returns Vector2Int(0,0).
        /// </summary>
        public static Vector2Int Zero = new Vector2Int(0, 0);
        public static Vector2Int One = new Vector2Int(1, 1);
        public static Vector2Int XAxis = new Vector2Int(1, 0);
        public static Vector2Int YAxis = new Vector2Int(0, 1);
        
        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Vector2Int(float x, float y)
        {
            X = (int)Math.Floor(x);
            Y = (int)Math.Floor(y);
        }
        public static bool operator == (Vector2Int a, Vector2Int b)
        {
            return a.X == b.X && a.Y == b.Y;
        }
        public static bool operator !=(Vector2Int a, Vector2Int b)
        {
            return a.X != b.X || a.Y != b.Y;
        }
        // Do not use Equals or GetHashCode. Im not changing it cuz I dont know when or why you should use it.
        // And without placing it in code it will give me a warning. Kinda stupid
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static Vector2Int operator -(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.X - b.X, a.Y - b.Y);
        }
        public static Vector2Int operator +(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.X + b.X, a.Y + b.Y);
        }
        public static Vector2Int operator *(Vector2Int a, int scalar)
        {
            return new Vector2Int(a.X * scalar, a.Y * scalar);
        }
        public static Vector2Int operator /(Vector2Int a, int scalar)
        {
            return new Vector2Int(a.X / scalar, a.Y / scalar);
        }

        // Conversion from Vector2 to Vector2Int
        public static explicit operator Vector2Int(Vector2 v)
        {
            return new Vector2Int((int)v.X, (int)v.Y);
        }
        public static explicit operator Vector2Int(Point v)
        {
            return new Vector2Int(v.X, v.Y);
        }

        // Conversion back from Vector2Int to Vector2
        public static implicit operator Vector2(Vector2Int v)
        {
            return new Vector2(v.X, v.Y);
        }
        public static implicit operator Point(Vector2Int v)
        {
            return new Point(v.X, v.Y);
        }

        private const double DegToRad = Math.PI / 180;
        public static Vector2Int Rotate(Vector2Int v, double degrees)
        {
            return RotateRadians(v, degrees * DegToRad);
        }
        public static Vector2Int RotateRadians(Vector2Int v, double radians)
        {
            var ca = Math.Cos(radians);
            var sa = Math.Sin(radians);
            return new Vector2Int((int)(ca * v.X - sa * v.Y), (int)(sa * v.X + ca * v.Y));
        }
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}

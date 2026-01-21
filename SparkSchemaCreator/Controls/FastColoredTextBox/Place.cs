using System;

namespace SparkSchemaCreator.Controls.FastColoredTextBox
{
    /// <summary>
    /// Line index and char index
    /// </summary>
    public struct Place(int iChar, int iLine) : IEquatable<Place>
    {
        public int iChar = iChar;
        public int iLine = iLine;

        public void Offset(int dx, int dy)
        {
            iChar += dx;
            iLine += dy;
        }

        public readonly bool Equals(Place other)
        {
            return iChar == other.iChar && iLine == other.iLine;
        }

        public override readonly bool Equals(object? obj)
        {
            return obj is Place place && Equals(place);
        }

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(iChar, iLine);
        }

        public static bool operator !=(Place p1, Place p2)
        {
            return !p1.Equals(p2);
        }

        public static bool operator ==(Place p1, Place p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator <(Place p1, Place p2)
        {
            if (p1.iLine < p2.iLine) return true;
            if (p1.iLine > p2.iLine) return false;
            if (p1.iChar < p2.iChar) return true;
            return false;
        }

        public static bool operator <=(Place p1, Place p2)
        {
            if (p1.Equals(p2)) return true;
            if (p1.iLine < p2.iLine) return true;
            if (p1.iLine > p2.iLine) return false;
            if (p1.iChar < p2.iChar) return true;
            return false;
        }

        public static bool operator >(Place p1, Place p2)
        {
            if (p1.iLine > p2.iLine) return true;
            if (p1.iLine < p2.iLine) return false;
            if (p1.iChar > p2.iChar) return true;
            return false;
        }

        public static bool operator >=(Place p1, Place p2)
        {
            if (p1.Equals(p2)) return true;
            if (p1.iLine > p2.iLine) return true;
            if (p1.iLine < p2.iLine) return false;
            if (p1.iChar > p2.iChar) return true;
            return false;
        }

        public static Place operator +(Place p1, Place p2)
        {
            return new Place(p1.iChar + p2.iChar, p1.iLine + p2.iLine);
        }

        public static Place Empty
        {
            get { return new Place(); }
        }

        public override readonly string ToString()
        {
            return $"({iChar},{iLine})";
        }
    }
}


using System;

namespace XAFwk.Media.Imaging
{
    public struct Color
    {
        private byte a, r, g, b;

        public Color(byte a, byte r, byte g, byte b)
        {
            this.a = a;
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public static Color FromArgb(byte a, byte r, byte g, byte b)
        {
            return new Color(a, r, g, b);
        }

        //public void Set(Color c)
        //{
        //    a = c.A;
        //    r = c.R;
        //    g = c.G;
        //    b = c.B;
        //}

        public static Color Black
        {
            get { return new Color(255, 255, 255, 255); }
        }

        public byte A
        {
            get { return a; }
            set { a = value; }
        }

        public byte R
        {
            get { return r; }
            set { r = value; }
        }

        public byte G
        {
            get { return g; }
            set { g = value; }
        }

        public byte B
        {
            get { return b; }
            set { b = value; }
        }
    }
}


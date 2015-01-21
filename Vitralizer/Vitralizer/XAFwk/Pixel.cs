using System;

namespace XAFwk.Media.Imaging
{
    public struct Pixel
    {
        Color color;

        public Pixel(byte a, byte r, byte g, byte b)
        {
            color = new Color(a, r, g, b);
        }

        public Pixel(Color color)
        {
            this.color = color;
        }

        public void Set (Color color)
        {
            this.color = color;
        }

        public byte A
        {
            get { return color.A; }
            set { color.A = value; }
        }

        public byte R
        {
            get { return color.R; }
            set { color.R = value; }
        }

        public byte G
        {
            get { return color.G; }
            set { color.G = value; }
        }

        public byte B
        {
            get { return color.B; }
            set { color.B = value; }
        }
    }
}

using System;

namespace XAFwk.Media.Imaging
{
    public struct Image
    {
        private Pixel[,] pixels;
        private String path;

        public Image(Pixel[,] pixels, String path)
        {
            this.pixels = pixels;
            this.path = path;
        }

        public Image(int width, int height, Color color = Color.Black)
        {
            pixels = new Pixel[width, height];
            foreach (Pixel p in pixels) p.Set(color); 
            path = String.Empty;
        }

        public Image(Pixel[,] pixels) : this(pixels, String.Empty) { }

        public Pixel[,] Pixels
        {
            get { return pixels; }
        }

        public string Path
        {
            get { return path; }
        }

        public int Width
        {
            get { return pixels.GetLength(0); }
        }

        public int Height
        {
            get { return pixels.GetLength(1); }
        }

        public int PixelCount
        {
             get { return Width * Height; }
        }

        public Pixel this[int width, int height]
        {
            get { return pixels[width, height];  }
            set { pixels[width, height] = value; }
        }
    }
}
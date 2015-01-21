using System;
using XAFwk.Media.Imaging;

namespace XAFwk.Media.Imaging
{
    public static class Operations
    {
        private static Random random = new System.Random();

        public static double ImageDifference(Image one, Image two)
        {
            double diff = 0;
            int width = one.Width;
            int height = one.Height;
            for (int wi = 0; wi < width; wi++)
            {
                for (int hi = 0; hi < height; hi++)
                {
                    diff += PixelDifference(one[wi, hi], two[wi, hi]);
                }
            }
            return diff;
        }

        public static double PixelDifference(Pixel one, Pixel two)
        {
            //(ΔE)^2
            //http://en.wikipedia.org/wiki/Color_difference
            return (Math.Pow((one.R - two.R), 2) + Math.Pow((one.G - two.G), 2) + Math.Pow((one.B - two.B), 2));
        }

        public static Image AddImages(Image original, Image addition, int xOffset = 0, int yOffset = 0)
        {
            int width = Math.Min(addition.Width + xOffset, original.Width - xOffset);
            int height = Math.Min(addition.Height + yOffset, original.Height - yOffset);

            for (int wi = xOffset; wi < width; wi++)
            {
                for (int hi = yOffset; hi < height; hi++)
                {
                    original[wi, hi] = AddColors(original[wi, hi], addition[wi - xOffset, hi - yOffset]);
                }
            }
            return original;
        }

        public static Pixel AddColors(Pixel bkgrnd, Pixel frgrnd, bool opaque = true)
        {
            //At = Af + Ab * (1 - Af)
            //Ct = ((Cf * Af) + (Cb * Ab) * (1 - Af)
            //http://en.wikipedia.org/wiki/Alpha_compositing

            float fR = frgrnd.R / 255f;
            float fG = frgrnd.G / 255f;
            float fB = frgrnd.B / 255f;
            float fA = frgrnd.A / 255f;

            float bR = bkgrnd.R / 255f;
            float bG = bkgrnd.G / 255f;
            float bB = bkgrnd.B / 255f;
            float bA = bkgrnd.A / 255f;

            byte r = (byte)((fR + bR * (1 - fA)) * 255f);
            byte g = (byte)((fG + bG * (1 - fA)) * 255f);
            byte b = (byte)((fB + bB * (1 - fA)) * 255f);
            byte a = (byte)((fA + bA * (1 - fA)) * 255f);

            if (opaque && a != 0) a = 255;

            Pixel p = new Pixel(a, r, g, b);

            return p;
        }

        public static Color GetRandomColorFromImage(Image image)
        {
            int x = random.Next(0, image.Width);
            int y = random.Next(0, image.Height);
            byte r = image[x, y].R;
            byte g = image[x, y].G;
            byte b = image[x, y].B;
            byte a = (byte)random.Next(100, 200);
            return Color.FromArgb(r, g, b, a);
        }

        //public static Image ScaleImage(int max, Image image)
        //{
        //    int width = max, height = max;
        //    int oldWidth = image.PixelWidth;
        //    int oldHeight = image.PixelHeight;
        //    if (oldWidth >= oldHeight) height = (int)(Math.Ceiling((double)(((oldHeight * max) / oldWidth))));
        //    else width = (int)(Math.Ceiling((double)(((oldWidth * max) / oldHeight))));
        //    System.Windows.Rect rect = new System.Windows.Rect(0, 0, width, height);
        //    DrawingVisual drawingVisual = new DrawingVisual();
        //    using (DrawingContext drawingContext = drawingVisual.RenderOpen())
        //    {
        //        drawingContext.DrawImage(image, rect);
        //    }

        //    RenderTargetBitmap resizedImage = new RenderTargetBitmap(
        //        (int)rect.Width, (int)rect.Height,
        //        96, 96,
        //        PixelFormats.Default);
        //    resizedImage.Render(drawingVisual);
        //    return resizedImage;

        //}

        public static Image Copy(Image original)
        {
            Pixel[,] pixels = new Pixel[original.Width, original.Height];
            Buffer.BlockCopy(original.Pixels, 0, pixels, 0, 40000);
            return new Image(pixels);
        }
    }
}
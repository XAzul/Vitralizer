using System;
using System.Threading;
using XAFwk.Media.Imaging;

namespace Vitralizer
{
    public class Vectorizer
    {
        private Image originalImage;
        private Image currentImage;
        private Image bestImage;
        //private Thread updateThread;
        double difference = 0;
        int generations = 0;
        int polygons = 0;
        bool running = false;

        public Vectorizer(Image image)
        {
            //if (image.Width > 200 || image.Height > 200) originalImage = Operations.ScaleImage(200, image);
            //else 
            originalImage = image;
        }

        public bool Running
        {
            get { return running; }
        }

        public double Diff
        {
            get { return difference; }
        }

        public int Polygons
        {
            get { return polygons; }
        }

        public double Generations
        {
            get { return generations; }
        }

        public double DiffPercent
        {
            get
            {
                if (running)
                //195075 = 3(255)^2 Max Diff Per Pixel
                return Math.Round(difference * 100 / (195075 * originalImage.PixelCount));
                else return 100;
            }
        }

        public Image CurrentImage
        {
            get { return CurrentImage; }
        }

        public Image BestImage
        {
            get { return BestImage; }
        }

        public void Start()
        {
            currentImage = new Image(originalImage.Width, originalImage.Height);
            bestImage = new Image(originalImage.Width, originalImage.Height);
            //updateThread = new Thread(Update);
            //updateThread.Priority = ThreadPriority.Highest;
            //updateThread.SetApartmentState(ApartmentState.STA);
            //updateThread.Start();
            running = true;
        }

        public void Stop()
        {
           //updateThread.Abort();   
        }

        private void Update()
        {
            double newDiff;
            difference = Operations.ImageDifference(originalImage, currentImage);
            //while(true)
            //{
            //    Draw();
                newDiff = Operations.ImageDifference(originalImage, currentImage);
                if (difference > newDiff)
                {
                    bestImage = Operations.Copy(currentImage);
                    difference = newDiff;
                    polygons++;
                }
                else currentImage = Operations.Copy(bestImage);
                generations++;
                //GC.Collect();
                //GC.WaitForFullGCApproach();
                //GC.WaitForFullGCComplete();
            //}
        }

        private void  Draw()
        {
            //int w = u.Random.Next(1, width + 1);
            //int h = u.Random.Next(1, height + 1);
            //int xOffset = u.Random.Next(width - w + 1);
            //int yOffset = u.Random.Next(height - h + 1);
            //Image pol = PolygonGenerator.GetTriangle(p.GetRandomColorFromPixelArray(originalImage), w, h);
            //currentImage = p.AddArrays(currentImage, pol, xOffset, yOffset);
            //pol = null;
        }
    }
}

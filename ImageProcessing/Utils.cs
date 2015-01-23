using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageProcessing
{
    public static class Utils
    {

        public static Image GetMultipleImage(Image image)
        {
            int w = (image.Width / 8) * 8;
            int h = (image.Height / 8) * 8;
            Bitmap newIm = new Bitmap(image, new Size(w, h));
            return newIm;
        }

        public static Image GetInverse(Image i1)
        {
            Bitmap bm = new Bitmap(i1);
            foreach (Point p in GetEnumerator(i1))
            {
                Color c = bm.GetPixel(p.X, p.Y);
                bm.SetPixel(p.X, p.Y, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
            }
            return bm;
        }

        public static Image Add(Image i1, Image i2)
        {
            Bitmap b1 = new Bitmap(i1);
            Bitmap b2 = new Bitmap(i2);
            Bitmap b3 = new Bitmap(b1.Width, b1.Height);
            if (b1.Height != b2.Height || b1.Width != b1.Width)
                throw new Exception("Images of different size!!!!");
            foreach (Point p in GetEnumerator(i1))
            {
                Color c1 = b1.GetPixel(p.X, p.Y);
                Color c2 = b2.GetPixel(p.X, p.Y);
                b3.SetPixel(p.X, p.Y, Color.FromArgb((c1.R + c2.R) % 256, (c1.G + c2.G) % 256, (c1.B + c2.B) % 256));
            }
            return b3;
        }

        public static IEnumerable<Point> GetEnumerator(Image image)
        {
            Bitmap bm = new Bitmap(image);
            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    yield return new Point(x, y);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace API.Helpers
{
    public static class ImageProcessor
    {
        public static Bitmap Base64ToBitmap(string base64String)
        {
            Bitmap bmpReturn;

            byte[] byteBuffer = Convert.FromBase64String(base64String);
            using (MemoryStream memoryStream = new MemoryStream(byteBuffer))
            {
                bmpReturn = (Bitmap)Image.FromStream(memoryStream);
            }

            return bmpReturn;
        }

        public static string BitmapToBase64(Bitmap image)
        {
            using (var ms = new MemoryStream())
            {
                //look at what this does later
                using (var bitmap = new Bitmap(image))
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return Convert.ToBase64String(ms.GetBuffer()); //Get Base64
                }
            }
        }

        public static Bitmap ConvertToGrayScale(Bitmap image)
        {
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color c = image.GetPixel(x, y);
                    int avg = (c.R + c.G + c.B) / 3;
                    image.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                }
            }
            return image;
        }
        
        public static Bitmap InvertColor(Bitmap image)
        {
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color c = image.GetPixel(x, y);
                    image.SetPixel(x, y, Color.FromArgb(255-c.R, 255-c.G, 255-c.B));
                }
            }
            return image;
        }

        public static Bitmap DarkenImage(Bitmap image)
        {
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color c = image.GetPixel(x, y);
                    image.SetPixel(x, y, Color.FromArgb(c.R/5, c.G/5, c.B/5));
                }
            }
            return image;
        }
    }
}
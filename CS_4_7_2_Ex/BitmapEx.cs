using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CS_4_7_2_Ex
{
    class BitmapEx
    {
        public void makePng()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"TAPSONIC_TOP_");
            sb.Append(DateTime.Now.ToString("yyyyMMddHHmmss"));
            sb.Append(@".png");
            Console.WriteLine(sb.ToString());

            // 1. Create a bitmap
            using (Bitmap bitmap = new Bitmap(80, 20, PixelFormat.Format24bppRgb))
            {
                // 2. Get access to the raw bitmap data
                BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);

                // 3. Generate RGB noise and write it to the bitmap's buffer.
                // Note that we are assuming that data.Stride == 3 * data.Width for simplicity/brevity here.
                byte[] noise = new byte[data.Width * data.Height * 3];
                new Random().NextBytes(noise);
                Marshal.Copy(noise, 0, data.Scan0, noise.Length);

                bitmap.UnlockBits(data);

                bitmap.Save(sb.ToString(), ImageFormat.Png);

                // 4. Save as JPEG and convert to Base64
                using (MemoryStream jpegStream = new MemoryStream())
                {
                    bitmap.Save(jpegStream, ImageFormat.Jpeg);
                    Console.WriteLine(Convert.ToBase64String(jpegStream.ToArray()));
                }
            }
        }

        public void makePng2()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"TAPSONIC_TOP_");
            sb.Append(DateTime.Now.ToString("yyyyMMddHHmmss"));
            sb.Append(@".png");
            Console.WriteLine(sb.ToString());

            // 1. Create a bitmap
            using (Bitmap bitmap = new Bitmap(80, 20, PixelFormat.Format32bppArgb))
            {

                int x, y;

                for (x = 0; x < bitmap.Width; x++)
                {
                    for (y = 0; y < bitmap.Height; y++)
                    {
                        //Color pixelColor = bitmap.GetPixel(x, y);
                        //Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
                        //bitmap.SetPixel(x, y, newColor);
                        bitmap.SetPixel(x, y, Color.FromArgb(255, 255, 0));
                    }
                }

                bitmap.Save(sb.ToString(), ImageFormat.Png);
            }

        }
    }
}

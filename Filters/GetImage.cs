using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    public class GetImage
    {

        private static Bitmap GetArgbCopy(Image sourceImage)
        {
            Bitmap bmpNew = new Bitmap(sourceImage.Width, sourceImage.Height, PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(bmpNew))
            {
                graphics.DrawImage(sourceImage, new Rectangle(0, 0, bmpNew.Width, bmpNew.Height), new Rectangle(0, 0, bmpNew.Width, bmpNew.Height), GraphicsUnit.Pixel);
                graphics.Flush();
            }            
            return bmpNew;
        }
        public static Bitmap makeGrayScale(Image image)
        {
            Bitmap original = GetArgbCopy(image);
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    Color originalColor = original.GetPixel(i, j);

                    int grayScale = (int)((originalColor.R * .3) + (originalColor.G * .59)
                        + (originalColor.B * .11));

                    Color newColor = Color.FromArgb(grayScale, grayScale, grayScale);

                    newBitmap.SetPixel(i, j, newColor);
                }
            }
            return newBitmap;
        }

        public static Bitmap makeNegative(Image image)
        {
            Bitmap original = GetArgbCopy(image);
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    Color pixel = original.GetPixel(i, j);

                    int r = 255 - pixel.R;
                    int g = 255 - pixel.G;
                    int b = 255 - pixel.B;
                    newBitmap.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            return newBitmap;
        }

        public static Bitmap makeMedian(Image image, int matrixSize = 3)
        {
            Bitmap original = GetArgbCopy(image);
            BitmapData sourceData =
                       original.LockBits(new Rectangle(0, 0,
                       original.Width, original.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride *
                                          sourceData.Height];            

            byte[] resultBuffer = new byte[sourceData.Stride *
                                           sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0,
                                       pixelBuffer.Length);

            original.UnlockBits(sourceData);
            int filterOffset = (matrixSize - 1) / 2;
            int calcOffset = 0;
            int byteOffset = 0;

            List<int> neighbourPixels = new List<int>();
            byte[] middlePixel;

            for (int offsetY = filterOffset; offsetY <
                original.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    original.Width - filterOffset; offsetX++)
                {
                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    neighbourPixels.Clear();

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * sourceData.Stride);

                            neighbourPixels.Add(BitConverter.ToInt32(
                                             pixelBuffer, calcOffset));
                        }
                    }
                    neighbourPixels.Sort();

                    middlePixel = BitConverter.GetBytes(
                                       neighbourPixels[filterOffset]);

                    resultBuffer[byteOffset] = middlePixel[0];
                    resultBuffer[byteOffset + 1] = middlePixel[1];
                    resultBuffer[byteOffset + 2] = middlePixel[2];
                    resultBuffer[byteOffset + 3] = middlePixel[3];
                }
            }
            Bitmap resultBitmap = new Bitmap(original.Width,
                                             original.Height);

            BitmapData resultData =
                       resultBitmap.LockBits(new Rectangle(0, 0,
                       resultBitmap.Width, resultBitmap.Height),
                       ImageLockMode.WriteOnly,
                       PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0,
                                       resultBuffer.Length);
            return resultBitmap;
        }

        public static Bitmap makeSepiaTone(Image image)
        {
            Bitmap original = GetArgbCopy(image);
            BitmapData bmpData = original.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            IntPtr ptr = bmpData.Scan0;

            byte[] byteBuffer = new byte[bmpData.Stride * original.Height];

            Marshal.Copy(ptr, byteBuffer, 0, byteBuffer.Length);

            byte maxValue = 255;

            for (int k = 0; k < byteBuffer.Length; k += 4)
            {
                var r = byteBuffer[k] * 0.189f + byteBuffer[k + 1] * 0.769f + byteBuffer[k + 2] * 0.393f;
                var g = byteBuffer[k] * 0.168f + byteBuffer[k + 1] * 0.686f + byteBuffer[k + 2] * 0.349f;
                var b = byteBuffer[k] * 0.131f + byteBuffer[k + 1] * 0.534f + byteBuffer[k + 2] * 0.272f;

                byteBuffer[k + 2] = (r > maxValue ? maxValue : (byte)r);
                byteBuffer[k + 1] = (g > maxValue ? maxValue : (byte)g);
                byteBuffer[k] = (b > maxValue ? maxValue : (byte)b);
            }
            Marshal.Copy(byteBuffer, 0, ptr, byteBuffer.Length);

            original.UnlockBits(bmpData);

            return original;
        }

        public static Bitmap makeBlur(Image image, Int32 blurSize = 5)
        {               
            Bitmap original = GetArgbCopy(image);
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);
            Rectangle rectangle = new Rectangle(0, 0, image.Width, image.Height);
            // make an exact copy of the bitmap provided
            using (Graphics graphics = Graphics.FromImage(newBitmap))
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                    new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

            // look at every pixel in the blur rectangle
            for (int xx = rectangle.X; xx < rectangle.X + rectangle.Width; xx++)
            {
                for (int yy = rectangle.Y; yy < rectangle.Y + rectangle.Height; yy++)
                {
                    int avgR = 0, avgG = 0, avgB = 0;
                    int blurPixelCount = 0;

                    // average the color of the red, green and blue for each pixel in the
                    // blur size while making sure you don't go outside the image bounds
                    for (int x = xx; (x < xx + blurSize && x < image.Width); x++)
                    {
                        for (int y = yy; (y < yy + blurSize && y < image.Height); y++)
                        {
                            Color pixel = original.GetPixel(x, y);

                            avgR += pixel.R;
                            avgG += pixel.G;
                            avgB += pixel.B;

                            blurPixelCount++;
                        }
                    }

                    avgR = avgR / blurPixelCount;
                    avgG = avgG / blurPixelCount;
                    avgB = avgB / blurPixelCount;

                    // now that we know the average for the blur size, set each pixel to that color
                    for (int x = xx; x < xx + blurSize && x < image.Width && x < rectangle.Width; x++)
                        for (int y = yy; y < yy + blurSize && y < image.Height && y < rectangle.Height; y++)
                            newBitmap.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
                }
            }
            return newBitmap;
        }

        public static Bitmap makeTransparency(Image image, byte alphaComponent = 150)
        {
            Bitmap bmpNew = GetArgbCopy(image);
            BitmapData bmpData = bmpNew.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            IntPtr ptr = bmpData.Scan0;

            byte[] byteBuffer = new byte[bmpData.Stride * bmpNew.Height];

            Marshal.Copy(ptr, byteBuffer, 0, byteBuffer.Length);


            for (int k = 3; k < byteBuffer.Length; k += 4)
            {
                byteBuffer[k] = alphaComponent;
            }

            Marshal.Copy(byteBuffer, 0, ptr, byteBuffer.Length);

            bmpNew.UnlockBits(bmpData);

            return bmpNew;
        }

    }
}
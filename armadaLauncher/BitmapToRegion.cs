using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace armadaLauncher
{
    class BitmapToRegion
    {
       private static bool colorsMatch(Color color1, Color color2, int tolerance)
        {
            if (tolerance < 0) tolerance = 0;
            return Math.Abs(color1.R - color2.R) <= tolerance &&
                   Math.Abs(color1.G - color2.G) <= tolerance &&
                   Math.Abs(color1.B - color2.B) <= tolerance;
        }

        private unsafe static bool colorsMatch(uint* pixelPtr, Color color1, int tolerance)
        {
            if (tolerance < 0) tolerance = 0;
            byte a = (byte)(*pixelPtr >> 24);
            byte r = (byte)(*pixelPtr >> 16);
            byte g = (byte)(*pixelPtr >> 8);
            byte b = (byte)(*pixelPtr >> 0);
            Color pointer = Color.FromArgb(a, r, g, b);
            return Math.Abs(color1.A - pointer.A) <= tolerance &&
                   Math.Abs(color1.R - pointer.R) <= tolerance &&
                   Math.Abs(color1.G - pointer.G) <= tolerance &&
                   Math.Abs(color1.B - pointer.B) <= tolerance;
        }

        public unsafe static Region getRegionFast(Bitmap bitmap, Color transparencyKey, int tolerance)
        {
            GraphicsUnit unit = GraphicsUnit.Pixel;
            RectangleF boundsF = bitmap.GetBounds(ref unit);
            Rectangle bounds = new Rectangle((int)boundsF.Left, (int)boundsF.Top,
                                             (int)boundsF.Width, (int)boundsF.Height);
            int yMax = (int)boundsF.Height;
            int xMax = (int)boundsF.Width;
            if (tolerance <= 0) tolerance = 1;
            BitmapData bitmapData = bitmap.LockBits(bounds, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            uint* pixelPtr = (uint*)bitmapData.Scan0.ToPointer();
            GraphicsPath path = new GraphicsPath();
            for (int y = 0; y < yMax; y++)
            {
                byte* basePos = (byte*)pixelPtr;

                for (int x = 0; x < xMax; x++, pixelPtr++)
                {
                    if (colorsMatch(pixelPtr, transparencyKey, tolerance))
                        continue;
                    int x0 = x;
                    while (x < xMax && !colorsMatch(pixelPtr, transparencyKey, tolerance))
                    {
                        x++;
                        pixelPtr++;
                    }
                    path.AddRectangle(new Rectangle(x0, y, x - x0, 1));
                }
                pixelPtr = (uint*)(basePos + bitmapData.Stride);
            }            
            
            Region outputRegion = new Region(path);
            path.Dispose();
            bitmap.UnlockBits(bitmapData);
            return outputRegion;
        } 
    }
}

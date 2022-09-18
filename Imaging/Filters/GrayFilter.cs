using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Imaging.Filters
{
    public class GrayFilter : IImageFilter
    {
        public Bitmap Apply(Bitmap source)
        {
            var res = new Bitmap(source.Width, source.Height);
            for (int y = 0; y < source.Height; y++)
            {
                Parallel.For(0, source.Width, (x) =>
                {
                    lock (res)
                    {
                        var gray = source.GetPixel(x, y).GetGrayValue();
                        res.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                    }
                });
            }

            return res;
        }
    }
}

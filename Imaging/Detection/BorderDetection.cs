using Imaging.Filters;
using Imaging.Filters.Matrix;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imaging.Detection
{
    public class BorderDetection
    {
        private readonly IImageFilter _Gy;
        private readonly IImageFilter _Gx;

        public BorderDetection()
        {
            _Gy = new MatrixFilter(new double[3, 3]
            {
                { -1, -2, -1 },
                {  0,  0,  0 },
                {  1,  2,  1 },
            }, 1);

            _Gx = new MatrixFilter(new double[3, 3]
            {
                { -1,  0, 1 },
                { -2,  0, 2 },
                { -1,  0, 1 },
            }, 1);
        }

        public Bitmap Apply(Bitmap source)
        {
            var gx = _Gx.Apply(source);
            var gy = _Gy.Apply(source);

            var res = new Bitmap(source.Width, source.Height);
            for (int y = 0; y < source.Height; y++)
            {
                Parallel.For(0, source.Width, (x) =>
                {
                    lock (res)
                    {
                        var r = Math.Pow(gx.GetPixel(x, y).GetGrayValue(), 2) + Math.Pow(gy.GetPixel(x, y).GetGrayValue(), 2);
                        var f = Math.Sqrt(r).GetBright();
                        res.SetPixel(x, y, Color.FromArgb(255, f,f,f));
                    }

                });
            }

            return res;
        }

    }
}

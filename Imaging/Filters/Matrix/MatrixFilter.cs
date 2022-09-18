using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imaging.Filters.Matrix
{
    public class MatrixFilter : IImageFilter
    {
        private readonly double[,] _filter;
        private readonly int _mean;

        public MatrixFilter(double[,] filter, int mean = 1)
        {
            _filter = filter;
            _mean = mean;
        }

        public Bitmap Apply(Bitmap source)
        {
            var res = new Bitmap(source.Width, source.Height);

            var dx = _filter.GetLength(0) / 2;
            var dy = _filter.GetLength(1) / 2;
            for (int y = dy; y < source.Height - dy; y++)
            {
                Parallel.For(dx, source.Width - dx, (x) =>
                {
                    lock (res)
                    {
                        double r = 0;
                        for (int i = 0; i < _filter.GetLength(0); i++)
                        {
                            for (int j = 0; j < _filter.GetLength(1); j++)
                            {
                                r += _filter[i, j] * source.GetPixel(x + i - dx, y + j - dy).GetGrayValue();
                            }
                        }
                        r = r / _mean;
                        int gr = r.GetBright();
                        res.SetPixel(x, y, Color.FromArgb(255, gr, gr, gr));
                    }
                });

                //for (int x = dx; x < source.Width - dx; x++)
                //{
                //    int r = 0;
                //    for(int i = 0; i < _filter.GetLength(0); i++)
                //    {
                //        for(int j=0; j < _filter.GetLength(1); j++)
                //        {
                //            r += _filter[i, j] * source.GetPixel(x+i-dx,y+j-dy).GetGrayValue();
                //        }
                //    }
                //    r = Math.Max(Math.Min(r, 255),0);
                //    res.SetPixel(x, y, Color.FromArgb(255, r, r, r));
                //}
            }


            return res;
        }
    }
}

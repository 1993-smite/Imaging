using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Imaging.Filters
{
    public class BinarizationFilter : IImageFilter
    {
        private int _max;

        public BinarizationFilter(byte max)
        {
            _max = max;
        }

        public Bitmap Apply(Bitmap source)
        {
            var res = new Bitmap(source.Width, source.Height);
            for(int y = 0; y < source.Height; y++)
            {
                Parallel.For(0, source.Width, (x) =>
                {
                    lock (res)
                    {
                        res.SetPixel(x, y, source.GetPixel(x, y).GetGrayValue() < _max ? Color.White : Color.Black);
                    }
                    
                });
            }

            return res;
        }
    }
}

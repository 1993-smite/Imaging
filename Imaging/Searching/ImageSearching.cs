using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Imaging.ColorExtensions;
using static System.Net.Mime.MediaTypeNames;

namespace Imaging.Searching
{
    public class ImageSearching
    {
        public IEnumerable<SearchingInfo> Searchings(Img bitmap, Img bitmap1)
        {
            Img min;
            Img max;
            if (bitmap.Width * bitmap.Height > bitmap1.Width * bitmap1.Height)
            {
                min = bitmap1;
                max = bitmap;
            }
            else
            {
                min = bitmap;
                max = bitmap1;
            }

            var maxH = max.Height;
            var maxW = max.Width;

            var minH = min.Height;
            var minW = min.Width;

            var y1 = max.Height / 100 * 30;
            var y01 = max.Height / 100 * 60;

            var dx = 5;
            var dy = 5;

            var res = new BlockingCollection<SearchingInfo>();

            var dy1 = Math.Max(y1 / 100, 1);
            var dy2 = Math.Max((max.Height - y01) / 100, 1);

            for (int x = 0; x < (maxW - minW); x += dx)
            {
                Parallel.For(0, (maxH - minH) / dy, (int index) =>
                {
                    var korr = GetCorrelation(max, min, x, index * dy);
                    res.Add(korr);
                });
                //for (int y = 0; y < (y1 - min.Height); y += dy1)
                //{
                //    var korr = GetCorrelation(max, min, x, y);
                //    res.Add(korr);
                //}


                //for (int y = y01; y < (max.Height - min.Height); y += dy2)
                //{
                //    var korr = GetCorrelation(max, min, x, y);
                //    res.Add(korr);
                //}
            }
            return res;
        }

        private SearchingInfo GetCorrelation(Bitmap max, Bitmap min, int beginX, int beginY)
        {
            decimal k = 0;
            for (int x = 0; x < min.Width; x += min.Width / 30)
            {
                for (int y = 0; y < min.Height; y += min.Height / 30)
                {
                    double d = max.GetPixel(beginX + x, beginY + y).GetGrayValue() - min.GetPixel(x, y).GetGrayValue();
                    k += (decimal)Math.Pow(d, 2);
                }
            }

            return new SearchingInfo()
            {
                X = beginX,
                Y = beginY,
                D = k
            };
        }

        private SearchingInfo GetCorrelation(
            Img mx, Img mn,
            int beginX, int beginY)
        {
            decimal k = 0;
            for (int x = 0; x < mn.Width; x += mn.Width / 30)
            {
                for (int y = 0; y < mn.Height; y += mn.Height / 30)
                {
                    double d = mx.Values[beginX + x][beginY + y] - mn.Values[x][y];
                        //mx[beginX + x, beginY + y].V - min.GetPixel(x, y).GetGrayValue();
                    k += (decimal)Math.Pow(d, 2);
                }
            }

            return new SearchingInfo()
            {
                X = beginX,
                Y = beginY,
                D = k
            };
        }
    }
}

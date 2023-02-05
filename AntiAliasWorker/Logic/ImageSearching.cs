using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AntiAliasWorker.Logic
{
    internal class ImageSearching
    {
        public static void Conturs(string file, string outFile)
        {
            var inImage = new Image<Bgr, byte>(file);
            var outImage = inImage.Convert<Gray, byte>().ThresholdBinary(new Gray(100), new Gray(255));

            var contours = new VectorOfVectorOfPoint();
            var mt = new Mat();

            CvInvoke.FindContours(outImage, contours, mt, RetrType.Tree, ChainApproxMethod.ChainApproxSimple);

            Rectangle maxRect;
            for (int i = 0; i < contours.Size; i++)
            {
                var p = CvInvoke.ArcLength(contours[i], true);

                //maxRect = CvInvoke.BoundingRectangle(contours[i]);

                //Console.WriteLine($"{p} {maxRect.X} {maxRect.Y} {maxRect.Width}  {maxRect.Height}");

                if (p > 10000 && p < 12000)
                {
                    maxRect = CvInvoke.BoundingRectangle(contours[i]);
                    break;
                }
            }

            for (int i = 0; i < contours.Size; i++)
            {
                if (i % 100 == 0)
                    Console.WriteLine($"\t {i} from {contours.Size}");

                //var test = new Image<Bgr, byte>(file);
                var c = contours[i];

                var p = CvInvoke.ArcLength(c, true);

                //var a = new VectorOfPoint();
                //CvInvoke.ApproxPolyDP(c, a, 0.04 * p, true);

                ////if (a.Size != 4)
                ////{
                ////    AddLog("");
                ////    continue;
                ////}
                if (p > 100)
                    continue;

                var rect = CvInvoke.BoundingRectangle(c);
                //var ratio = rect.Width / rect.Height;
                ////if (ratio >= 0.9 && ratio < 1.1)
                ////{
                ////    AddLog("");
                ////    continue;
                ////}

                //var m = CvInvoke.Moments(c);

                //var ln = JsonConvert.SerializeObject(new { p = p, ms = m, rect });

                //AddLog(ln);

                if (!(rect.Y < 270 || rect.Y > 3310 || rect.X < 270))
                    continue;



                //CvInvoke.DrawContours(test, new VectorOfVectorOfPoint(new VectorOfPoint[] {c}), -1, new MCvScalar(0, 0, 0), 50, LineType.AntiAlias);
                CvInvoke.DrawContours(inImage, new VectorOfVectorOfPoint(new VectorOfPoint[] { c }), -1, new MCvScalar(0, 0, 0), 100, LineType.AntiAlias);

                //test.ToBitmap().Save($"Images/imgs/{i+1}.png");
            }

            //CvInvoke.DrawContours(inImage, contours, -1, new MCvScalar(0, 0, 0), 50, LineType.AntiAlias);

            inImage.ToBitmap().Save(outFile);
        }
    }
}

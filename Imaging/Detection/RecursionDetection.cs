using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imaging.Detection
{
    public enum DetectionType
    {
        cross,
        square
    }

    public class RecursionDetection : IImageDetection
    {
        int idAreas = 0;
        DetectionType type;

        public RecursionDetection(DetectionType detectionType = DetectionType.cross)
        {
            type = detectionType;
        }

        public ICollection<Area> DetectArea(Bitmap bitmap)
        {
            var hh = new int[bitmap.Width,bitmap.Height,1];
            var points = new int[bitmap.Width, bitmap.Height, 1];
            var result = new List<Area>();
            for(int y = 0; y < bitmap.Height; y++)
            {
                for(int x = 0; x < bitmap.Width; x++)
                {
                    Fill(bitmap, result, x, y, points, ++idAreas);
                }
            }

            return result;
        }

        private void Fill(Bitmap img, ICollection<Area> areas, int x, int y, int[,,] points, int idArea)
        {
            var color = img.GetPixel(x, y);
            var p = new Point(x, y, color);
            if (color.ToArgb() == Color.White.ToArgb() && points[x,y,0] == 0)
            {
                var area = areas.SingleOrDefault(x => x.Id == idArea);
                if (area == null)
                {
                    area = new Area(++idArea);
                    areas.Add(area);
                }


                area.AddPoint(new Point(x, y, color));
                points[x, y, 0] = 1;

                if (x>0)
                    Fill(img, areas, x - 1, y, points, idArea);
                if (x<img.Width - 1)
                    Fill(img, areas, x + 1, y, points, idArea);
                if (y > 0)
                    Fill(img, areas, x, y - 1, points, idArea);
                if (x < img.Height - 1)
                    Fill(img, areas, x, y + 1, points, idArea);

                if (type == DetectionType.cross)
                    return;

                if (x > 0 && y > 0)
                    Fill(img, areas, x - 1, y - 1, points, idArea);
                if (x < img.Width - 1 && y < img.Height - 1)
                    Fill(img, areas, x + 1, y + 1, points, idArea);
                if (x > 0 && y < img.Height - 1)
                    Fill(img, areas, x - 1, y + 1, points, idArea);
                if (x < img.Width - 1 && y > 0)
                    Fill(img, areas, x + 1, y - 1, points, idArea);
            }
        }
    }
}

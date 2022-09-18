using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imaging.Detection
{
    interface IImageDetection
    {
        ICollection<Area> DetectArea(Bitmap bitmap);
    }

    public class Area
    {
        public int Id { get; private set; }
        public ICollection<Point> area { get; private set; }
        public void AddPoint(Point p)
        {
            area.Add(p);
        }
        public void RemovePoint(Point p)
        {
            area.Remove(p);
        }

        public Area(int id)
        {
            Id = id;
            area = new List<Point>();
        }
    } 

    public struct Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Color Color { get; private set; }

        public Point(int x, int y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }
}

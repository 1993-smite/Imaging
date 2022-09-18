using System.Drawing;

namespace Imaging
{
    public static class ColorExtensions
    {
        static int point = 0;

        public static int GetGrayValue(this Color val) => (val.R + val.B + val.G) / 3;

        public static int GetBright(this double val) => Math.Max(0, Math.Min((int)val, 255));

        public static Color RandColor(this Color color)
        {
            var clrs = new List<Color>()
            {
                Color.Brown,
                Color.Red,
                Color.Chocolate,
                Color.DarkGray,
                Color.Gold,
                Color.GreenYellow,
                Color.Indigo,
                Color.YellowGreen,
                Color.DarkGray,
                Color.DarkOrange,
                Color.DarkViolet
            };

            return clrs.Count - 1 > point ? clrs[point++] : Color.White;
        }
    }
}

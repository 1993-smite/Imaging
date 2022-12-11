using ImageCore.Logic.Options;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageCore.Logic.Manipulators
{
    public class SystemDrawingManipulator : IImageManipulator
    {
        public Stream DrawImageOnImage(Stream stream, Stream minStream, ImageOptions option)
        {
            var image = new Bitmap(stream);
            Image min = new Bitmap(minStream);

            var start = (Point)option.GetStartPoint;
            using (var gr = Graphics.FromImage(image))
            {
                gr.DrawImage(min, start);
            }

            var mem = new MemoryStream();
            image.Save(mem, ImageFormat.Png);
            mem.Seek(0, SeekOrigin.Begin);

            return mem;
        }

        public Stream DrawTextOnImage(Stream stream, string text, Options.TextImageOptions options)
        {
            var image = new Bitmap(stream);
            var font = (Font)options.GetFont;
            var brush = (Brush)options.GetColor;
            var start = (Point)options.GetStartPoint;

            using (var gr = Graphics.FromImage(image))
            {
                gr.DrawString(text, font, brush, start);
            }

            var mem = new MemoryStream();
            image.Save(mem, ImageFormat.Png);
            mem.Seek(0, SeekOrigin.Begin);
            return mem;
        }
    }
}

using ImageCore.Logic.Options;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Metadata;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;

namespace ImageCore.Logic.Manipulators
{
    public class ImageSharpManipulator : IImageManipulator
    {
        public Stream DrawImageOnImage(Stream stream, Stream minStream, ImageOptions option)
        {
            Image image = Image.Load(stream);
            Image min = Image.Load(minStream);
            var rand = new Random();
            image.Mutate(img =>
            {

                for (double y = 200; y < (image.Height - 200); y += min.Height + 200)
                {
                    for (double x = 100; x < (image.Width - 100); x += min.Width + 100)
                    {
                        img.DrawImage(min, new Point((int)x, (int)y), (float)rand.NextDouble());
                    }
                }
            });

            var mem = new MemoryStream();
            image.SaveAsPng(mem);
            mem.Seek(0, SeekOrigin.Begin);

            return mem;
        }

        public Stream DrawTextOnImage(Stream stream, string text, Options.TextImageOptions options)
        {
            Image image = Image.Load(stream);

            //draw Text
            image.Mutate(img =>
            {
                var font = (Font)options.GetFont;
                var color = (Color)options.GetColor;
                var start = (PointF)options.GetStartPoint;
                //var ff = image.Metadata.HorizontalResolution / ImageMetadata.DefaultHorizontalResolution;
                //var font = SystemFonts.CreateFont("Arial", (float)(24 * Math.Max(ff, 1)), FontStyle.Regular);
                //var size = TextMeasurer.Measure(text, new TextOptions(font));
                //float scalingFactor = image.Height / size.Height / 10;
                //var scalingFont = new Font(font, scalingFactor * font.Size);
                img.DrawText(text, font, color, start);
            });

            var mem = new MemoryStream();
            image.SaveAsPng(mem);
            mem.Seek(0, SeekOrigin.Begin);
            return mem;
        }
    }
}

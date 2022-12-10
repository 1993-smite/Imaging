// See https://aka.ms/new-console-template for more information

Image image = Image.Load("Examples/img.jpg");

var txt = "test";
image.Mutate(img =>
{
    var ff = image.Metadata.HorizontalResolution / ImageMetadata.DefaultHorizontalResolution;
    var font = SystemFonts.CreateFont("Arial", (float)(24 * Math.Max(ff, 1)), FontStyle.Regular);
    var size = TextMeasurer.Measure(txt, new TextOptions(font));
    float scalingFactor = image.Height / size.Height / 10;
    var scalingFont = new Font(font, scalingFactor * font.Size);
    img.DrawText(txt, scalingFont, Color.Black, new PointF(image.Width / 2 - 50, image.Height / 2 - 50) );
});

image.SaveAsJpeg("test.jpg");

Console.WriteLine("Hello, World!");




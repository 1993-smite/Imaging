// See https://aka.ms/new-console-template for more information

var drawText = () =>
{
    Image image = Image.Load("Examples/img.png");

    //draw Text
    var txt = "test";
    image.Mutate(img =>
    {
        var ff = image.Metadata.HorizontalResolution / ImageMetadata.DefaultHorizontalResolution;
        var font = SystemFonts.CreateFont("Arial", (float)(24 * Math.Max(ff, 1)), FontStyle.Regular);
        var size = TextMeasurer.Measure(txt, new TextOptions(font));
        float scalingFactor = image.Height / size.Height / 10;
        var scalingFont = new Font(font, scalingFactor * font.Size);
        img.DrawText(txt, scalingFont, Color.Black, new PointF(image.Width / 2 - 50, image.Height / 2 - 50));
    });

    return image;
};

// draw Image
var drawImage = () =>
{
    Image image = Image.Load("Examples/img.jpg");
    Image min = Image.Load("Examples/vanDamm.jpg");
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
        //img.DrawImage(min, new Point(image.Width / 2 - min.Width / 2, image.Height / 2 - min.Height / 2) ,(float)0.6);
        //img.DrawImage(min, new Point(image.Width / 2 - min.Width / 2, image.Height / 2 - min.Height / 2), (float)0.6);
    });

    return image;
};


var image = drawImage();
image.SaveAsJpeg("test.jpg");



Console.WriteLine("Hello, World!");




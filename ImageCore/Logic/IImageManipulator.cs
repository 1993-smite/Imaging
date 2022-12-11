using ImageCore.Logic.Options;

namespace ImageCore.Logic
{
    public interface IImageManipulator
    {
        Stream DrawTextOnImage(Stream stream, string text, TextImageOptions options);
        Stream DrawImageOnImage(Stream stream, Stream min, ImageOptions options);
    }
}
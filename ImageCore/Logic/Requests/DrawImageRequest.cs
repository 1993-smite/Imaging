using MediatR;

namespace ImageCore.Logic.Requests
{
    public class DrawImageRequest: IRequest<Stream>
    {
        public ImageOptions Options { get; set; }
        public Stream Image { get; set; }
        public Stream MinImage { get; set; }
        public IImageManipulator Manipulator { get; set; }
    }
}

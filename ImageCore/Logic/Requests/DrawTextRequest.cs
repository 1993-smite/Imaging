using MediatR;

namespace ImageCore.Logic.Requests
{
    public class DrawTextRequest: IRequest<Stream>
    {
        public TextImageOptions Options { get; set; }
        public string Text { get; set; }
        public Stream Image { get; set; }
        public IImageManipulator Manipulator { get; set; }
    }
}

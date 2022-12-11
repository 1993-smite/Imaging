using ImageCore.Logic.Requests;
using MediatR;

namespace WebImages.Handlers
{
    public class DrawTextHandle : IRequestHandler<DrawTextRequest, Stream>
    {
        public Task<Stream> Handle(DrawTextRequest request, CancellationToken cancellationToken)
        {
            var result = request.Manipulator.DrawTextOnImage(request.Image, request.Text, request.Options);
            return Task.FromResult(result);
        }
    }
}

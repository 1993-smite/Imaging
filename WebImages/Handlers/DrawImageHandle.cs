using ImageCore.Logic.Requests;
using MediatR;

namespace WebImages.Handlers
{
    public class DrawImageHandle : IRequestHandler<DrawImageRequest, Stream>
    {
        public Task<Stream> Handle(DrawImageRequest request, CancellationToken cancellationToken)
        {
            var result = request.Manipulator.DrawImageOnImage(request.Image, request.MinImage, request.Options);
            return Task.FromResult(result);
        }
    }
}

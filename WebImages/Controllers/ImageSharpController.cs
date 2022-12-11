using ImageCore.Logic;
using ImageCore.Logic.Manipulators;
using ImageCore.Logic.Options;
using ImageCore.Logic.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace WebImages.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageSharpController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IImageManipulator _manipulator = new ImageSharpManipulator();

        public ImageSharpController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            using var img = new FileStream(Consts.ImageDefault, FileMode.Open);
            return File(img, "APPLICATION/octet-stream", "example.png");
        }

        [HttpGet("text/{text}")]
        public async Task<IActionResult> GetAsync(string text)
        {
            using var img = new FileStream(Consts.ImageDefault, FileMode.Open);
            var options = new TextImageOptions();
            options.SetFont(SystemFonts.CreateFont(Consts.Font, Consts.FontSize, FontStyle.Regular));
            options.SetColor(Color.Black);
            options.SetStartPoint(new PointF(500, 500));
            var result = await _mediator.Send(new DrawTextRequest()
            {
                Image = img,
                Text = text,
                Options = options,
                Manipulator = _manipulator
            });
            return File(result, "APPLICATION/octet-stream", "text.png");
        }

        [HttpGet("image")]
        public async Task<IActionResult> GetAsync()
        {
            using var img = new FileStream(Consts.ImageDefault, FileMode.Open);
            using var min = new FileStream(Consts.MinImageDefault, FileMode.Open);
            var options = new ImageOptions();
            options.SetStartPoint(new PointF(500, 500));
            var result = await _mediator.Send(new DrawImageRequest()
            {
                Image = img,
                MinImage = min,
                Options = options,
                Manipulator = _manipulator
            });
            return File(result, "APPLICATION/octet-stream", "test.png");
        }
    }
}
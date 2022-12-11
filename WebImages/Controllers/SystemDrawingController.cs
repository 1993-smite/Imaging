using ImageCore.Logic.Manipulators;
using ImageCore.Logic;
using ImageCore.Logic.Options;
using ImageCore.Logic.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace WebImages.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemDrawingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IImageManipulator _manipulator = new SystemDrawingManipulator();

        public SystemDrawingController(IMediator mediator)
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
            options.SetFont(new Font(Consts.Font, Consts.FontSize));
            options.SetColor(Brushes.Black);
            options.SetStartPoint(new Point(500, 500));
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
            options.SetStartPoint(new Point(500, 500));
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
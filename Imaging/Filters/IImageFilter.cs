using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Imaging.Filters
{
    internal interface IImageFilter
    {
        Bitmap Apply(Bitmap source);
    }
}

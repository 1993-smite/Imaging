using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ConsoleApp1
{
    internal interface IImageFilter
    {
        Bitmap Apply(Bitmap source);
    }
}

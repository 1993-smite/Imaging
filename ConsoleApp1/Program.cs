using AForge.Imaging.Filters;
using System;
using System.Drawing.Imaging;
using System.Drawing;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = @"E:/Images";


            var source = new Bitmap($"{path}/tst.png");

            var ggg = new BinaryDilatation3x3();
            var res = ggg.Apply(source);
            res.Save($"{path}/res.png");

            Console.WriteLine("Hello World!");
        }
    }
}

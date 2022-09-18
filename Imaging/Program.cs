// See https://aka.ms/new-console-template for more information


using Imaging;
using Imaging.Detection;
using Imaging.Filters;
using Imaging.Filters.Matrix;
using System.Drawing;




Console.WriteLine("Hello, World!");

var path = @"E:/Images";


var source = new Bitmap($"{path}/_captcha.png");

var bin = new BinarizationFilter(50);
var gray = new GrayFilter();
var cl = new ClarityFilter();
var gf = new GauseFilter();
var er = new ErosianFilter();
var pf = new PrewittFilter();
var sf = new SobelFilter();
var bd = new BorderDetection();

//var res = bin.Apply(source);

//var gr = gray.Apply(source);

//gr.Save($"{path}/resGray.png");

//var res = bin.Apply(source);
//var res = cl.Apply(source);

//cl.Apply(res).Save($"{path}/resClarity.png");

//var rr = gf.Apply(source);

//gf.Apply(rr).Save($"{path}/resGause.png");

//var rr1 = er.Apply(source);

//rr1.Save($"{path}/resErosian.png");

pf.Apply(source).Save($"{path}/resPrewitt1.png");
//sf.Apply(source).Save($"{path}/resSobel.png");

//bd.Apply(source).Save($"{path}/resBorder.png");

//var det = new RecursionDetection(DetectionType.cross);

//var arr = det.DetectArea(res).Where(x=>x.area.Count > 30).ToList();

//for (int i=0;i<arr.Count;i++)
//{
//    var color = Color.White.RandColor();
//    foreach (var p in arr[i].area)
//    {
//        res.SetPixel(p.X, p.Y, color);
//    }
//}

//res.Save($"{path}/res.png");



Console.WriteLine("The End!");
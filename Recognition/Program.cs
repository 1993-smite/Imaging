// See https://aka.ms/new-console-template for more information
using Aspose.OCR;
using IronOcr;
using Tesseract;


//var ocrengine = new TesseractEngine(@".\tessdata", "rus+eng", EngineMode.Default);
//var img = Pix.LoadFromFile("Examples/rec.png");
//var res = ocrengine.Process(img);

//var Ocr = new IronTesseract();
//// Hundreds of languages available 
//Ocr.Language = OcrLanguage.English;
//using (var Input = new OcrInput())
//{
//    Input.AddImage(@"Examples/rec.png");
//    // Input.DeNoise();  optional  
//    // Input.Deskew();   optional  
//    IronOcr.OcrResult Result = Ocr.Read(Input);
//    Console.WriteLine(Result.Text);
//    // Explore the OcrResult using IntelliSense
//}

AsposeOcr api = new AsposeOcr();

// recognize image
try
{
    string result = api.RecognizeImage("Examples/rec.png");

    // display the recognized text
    Console.WriteLine(result);
}
catch(Exception err)
{
    Console.WriteLine(err.Message);
}

Console.ReadLine();
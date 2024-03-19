using QRCoder;
using System.Drawing;
namespace QRCodeGeneratorProgram
{
    internal class Program
    {
        const string YOUR_URL = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";

        static void Main(string[] args)
        {
            GenerateQRCode(YOUR_URL, "shuckydarns");
            Console.WriteLine("Generated QR code :)");
        }

        static void GenerateQRCode(string link, string fileName)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData myQrCodeData = qrGenerator.CreateQrCode(link, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode code = new BitmapByteQRCode(myQrCodeData);
            byte[] qrCodeBits = code.GetGraphic(20);
            Bitmap bmp;
            using (MemoryStream ms = new MemoryStream(qrCodeBits))
            {
                bmp = new Bitmap(ms);
                bmp.Save($"{fileName}.png");
            }
        }
    }
}
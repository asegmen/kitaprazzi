using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace Kitaprazzi.Core.Helper
{
    public class ImageHelper
    {
        public static byte[] ImageToByteArray(Stream streamImage)
        {
            Stream stream = streamImage;
            BinaryReader binaryReader = new BinaryReader(stream);
            return binaryReader.ReadBytes((int)stream.Length);
        }

        public static string byteArrayToImage(byte[] byteArrayIn)
        {
            string base64 = Convert.ToBase64String(byteArrayIn);
            return "data:Image/png;base64," + base64;
        }
        public Image byteArrayToImage2(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}

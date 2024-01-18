using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using static QRCoder.PayloadGenerator;

namespace EasyWiFiConnect
{
    internal class QRGenerator
    {
        public static BitmapImage GenerateWiFiQRCode(string wifiName, string wifiPass)
        {
            WiFi generator = new WiFi(wifiName, wifiPass, WiFi.Authentication.WPA);
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(20);

            BitmapImage qrCodeAsBitmapImage = ImageConverter.ConvertToBitmapImage(qrCodeAsBitmap);

            return qrCodeAsBitmapImage;
        }
    }
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EasyWiFiConnect
{
    /// <summary>
    /// Interaction logic for QRImage.xaml
    /// </summary>
    public partial class QRImage : Window
    {
        public QRImage(BitmapImage qrCodeBitmap)
        {
            InitializeComponent();

            imageQRCode.Source = qrCodeBitmap;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image (*.png)|*.png";
            saveFileDialog.FileName = "QRCodeImage";

            if (saveFileDialog.ShowDialog() == true)
            {
                // Получаем BitmapImage из Image на форме
                BitmapSource bitmapSource = (BitmapSource)imageQRCode.Source;

                // Конвертируем в Bitmap и сохраняем
                SaveBitmapSourceToPng(saveFileDialog.FileName, bitmapSource);
            }
        }

        private void SaveBitmapSourceToPng(string fileName, BitmapSource bitmapSource)
        {
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                encoder.Save(stream);
            }

            MessageBox.Show("QR code successfully saved!");
        }
    }
}

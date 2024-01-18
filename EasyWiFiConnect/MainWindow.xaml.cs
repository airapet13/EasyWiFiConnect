using QRCoder;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyWiFiConnect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void GenerateQRCodeButton_Click(object sender, RoutedEventArgs e)
        {
            string wifiName = WifiNameTextBox.Text;
            string wifiPass = WifiPassTextBox.Text;

            if(!string.IsNullOrEmpty(wifiName) && !string.IsNullOrEmpty(wifiPass) ) 
            {
                BitmapImage qrCodeBitmap = QRGenerator.GenerateWiFiQRCode(wifiName, wifiPass);

                QRImage qrImageWindow = new QRImage(qrCodeBitmap);
                qrImageWindow.Show();
            }
            else
            {
                MessageBox.Show("Please enter the WiFi network name and password.");
            }
        }
    }
}

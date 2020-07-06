using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartShop.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRCodeMaker : ContentPage
    {
        public QRCodeMaker()
        {
            InitializeComponent();
            BarcodeImage.IsVisible = false;
        }

        private void txtInputvalue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInputvalue.Text))
            {
                BarcodeImage.BarcodeValue = txtInputvalue.Text;
                qrImage.BarcodeValue = txtInputvalue.Text;
            }
            else
            {
                BarcodeImage.BarcodeValue = " ";
                qrImage.BarcodeValue = " ";
            }
        }

        private void QRrad_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

            qrImage.IsVisible = QRrad.IsChecked;
            BarcodeImage.IsVisible = barCodeRad.IsChecked;
        }
    }
}
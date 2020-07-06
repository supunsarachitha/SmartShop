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
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            
            return base.OnBackButtonPressed();
        }

        private async void CreateQRCode_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new QRCodeMaker());
        }
    }


}
using SmartShop.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartShop
{
    public partial class App : Application
    {
        public App()
        {

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjYzMzAxQDMxMzgyZTMxMmUzMFh5VVhHdUg0MmhPUXpSK05zWkppSEZwTTlsL3FxM3lteFhYRlFIYjZSS1U9");
            InitializeComponent();

            MainPage = new AddNewItems();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

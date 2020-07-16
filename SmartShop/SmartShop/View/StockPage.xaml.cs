using Rg.Plugins.Popup.Extensions;
using SmartShop.Model;
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
    public partial class StockPage : ContentPage
    {
        public StockPage()
        {
            InitializeComponent();
            try
            {
                _ = GetStockAsync();

                MessagingCenter.Subscribe<AddStockPopup>(this, "StockUpdated", (sender) =>
                {
                    _ = GetStockAsync();
                });
            }
            catch (Exception ex)
            {

                return;
            }
        }

        private async Task GetStockAsync()
        {
            try
            {
                var ListItems = await App.Database.GetStockItemsAsync();
                StockList.ItemsSource = ListItems;
            }
            catch (Exception ex)
            {

                return;
            }
        }

        private async void StockList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selectedItem = (ItemStock)StockList.SelectedItem;
                var popupPage = new AddStockPopup(((ItemStock)StockList.SelectedItem).ItemId, ((ItemStock)StockList.SelectedItem).ItemName);

                await Navigation.PushPopupAsync(popupPage, true);
            }
            catch (Exception ex)
            {

                return;
            }
        }
    }
}
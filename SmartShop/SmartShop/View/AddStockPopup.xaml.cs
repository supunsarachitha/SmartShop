using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
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
    public partial class AddStockPopup : PopupPage
    {
        private int itemId;
        private string itemName;

        public AddStockPopup(int itemId, string itemName)
        {
            InitializeComponent();
            try
            {
                this.itemId = itemId;
                this.itemName = itemName;
                txtName.Text = itemName;

                GetStock();
            }
            catch (Exception ex)
            {

                return;
            }

        }

        private async void GetStock()
        {
            try
            {
                var a = await App.Database.GetStockById(itemId);
                txtBalance.Text = !string.IsNullOrEmpty(a.ToString()) ? a.Qty.ToString() : "0";
            }
            catch (Exception ex)
            {

                return;
            }
           
           
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            try
            {
                StockBalance list = new StockBalance()
                {
                    Qty = !string.IsNullOrEmpty(txtBalance.Text)? Convert.ToInt32(txtBalance.Text.Trim()): 0,
                    ItemId = itemId
                };

                var a = await App.Database.GetStockById(itemId);

                if (a == null)
                {
                    await App.Database.insertStock(list);
                }
                else
                {
                    await App.Database.UpdateItemStock(list);

                }

                MessagingCenter.Send(this, "StockUpdated");

                await Navigation.PopPopupAsync();
            }
            catch (Exception ex)
            {

                return;
            }
        }
    }
}
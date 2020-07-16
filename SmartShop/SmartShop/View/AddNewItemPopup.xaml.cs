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
    public partial class AddNewItemPopup : PopupPage
    {
        public AddNewItemPopup()
        {
            InitializeComponent();
            txtDescription.Text = "";
            txtName.Text = "";
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            try
            {
                    ItemList list = new ItemList()
                    {
                        ItemDescription = txtDescription.Text,
                        ItemName = txtName.Text
                    };

                    await App.Database.SaveItemAsync(list);

                    InvoceCallback();
                    await Navigation.PopPopupAsync();
            }
            catch (Exception)
            {

                return;
            }
        }


        public event EventHandler<object> CallbackEvent;

        private void InvoceCallback()
        {

            CallbackEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
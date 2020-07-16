using Rg.Plugins.Popup.Extensions;
using SmartShop.Model;
using SmartShop.ViewModel;
using Syncfusion.DataSource;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace SmartShop.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewItems : ContentPage
    {

        AddNewItemsViewModel VM = new AddNewItemsViewModel();

        ObservableCollection<ItemList> itemDetailCollection = new ObservableCollection<ItemList>();

        public AddNewItems()
        {
            InitializeComponent();
            //BindingContext = VM;


            bindData(false);

        }

        private async void OnCallback(object sender, object e)
        {
            bindData(true);
        }

        private async void bindData(bool Isrefresh)
        {
           
            
            //NewItemsList.ItemsSource = itemDetailCollection;
           
            var ListItems = await App.Database.GetItemsAsync();
            NewItemsList.ItemsSource = ListItems;
            foreach (var item in ListItems)
            {

                ItemList list = new ItemList()
                {
                    ItemDescription = item.ItemDescription,
                    ItemName = item.ItemName,
                    ItemId = item.ItemId
                };

                itemDetailCollection.Add(list);
            }

            if (!Isrefresh)
            {
                NewItemsList.DataSource.GroupDescriptors.Add(new GroupDescriptor()
                {
                    PropertyName = "ItemName",
                    KeySelector = (object obj1) =>
                    {
                        var item = (obj1 as ItemList);
                        return item.ItemName[0].ToString();
                    }
                    //Comparer = new CustomGroupComparer()
                });
            }
            
        }

        private void Info_Tapped(object sender, EventArgs e)
        {
            ItemList l = (ItemList)((Grid)sender).BindingContext;
            DisplayAlert(l.ItemName, l.ItemDescription, "close");
        }


        private void SearchEntry_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {

                if (SearchEntry.Text != null || SearchEntry.Text.Trim() != "")
                {
                    if (SearchEntry.Text.Trim().Length > 0)
                    {
                        var searchedResult = itemDetailCollection.Where(x => x.ItemName.ToLower().Contains(SearchEntry.Text.ToLower())).ToList();
                        NewItemsList.ItemsSource = searchedResult;
                    }

                }
                else
                {
                    NewItemsList.ItemsSource = itemDetailCollection;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {

            var popupPage = new AddNewItemPopup();
            popupPage.CallbackEvent += OnCallback;
            await Navigation.PushPopupAsync(popupPage, true);
        }

        private async void delete_Tapped(object sender, EventArgs e)
        {
            try
            {

                ItemList l = (ItemList)((Grid)sender).BindingContext;
                await App.Database.DeleteItemAsync(l);
                NewItemsList.ItemsSource = await App.Database.GetItemsAsync();
            }
            catch (Exception)
            {

                return;
            }
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }


    }
}
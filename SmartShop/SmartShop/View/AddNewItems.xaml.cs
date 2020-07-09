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

        ObservableCollection<ItemDetail> itemDetailCollection = new ObservableCollection<ItemDetail>();

        public AddNewItems()
        {
            InitializeComponent();
            //BindingContext = VM;


            
            itemDetailCollection.Add(new ItemDetail(1,"Apple","des",100));
            itemDetailCollection.Add(new ItemDetail(1, "Banana", "des", 100));
            itemDetailCollection.Add(new ItemDetail(1, "Coco", "des", 100));
            itemDetailCollection.Add(new ItemDetail(1, "Doorian", "des", 100));
            itemDetailCollection.Add(new ItemDetail(1, "Egg", "des", 100));
            itemDetailCollection.Add(new ItemDetail(1, "Fruits", "des", 100));


            NewItemsList.ItemsSource = itemDetailCollection;



            NewItemsList.DataSource.GroupDescriptors.Add(new GroupDescriptor()
            {
                PropertyName = "ItemName",
                KeySelector = (object obj1) =>
                {
                    var item = (obj1 as ItemDetail);
                    return item.ItemName[0].ToString();
                }
                //Comparer = new CustomGroupComparer()
            });

        }

        private void ContactInfo_Tapped(object sender, EventArgs e)
        {

        }

        private void ViewProfile_Tapped(object sender, EventArgs e)
        {

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

        private void btnAdd_Clicked(object sender, EventArgs e)
        {

        }
    }
}
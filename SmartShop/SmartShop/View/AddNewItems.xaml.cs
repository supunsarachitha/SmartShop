using SmartShop.Model;
using SmartShop.ViewModel;
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

        public AddNewItems()
        {
            InitializeComponent();
            BindingContext = VM;


            ObservableCollection<ItemDetail> itemDetailCollection = new ObservableCollection<ItemDetail>();
            itemDetailCollection.Add(new ItemDetail(1,"A","des",100));
            itemDetailCollection.Add(new ItemDetail(1, "B", "des", 100));
            itemDetailCollection.Add(new ItemDetail(1, "C", "des", 100));
            itemDetailCollection.Add(new ItemDetail(1, "D", "des", 100));
            itemDetailCollection.Add(new ItemDetail(1, "E", "des", 100));
            itemDetailCollection.Add(new ItemDetail(1, "F", "des", 100));


            NewItemsList.ItemsSource = itemDetailCollection;

        }


    }
}
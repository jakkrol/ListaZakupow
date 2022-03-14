using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ListaZakupow.Models;

namespace ListaZakupow
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProducts_Page : ContentPage
    {
        ListObject list;
        
        public AddProducts_Page(ListObject list)
        {
            InitializeComponent();
            AllList.ItemsSource = Models.AllProductsList.AllProductList;

            this.list = list;
        }

     
        private void AddNewProduct_Clicked(object sender, EventArgs e)
        {
            
            foreach (Models.Products obj in list.ProductList)
            {
                if (obj.nazwa == Add_my_product.Text)
                {
                    //napraw --> ilosc sie nie zmienia
                    obj.ilosc++;
                    return;
                }

            }

            list.ProductList.Add(new Products { nazwa = Add_my_product.Text, ilosc = 1 });
            
       
            //Navigation.PushAsync(new ProductsList_Page(list));
        }

        private void AllList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var dataItem = e.Item as Products;
            

            foreach (Models.Products obj in list.ProductList)
            {
                if (obj.nazwa == dataItem.nazwa)
                {
                    //napraw --> ilosc sie nie zmienia
                    obj.ilosc++;
                    return;
                }
                
            }
            list.ProductList.Add(new Products { nazwa = dataItem.nazwa, ilosc = 1 });
        }
    }
}
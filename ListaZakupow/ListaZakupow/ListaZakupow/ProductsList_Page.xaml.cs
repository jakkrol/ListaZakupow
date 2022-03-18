using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ListaZakupow.Models;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ListaZakupow
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsList_Page : ContentPage
    {
        ListObject list;

        public ProductsList_Page(ListObject list)
        {
            InitializeComponent();
            this.list = list;
            ProductList.ItemsSource = list.ProductList;
            Title = list.listName;


        }
        protected override void OnAppearing()
        {

            ProductList.ItemsSource = null;
            ProductList.ItemsSource = list.ProductList;
            list.CheckedItems = 0;
            base.OnAppearing();
        }


        private async void AddProduct_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new AddProducts_Page(list));
            string result = await DisplayPromptAsync("Dodaj produkt", "Dodaj", maxLength: 10);
            
            if ((result == null) || (result == ""))
            {
                return;
            }
            else
            {
                string result2 = await DisplayPromptAsync("Ile?", "Ile?", initialValue: "1", maxLength: 2, keyboard: Keyboard.Numeric);
                list.ProductList.Add(new Products { nazwa = result, ilosc = Convert.ToInt16(result2) });


                string jsonValueToSave = JsonConvert.SerializeObject(MainPage.mainList);
                Application.Current.Properties.Remove("myList");
                Application.Current.Properties.Add("myList", jsonValueToSave);
                await Application.Current.SavePropertiesAsync();
                Console.WriteLine("test");
                Console.WriteLine(Application.Current.Properties["myList"]);


                
            }
        }

        private void ProductList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            /*var dataItem = e.Item as Products;


            foreach (Models.Products obj in list.ProductList)
            {
                if (obj.nazwa == dataItem.nazwa)
                {
                    if (obj.isChecked == false)
                    {
                        list.CheckedItems++;
                        obj.isChecked = true;
                        ProductList.SelectedItem = null;
                        ProductList.ItemsSource = null;
                        ProductList.ItemsSource = list.ProductList;
                    }
                    else
                    {
                        list.CheckedItems--;
                        obj.isChecked = false;
                        ProductList.SelectedItem = null;
                        ProductList.ItemsSource = null;
                        ProductList.ItemsSource = list.ProductList;
                    }
                }

            }*/
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            ProductList.SelectedItem = null;
            /*var viewcell = (ViewCell)sender;
            
            
            if (viewcell.View.BackgroundColor != Color.Green)
            {
                viewcell.View.BackgroundColor = Color.Green;
                ProductList.SelectedItem = null;
                
            }
            else
            {
                viewcell.View.BackgroundColor = Color.FromHex("#2a2a2a");
                ProductList.SelectedItem = null;
            }*/
        }

        private void box_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

            var senderBindingContext = (CheckBox)sender;
            var dataItem = senderBindingContext.BindingContext as Products;

            //Console.WriteLine(dataItem.nazwa);

            
            foreach (Models.Products obj in list.ProductList)
            {
                if (obj.nazwa == dataItem.nazwa)
                {
                    if (obj.isChecked == true)
                    {
                        Console.WriteLine("true");
                        list.CheckedItems++;
                        obj.isChecked = true;
                        return;
                        //ProductList.SelectedItem = null;
                        //ProductList.ItemsSource = null;
                        //ProductList.ItemsSource = list.ProductList;
                    }
                    else
                    {
                        Console.WriteLine("false");
                        list.CheckedItems--;
                        obj.isChecked = false;
                        return;
                        //ProductList.SelectedItem = null;
                        //ProductList.ItemsSource = null;
                        //ProductList.ItemsSource = list.ProductList;
                    }
                }

           }

        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ListaZakupow.Models;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.IO;
using Xamarin.Essentials;
using System.Xml.Serialization;

namespace ListaZakupow
{
    public partial class MainPage : ContentPage
    {
        
        public static ObservableCollection<ListObject> mainList = new ObservableCollection<ListObject>();

        public MainPage()
        {
            InitializeComponent();
            if (Application.Current.Properties.ContainsKey("myList"))
            {
                Console.WriteLine(Application.Current.Properties["myList"]);
                string jsonValue = Application.Current.Properties["myList"] as string;
/*                Console.WriteLine("test");
                Console.WriteLine(jsonValue);*/
                mainList = JsonConvert.DeserializeObject<ObservableCollection<ListObject>>(jsonValue);
                

                
            }
            
            List.ItemsSource = mainList;
   


            //test
            /*    foreach (ListObject obj in mainList)
                {
                    if (obj.listName == "someValue")
                    {
                        obj.ProductList.Add( new Products() { nazwa = "someValue", ilosc = 1 } );
                        break;
                    }
                }*/
        }

        protected override void OnAppearing()
        {
            string jsonValueToSave = JsonConvert.SerializeObject(mainList);
            Application.Current.Properties.Remove("myList");
            Application.Current.Properties.Add("myList", jsonValueToSave);
            Application.Current.SavePropertiesAsync();

            List.ItemsSource = null;
            List.ItemsSource = mainList;
            base.OnAppearing();
            
        }

        private void AddList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewList_Page());

            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var senderBindingContext = ((Button)sender).BindingContext;
            var dataItem = (ListObject)senderBindingContext;
            
            //list.ProductList.Add(new Products { nazwa = dataItem.nazwa, ilosc = 1 });

            mainList.Remove(dataItem);
        

            
        }

        private void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            var dataItem = e.Item as ListObject;

            Navigation.PushAsync(new ProductsList_Page(dataItem));
        }


    }
}

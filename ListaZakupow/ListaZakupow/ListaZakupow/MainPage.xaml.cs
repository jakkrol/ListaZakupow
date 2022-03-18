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
        
        public static ObservableCollection<ListObject> mainList { get; set; } = new ObservableCollection<ListObject>();

        public MainPage()
        {
            InitializeComponent();
            if (Application.Current.Properties.ContainsKey("myList"))
            {
                string jsonValue = Application.Current.Properties["myList"] as string;
                //Console.WriteLine("test");
                //Console.WriteLine(jsonValue);
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
            Console.WriteLine("test");
            Console.WriteLine(Application.Current.Properties["myList"]);


            List.ItemsSource = null;
            List.ItemsSource = mainList;
            base.OnAppearing();
            
        }

        private void AddList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewList_Page());

            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
                    var senderBindingContext = ((Button)sender).BindingContext;
                    var dataItem = (ListObject)senderBindingContext;

               /*     //list.ProductList.Add(new Products { nazwa = dataItem.nazwa, ilosc = 1 });
                    TrashcanPage.trashList.Add(dataItem);

                    string jsonToSave = JsonConvert.SerializeObject(TrashcanPage.trashList);
                    Application.Current.Properties.Remove("myTrashList");
                    Application.Current.Properties.Add("myTrashList", jsonToSave);
                    Application.Current.SavePropertiesAsync();
                    Console.WriteLine("test2");
                    Console.WriteLine(Application.Current.Properties["myTrashList"]);


                    mainList.Remove(dataItem);

                    string jsonValueToSave = JsonConvert.SerializeObject(mainList);
                    Application.Current.Properties.Remove("myList");
                    Application.Current.Properties.Add("myList", jsonValueToSave);
                    Application.Current.SavePropertiesAsync();*/


            string res = await DisplayActionSheet("Co chcesz zrobić?", "Anuluj", null, "Modyfikuj", "Usuń");
            if (res == "Usuń")
            {
                TrashcanPage.trashList.Add(dataItem);

                string jsonToSave = JsonConvert.SerializeObject(TrashcanPage.trashList);
                Application.Current.Properties.Remove("myTrashList");
                Application.Current.Properties.Add("myTrashList", jsonToSave);
                await Application.Current.SavePropertiesAsync();
                Console.WriteLine("test2");
                Console.WriteLine(Application.Current.Properties["myTrashList"]);


                mainList.Remove(dataItem);

            }
            if (res == "Modyfikuj")
            {
                foreach (Models.ListObject obj in mainList)
                {
                    if (obj.listName == dataItem.listName)
                    {
                        string result = await DisplayPromptAsync("Modyfikuj nazwę", "Modyfikuj", maxLength: 20);

                        if ((result == null) || (result == ""))
                        {
                            return;
                        }
                        else
                        {
                           

                            obj.listName = result;
                            

                            List.ItemsSource = null;
                            List.ItemsSource = mainList;
                        }
                    }
                }
            }

            string jsonValueToSave = JsonConvert.SerializeObject(mainList);
            Application.Current.Properties.Remove("myList");
            Application.Current.Properties.Add("myList", jsonValueToSave);
            await Application.Current.SavePropertiesAsync();

        }

        private void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            var dataItem = e.Item as ListObject;

            Navigation.PushAsync(new ProductsList_Page(dataItem));
        }


    }
}

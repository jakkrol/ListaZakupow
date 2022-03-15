using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using ListaZakupow.Models;
using System.IO;
using Xamarin.Essentials;
using System.Xml.Serialization;

namespace ListaZakupow
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrashcanPage : ContentPage
    {
        public static ObservableCollection<ListObject> trashList { get; set; } = new ObservableCollection<ListObject>();
        public TrashcanPage()
        {
            InitializeComponent();
            if (Application.Current.Properties.ContainsKey("myTrashList"))
            {
                string jsonValue = Application.Current.Properties["myTrashList"] as string;
                Console.WriteLine("test3");
                Console.WriteLine(jsonValue);
                trashList = JsonConvert.DeserializeObject<ObservableCollection<ListObject>>(jsonValue);



            }

            TrashList.ItemsSource = trashList;
        }

        protected override void OnAppearing()
        {
            string jsonValueToSave = JsonConvert.SerializeObject(trashList);
            Application.Current.Properties.Remove("myTrashList");
            Application.Current.Properties.Add("myTrashList", jsonValueToSave);
            Application.Current.SavePropertiesAsync();
            Console.WriteLine("test2");
            Console.WriteLine(Application.Current.Properties["myTrashList"]);

            TrashList.ItemsSource = null;
            TrashList.ItemsSource = trashList;
            base.OnAppearing();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var senderBindingContext = ((Button)sender).BindingContext;
            var dataItem = (ListObject)senderBindingContext;

            trashList.Remove(dataItem);

            string jsonValueToSave = JsonConvert.SerializeObject(trashList);
            Application.Current.Properties.Remove("myTrashList");
            Application.Current.Properties.Add("myTrashList", jsonValueToSave);
            Application.Current.SavePropertiesAsync();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var senderBindingContext = ((Button)sender).BindingContext;
            var dataItem = (ListObject)senderBindingContext;

            MainPage.mainList.Add(dataItem);

            string jsonToSave = JsonConvert.SerializeObject(MainPage.mainList);
            Application.Current.Properties.Remove("myList");
            Application.Current.Properties.Add("myList", jsonToSave);
            Application.Current.SavePropertiesAsync();
            Console.WriteLine("test2");
            Console.WriteLine(Application.Current.Properties["myList"]);

            trashList.Remove(dataItem);

            string jsonValueToSave = JsonConvert.SerializeObject(trashList);
            Application.Current.Properties.Remove("myTrashList");
            Application.Current.Properties.Add("myTrashList", jsonValueToSave);
            Application.Current.SavePropertiesAsync();
        }
    }
}
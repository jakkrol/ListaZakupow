using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ListaZakupow.Models;
using System.Collections.ObjectModel;

namespace ListaZakupow
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewList_Page : ContentPage
    {
        public NewList_Page()
        {
            InitializeComponent();
            
        }
        
        private void AddNewList_Clicked(object sender, EventArgs e)
        {

            MainPage.mainList.Add(new ListObject { ProductList = new ObservableCollection<Products> { }, listName = List_name.Text, CheckedItems = 0 }) ;

            Navigation.PopAsync();

               /*     Models.ListObject pList;

                   foreach (Models.ListObject obj in MainListClass.mainList)
                   {
                       if (obj.listName == List_name.Text)
                       {
                          pList = obj;
                           ProductsList_Page pp = new ProductsList_Page(pList);
                            Navigation.PushAsync(new MainPage());
                            Console.WriteLine("huj");
                       }
                   }*/
                   

            

        }
    }
}
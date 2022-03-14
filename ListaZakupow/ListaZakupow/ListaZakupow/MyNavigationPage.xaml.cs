using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaZakupow
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyNavigationPage : FlyoutPage
    {
        public MyNavigationPage()
        {
            InitializeComponent();
            flyout.listview.ItemSelected += OnSelectedItem;
        }

        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutItemPage;
            if(item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage)) {BarBackgroundColor = Color.Green };
                flyout.listview.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
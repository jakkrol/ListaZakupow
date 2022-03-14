using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaZakupow
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MyNavigationPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

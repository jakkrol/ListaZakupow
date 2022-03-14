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
    public partial class PromotionsPage : ContentPage
    {
        public PromotionsPage()
        {
            InitializeComponent();

            Biedronka.Source = ImageSource.FromResource("ListaZakupow.Images.biedronka.png");
            Lidl.Source = ImageSource.FromResource("ListaZakupow.Images.lidl.png");
            Zabka.Source = ImageSource.FromResource("ListaZakupow.Images.zabka.jpg");
        }

        private void Biedronka_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DisplayPromotionPage("https://ding.pl/biedronka,79?gclid=Cj0KCQiA95aRBhCsARIsAC2xvfwU5fd-XXB9ry2yQqeRyPh96cFqmCe5LlXKsgCTJ9Xp4dJd9rQNNFIaAuGfEALw_wcB"));
        }

        private void Lidl_Clicked(object sender, EventArgs e)
        {
           Navigation.PushAsync(new DisplayPromotionPage("https://www.gazetkowo.pl/v2/siec-handlowa/lidl?gclid=Cj0KCQjwz7uRBhDRARIsAFqjulkeRCHZZrK-CIhnXgMFbbDLPLM7VLqNalIU6HPSH8ACRotpVcjfuhEaAi_UEALw_wcB"));
        }

        private void Zabka_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DisplayPromotionPage("https://www.zabka.pl/gazetka-promocyjna"));
        }
    }
}
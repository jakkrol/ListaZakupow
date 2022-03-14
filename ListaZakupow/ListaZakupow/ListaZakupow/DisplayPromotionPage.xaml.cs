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
    public partial class DisplayPromotionPage : ContentPage
    {
        public DisplayPromotionPage(string link)
        {
            InitializeComponent();
            View.Source = link;
        }
    }
}
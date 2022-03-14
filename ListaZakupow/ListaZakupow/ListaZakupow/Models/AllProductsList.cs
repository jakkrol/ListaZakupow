using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace ListaZakupow.Models
{
    public class AllProductsList : ObservableCollection<Products>
    {
        public static ObservableCollection<Products> AllProductList = new ObservableCollection<Products>()
        {
            new Products{nazwa = "jabłko"},
            new Products{nazwa = "banan"},
            new Products{nazwa = "ananas"},
            new Products{nazwa = "arbuz"},
            new Products{nazwa = "kokos"}
        };



    }
}

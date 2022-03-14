using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace ListaZakupow.Models
{
    public class MainListClass : ListObject
    {
        static public ObservableCollection<ListObject> mainList { get; set; }

      
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ListaZakupow.Models
{

    [JsonObject]
    public class ListObject : ObservableCollection<Products>
    {
        [JsonProperty] public string listName { get; set; }
        [JsonProperty] public ObservableCollection<Products> ProductList { get; set; }
        [JsonProperty] public int CheckedItems { get; set; }
        [JsonProperty] public float Progress
        {
            get { return (float)CheckedItems / (float)ProductList.Count; }
            set { }
        }



       
        /*        public ListObject(string listname, List<Products> productlist)
                {
                    listName = listname;
                    ProductList = productlist;

                    foreach(var Product in productlist)
                    {
                        base.Add(Product);
                    }
                }*/
    }
}

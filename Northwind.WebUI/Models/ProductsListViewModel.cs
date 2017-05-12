using System.Collections.Generic;
using Domain;

namespace Northwind.WebUI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Products> Products { get; set; }
        public PagingInfo PagingInfo { get; set; } 
        public string CurrentCategory { get; set; }
    }
}
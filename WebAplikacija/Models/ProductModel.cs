using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplikacija.Models
{
    public class ProductModel
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public string Suplier { get; set; }
        public Nullable<decimal> Price { get; set; }


    }
}
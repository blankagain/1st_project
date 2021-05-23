using System;
using System.Collections.Generic;

#nullable disable

namespace product_catalog.Models
{
    public partial class Product1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PurchasePrice { get; set; }
        public int SellPrice { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}

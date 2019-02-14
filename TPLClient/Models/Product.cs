using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPLClient.Models
{
    public class Product
    {
        public string Name { get; set; }
        public int InventoryCount { get; set; }
        public int DiscountedPrice { get; set; }
     public double TotalExecutionTimeInSec { get; set; }
        public string Heading { get; set; }
    }

}
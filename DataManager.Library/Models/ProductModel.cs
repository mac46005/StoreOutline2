using System;
using System.Collections.Generic;
using System.Text;

namespace DataManager.Library.Models
{
    public class ProductModel
    {
        public string ProductName { get; set; }
        public string SerialNumber { get; set; }
        public int Gen_Id { get; set; }
        public decimal RetailPrice { get; set; }
        public int Tax_Id { get; set; }
        public int QuantityStock { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModified { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataManager.Library.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string SerialNumber { get; set; }

        public int Gen_Id { get; set; }

        [Required]
        [Range(0.01,2000)]
        public decimal RetailPrice { get; set; }

        public int Tax_Id { get; set; }

        public int QuantityStock { get; set; }
        
        public bool IsAvailable { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public DateTime LastModified { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DataManager.Library.Models
{
    public class SupplierModel
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string StateProvince { get; set; }
        public int MyProperty { get; set; }
    }
}

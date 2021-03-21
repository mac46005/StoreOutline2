using DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreOutline2.Areas.Admin.Models
{
    public class GeneralProductViewModel
    {
        public ProductModel Product { get; set; }
        public GeneralDetailsModel GenDetails { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DataManager.Library.Models
{
    interface IStreetAddress
    {
        public string Address { get; set; }
        public string StateProvince { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}

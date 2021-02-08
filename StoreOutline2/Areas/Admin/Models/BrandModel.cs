using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreOutline2.Areas.Admin.Models
{
    public class BrandModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Enter Brand Name.")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

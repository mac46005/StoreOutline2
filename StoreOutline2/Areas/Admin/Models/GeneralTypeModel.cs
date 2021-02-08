using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreOutline2.Areas.Admin.Models
{
    public class GeneralTypeModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Please enter a valid general type name.")]
        public string TypeName { get; set; }
    }
}

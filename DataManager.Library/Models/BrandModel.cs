using DataManager.Library.CustomAttributes;
using DataManager.Library.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataManager.Library.Models
{
    public class BrandModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Enter Brand Name.")]
        [CheckForDuplicate(PIM_Helper.ListOfBrandsNames())]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

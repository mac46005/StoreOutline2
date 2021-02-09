using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataManager.Library.Models
{
    public class SubTypeModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Please enter a valid Sub Type Name.")]
        public string SubTypeName { get; set; }
        [Required(ErrorMessage = "Please select the associated general type in the list.")]
        public int GeneralType_Id { get; set; }
    }
}

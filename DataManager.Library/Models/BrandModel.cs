
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
        private string name;
        public string Name 
        { get { return name; } 
            set 
            {
                name = value.Trim();
            } 
        }
        public string Description { get; set; }
    }
}

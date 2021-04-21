
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataManager.Library.Models
{
    public class ProductClassModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Please enter a valid product class name.")]
        private string _className;
        public string ClassName
        { 
            get{ return _className; }
            set
            {
                _className = value.Trim();
            }
        }





        public ICollection<int> Type_Ids { get; set; }
        public List<ProductTypeModel> Types { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataManager.Library.Models
{
    public class ProductClassModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Please enter a valid general type name.")]
        private string _class;
        public string Class
        { 
            get{ return _class; }
            set
            {
                _class = value.Trim();
            }
        }





        public ICollection<int> Type_Ids { get; set; }
        public List<ProductTypeModel> Types { get; set; }
    }
}

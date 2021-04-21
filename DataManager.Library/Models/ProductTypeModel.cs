
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataManager.Library.Models
{
    public class ProductTypeModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Please enter a valid Sub Type Name.")]
        private string _type;
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value.Trim();
            }
        }
        [Required(ErrorMessage = "Please select the associated general type in the list.")]
        public int ProductClass_Id { get; set; }
        public ProductClassModel ProductClass { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataManager.Library.Models
{
    public class GeneralTypeModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Please enter a valid general type name.")]
        private string _typeName;
        public string TypeName
        {
            get{ return _typeName; }
            set
            {
                _typeName = value.Trim();
            }
        }
    }
}

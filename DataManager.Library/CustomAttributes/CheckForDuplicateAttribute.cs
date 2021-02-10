using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataManager.Library.CustomAttributes
{
    public class CheckForDuplicateAttribute : ValidationAttribute
    {
        public List<string> ListOfValues { get; set; } = new List<string>();
        public CheckForDuplicateAttribute()
        {
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult result = ValidationResult.Success;

            bool isDuplicate = false;
            string duplicateValue = "";
            string valueToCheck = ((string)value).Trim().ToLower();
            foreach (var item in ListOfValues)
            {
                if (valueToCheck == item.Trim().ToLower())
                {
                    isDuplicate = true;
                    duplicateValue = item;
                }
            }
            if (isDuplicate)
            {
                string msg = base.ErrorMessage ?? $"The value already exists : {duplicateValue}";
                result =  new ValidationResult(msg);
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataManager.Library.CustomAttributes
{
    public class CheckForDuplicateAttribute : ValidationAttribute
    {
        private List<string> _listOfValues;
        public CheckForDuplicateAttribute(List<string> listOfValues)
        {
            _listOfValues = listOfValues;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult result = ValidationResult.Success;

            bool isDuplicate = false;
            string duplicateValue = "";
            string valueToCheck = ((string)value).Trim().ToLower();
            foreach (var item in _listOfValues)
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

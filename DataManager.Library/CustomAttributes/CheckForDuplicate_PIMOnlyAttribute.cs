using DataManager.Library.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataManager.Library.CustomAttributes
{
    public class CheckForDuplicate_PIMOnlyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult result = ValidationResult.Success;

            bool isDuplicate = false;
            string duplicateValue = "";
            string valueToCheck = ((string)value).Trim().ToLower();
            foreach (var item in PIM_Helper.ListOfAll_SubGenBrand_Names())
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EasonProjectASPNETMVC5.Models.MyValidation
{
    public class MyDateRangeValidationAttribute : ValidationAttribute
    {
        //public string startDate;

        public string startDate { get; set; }
        public string endDate { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime inputDate = (DateTime)value;
            if(inputDate>Convert.ToDateTime(startDate) && inputDate < Convert.ToDateTime(endDate))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("");
            }
        }
    }
}
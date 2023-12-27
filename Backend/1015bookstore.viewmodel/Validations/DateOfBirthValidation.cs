using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Validations
{
    public class DateOfBirthAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dob = (DateTime)value;
            return dob <= DateTime.Now && dob >= DateTime.Now.AddYears(-100);
        }
    }
}

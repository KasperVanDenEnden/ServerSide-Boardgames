using System.ComponentModel.DataAnnotations;

namespace Portal.Models
{
    public class ViewModelValidationAttributes
    {
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dateValue = (DateTime)value;
            if (dateValue < DateTime.Today)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }

    public class AfterTimeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var timeValue = (TimeSpan)value;
            var targetTime = new TimeSpan(18, 0, 0); // 6pm

            if (timeValue <= targetTime)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }

    public class NotZeroAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var intValue = (int)value;
            if (intValue == 0)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}

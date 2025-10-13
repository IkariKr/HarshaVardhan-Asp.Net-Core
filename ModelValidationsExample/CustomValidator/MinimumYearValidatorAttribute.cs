using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.CustomValidator;

public class MinimumYearValidatorAttribute:ValidationAttribute
{
    public int MinimumYear { get; set; } = 2000;
    public string DefaultErrorMessage { get; set; } = "Minimum Year must be greater than or equal to {0}.";
    
    public MinimumYearValidatorAttribute()
    {
        
    }
    
    public MinimumYearValidatorAttribute(int minimumYear)
    {
        MinimumYear =  minimumYear;
    }
    
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null)
        {
            var date =  (DateTime)value;
            if (date.Year < MinimumYear)
            {
                return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage,MinimumYear));
            }
        }
        return ValidationResult.Success;
    }
}
using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.CustomValidator;

public class DateRangeValidatorAttribute : ValidationAttribute
{
    public string OtherPropertyName { get; set; }
    
    public DateRangeValidatorAttribute(string otherPropertyName)
    {
        OtherPropertyName =  otherPropertyName;
    }
    
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null) return null;
        
        var toDate = Convert.ToDateTime(value);
        var otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName); //通过类型获取属性名
        if (otherProperty == null) return null;
        var fromDate = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));

        if (fromDate > toDate)
        {
            return new ValidationResult(ErrorMessage,new string[]
            {
                OtherPropertyName,validationContext.MemberName
            });
        }
        
        return ValidationResult.Success;

    }
}
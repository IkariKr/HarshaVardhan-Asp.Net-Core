using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ModelValidationsExample.CustomValidator;

namespace ModelValidationsExample.Models;

public class Person:IValidatableObject
{
    [Required(ErrorMessage = "{0} is required")]
    [Display(Name = "Person Name")]
    //最小长度总是索引号{2} 最大长度总是索引号{1}
    [StringLength(40,MinimumLength = 3,ErrorMessage = "{0} must be between {2} and {1} characters")]
    [RegularExpression("^[a-zA-Z .]+$", ErrorMessage = "{0} must be alphanumeric")]
    public string? PersonName { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    
    [Required(ErrorMessage = "{0} is required")]
    [Compare("Password", ErrorMessage = "{0} and {1} must match")]
    [Display(Name = "Confirm Password")]
    public string? ConfirmPassword { get; set; }
    
    [Range(100,10000,ErrorMessage = "{0} must be between {1} and {2}")]
    [ValidateNever]//暂时禁用属性验证
    public double? Price { get; set; }
    [Required(ErrorMessage = "{0} is required")]
    public string? Password { get; set; }

    //[MinimumYearValidator(2006,ErrorMessage ="Date of birth should not be newer than {0}")]
    [MinimumYearValidator(2006)] //可选的错误消息
    [BindNever]
    public DateTime? DateOfBirth { get; set; }
    
    public DateTime? FromDate { get; set; }
    [DateRangeValidator("FromDate",ErrorMessage="FromDate must be older than or equal to ToDate")]
    public DateTime? ToDate { get; set; }
    
    public int? Age { get; set; }
    
    public List<string?> Tags { get; set; } =  [];
    
    
    public override string ToString()
    {
        return $"PersonName:{PersonName},Phone:{Phone},Address:{Address},PhoneNumber:{PhoneNumber},Email:{Email},ConfirmPassword:{ConfirmPassword},Price:{Price},DataOfBirth:{DateOfBirth}";
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if(DateOfBirth.HasValue == false && Age.HasValue == false)
            yield return new ValidationResult("Either of Date of Brith or Age must be supplied",
                [nameof(DateOfBirth),nameof(Age)]);
    }
}
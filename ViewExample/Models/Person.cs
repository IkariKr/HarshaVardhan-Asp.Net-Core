namespace ViewExample.Models;

public class Person
{
    public string? PersonName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    public Gender? Gender { get; set; }
}

public enum Gender
{
    Male,Female,Other,
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDirectory.Shared;

public class Employee
{
    [Required(AllowEmptyStrings = false, ErrorMessage="Please enter first name.")]
    [MinLength(2, ErrorMessage = "Min length of first name is 2 letters.")]
    public string FirstName { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter last name.")]
    [MinLength(2, ErrorMessage = "Min length of last name is 2 letters.")]
    public string LastName { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter date of birth.")]
    public DateTime DateOfBirth { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter date of employment.")]
    public DateTime DateOfEmployment { get; set; }
    
    public string? Biography { get; set; }
}
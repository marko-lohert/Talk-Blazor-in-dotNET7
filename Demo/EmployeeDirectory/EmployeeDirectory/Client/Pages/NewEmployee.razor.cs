using EmployeeDirectory.Shared;
using System.Net.Http.Json;

namespace EmployeeDirectory.Client.Pages;

public partial class NewEmployee
{
    public Employee NewEmployeeModel { get; set; } = new();
    protected override void OnInitialized()
    {
        base.OnInitialized();

        // Default date of birth is this day 18 years ago.
        NewEmployeeModel.DateOfBirth = DateTime.Now.Date.AddYears(-18);
        // Default date of employment is today.
        NewEmployeeModel.DateOfEmployment = DateTime.Now.Date;
    }
    
    private void NewUserSubmit()
    {
        Http.PostAsJsonAsync<Employee>("Employee", NewEmployeeModel);
    }
}

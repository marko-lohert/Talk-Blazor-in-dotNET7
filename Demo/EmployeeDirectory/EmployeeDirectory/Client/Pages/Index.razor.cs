using EmployeeDirectory.Shared;
using System.Net.Http.Json;

namespace EmployeeDirectory.Client.Pages;

public partial class Index
{
    DirectoryOfEmployees? Directory { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Directory = await Http.GetFromJsonAsync<DirectoryOfEmployees>("DirectoryOfEmployees");
    }
}

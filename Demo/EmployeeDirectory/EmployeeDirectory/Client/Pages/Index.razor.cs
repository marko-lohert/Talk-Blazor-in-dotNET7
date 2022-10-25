using EmployeeDirectory.Shared;
using System.Net.Http.Json;

namespace EmployeeDirectory.Client.Pages;

public partial class Index
{
    DirectoryOfEmployees? Directory { get; set; }

    public string FilterText { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await LoadDataFromServer();
    }

    private async Task LoadDataFromServer()
    {
        if (FilterText is null or "")
            Directory = await Http.GetFromJsonAsync<DirectoryOfEmployees>("api/DirectoryOfEmployees");
        else
            Directory = await Http.GetFromJsonAsync<DirectoryOfEmployees>($"api/DirectoryOfEmployees/GetFilter?filterText={FilterText}");
    }
}

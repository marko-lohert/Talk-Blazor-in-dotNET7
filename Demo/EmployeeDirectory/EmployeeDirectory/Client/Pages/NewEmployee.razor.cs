﻿using EmployeeDirectory.Shared;
using Microsoft.AspNetCore.Components.Routing;
using System.Net.Http.Json;

namespace EmployeeDirectory.Client.Pages;

public partial class NewEmployee
{
    public Employee NewEmployeeModel { get; set; } = new();

    // Did user start entered any data in this page?
    public bool IsDirty { get; set; } = false;

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

    void OnDataInput()
    {
        IsDirty = true;
    }

    async Task BeforeNavigationAsync(LocationChangingContext context)
    {
        bool userConfirmed = await JS.InvokeAsync<bool>("window.confirm", new object[] { "If you leave this page, you'll lose your changes." });

        if (userConfirmed is false)
        {
            context.PreventNavigation();
        }
    }
}

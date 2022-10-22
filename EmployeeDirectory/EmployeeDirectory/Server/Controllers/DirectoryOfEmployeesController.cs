using EmployeeDirectory.Server.DAL;
using EmployeeDirectory.Shared;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDirectory.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class DirectoryOfEmployeesController
{
    private readonly ILogger<DirectoryOfEmployeesController> _logger;

    public DirectoryOfEmployeesController(ILogger<DirectoryOfEmployeesController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public DirectoryOfEmployees Get()
    {
        DirectoryOfEmployeesDAO dao = new();
        return dao.GetDirectoryOfEmployees();
    }
}

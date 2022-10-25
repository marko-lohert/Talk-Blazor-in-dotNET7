using EmployeeDirectory.Server.DAL;
using EmployeeDirectory.Shared;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDirectory.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
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

    [HttpGet("GetFilter")]
    public DirectoryOfEmployees GetFilter([FromQuery] string filterText)
    {
        DirectoryOfEmployeesDAO dao = new();
        return dao.GetDirectoryOfEmployees(filterText);
    }
}

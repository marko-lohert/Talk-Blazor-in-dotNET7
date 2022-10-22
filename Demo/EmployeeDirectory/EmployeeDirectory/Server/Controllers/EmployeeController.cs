using EmployeeDirectory.Server.DAL;
using EmployeeDirectory.Shared;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDirectory.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController
{
    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(ILogger<EmployeeController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public void Post([FromBody] Employee employee)
    {
        EmployeeDAO dao = new();
        dao.AddNewEmployee(employee);
    }
}

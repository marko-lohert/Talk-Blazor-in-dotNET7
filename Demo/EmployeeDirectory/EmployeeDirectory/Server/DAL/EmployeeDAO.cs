using EmployeeDirectory.Shared;

namespace EmployeeDirectory.Server.DAL;

public class EmployeeDAO
{
    public void AddNewEmployee(Employee employee)
    {
        if (employee is not null)
            DirectoryOfEmployeesDAO.CacheDirectoryOfEmployees?.Employees?.Insert(index: 0, employee);
    }
}

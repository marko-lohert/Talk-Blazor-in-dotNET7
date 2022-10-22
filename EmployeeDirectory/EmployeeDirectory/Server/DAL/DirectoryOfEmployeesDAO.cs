using EmployeeDirectory.Shared;

namespace EmployeeDirectory.Server.DAL;

public class DirectoryOfEmployeesDAO
{
    public DirectoryOfEmployees GetDirectoryOfEmployees()
    {
        return MockDataDirectoryOfEmployees(countEmployees: 1000);
    }

    private static DirectoryOfEmployees MockDataDirectoryOfEmployees(int countEmployees)
    {
        if (countEmployees <= 0)
            return new() { Employees = new() };

        DirectoryOfEmployees directory = new() { Employees = new() };

        for (int i = 0; i < countEmployees; i++)
        {
            Employee employee = MockDataEmployee();
            directory.Employees.Add(employee);
        }

        return directory;
    }

    private static Employee MockDataEmployee()
    {
        string randomFirstName = FirstNames[Random.Shared.Next(FirstNames.Length)];
        string randomLastName = LastNames[Random.Shared.Next(LastNames.Length)];
        DateTime randomDateOfBirth = DateTime.Now.AddDays(-1 * Random.Shared.Next(MinEmployeeAgeInDays, MaxEmployeeAgeInDays));
        DateTime minPossibleDateOfEmployment = randomDateOfBirth.AddDays(MinEmployeeAgeInDays);
        int maxPossibleDatesOnJob = DateTime.Now.Date.Subtract(minPossibleDateOfEmployment).Days;
        DateTime randomDateOfEmployment = minPossibleDateOfEmployment.AddDays(Random.Shared.Next(maxPossibleDatesOnJob));

        return new Employee(
            FirstName: randomFirstName,
            LastName: randomLastName,
            DateOfBirth: randomDateOfBirth,
            DateOfEmployment: randomDateOfEmployment,
            Biography: string.Empty
            );
    }

    static readonly string[] FirstNames = { "Anna", "Arthur", "Barbara", "Bill", "Jane", "Joe", "John", "Nicole", "Susan", "Mark" };
    static readonly string[] LastNames = { "Anderson", "Davis", "Diaz", "Jackson", "Johnson", "Lopez", "Miller", "Scott", "Smith", "Williams" };

    const int MinEmployeeAgeInDays = 18 * 365;
    const int MaxEmployeeAgeInDays = 65 * 365;
}

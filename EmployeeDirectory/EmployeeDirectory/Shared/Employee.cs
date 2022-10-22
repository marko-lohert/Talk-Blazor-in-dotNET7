namespace EmployeeDirectory.Shared;

public record Employee(string FirstName, string LastName, DateTime DateOfBirth, DateTime DateOfEmployment, string? Biography);
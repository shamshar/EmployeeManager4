namespace WiredBrainCoffee.EmployeeManager.Models
{
    public record EmployeeDto(
        int Id,
        string FirstName,
        string LastName,
        bool IsDeveloper,
        string DepartmentName
    );
}


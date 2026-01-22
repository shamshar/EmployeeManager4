namespace WiredBrainCoffee.EmployeeManager.Models
{
    public class EmployeeEditDto
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public bool IsDeveloper { get; set; }

        public int? DepartmentId { get; set; }

        public List<DepartmentDto>? Departments { get; set; }
    }
}

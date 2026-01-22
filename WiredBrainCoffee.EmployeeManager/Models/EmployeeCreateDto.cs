using System.ComponentModel.DataAnnotations;

namespace WiredBrainCoffee.EmployeeManager.Models
{
    public class EmployeeCreateDto
    {
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; } = string.Empty;

        public bool IsDeveloper { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        public int? DepartmentId { get; set; }

        public List<DepartmentDto> Departments { get; set; } = new();
    }
}

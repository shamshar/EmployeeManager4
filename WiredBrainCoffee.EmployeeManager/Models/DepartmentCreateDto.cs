using System.ComponentModel.DataAnnotations;

namespace WiredBrainCoffee.EmployeeManager.Models
{
    public class DepartmentCreateDto
    {
        [Required, StringLength(50)]
        public string? Name { get; set; } = string.Empty;
    }

}

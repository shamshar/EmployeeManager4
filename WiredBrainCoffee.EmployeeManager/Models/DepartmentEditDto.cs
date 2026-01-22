using System.ComponentModel.DataAnnotations;

namespace WiredBrainCoffee.EmployeeManager.Models
{
    public class DepartmentEditDto
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string? Name { get; set; } = string.Empty;
    }
}


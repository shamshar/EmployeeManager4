using WiredBrainCoffee.EmployeeManager.Models;

namespace WiredBrainCoffee.EmployeeManager.Services
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAllAsync();
        Task<DepartmentDto?> GetByIdAsync(int id);
        Task CreateAsync(string name);
        Task UpdateAsync(int id, string name);
        Task DeleteAsync(int id);
        Task CreateAsync(DepartmentCreateDto dto);
        Task UpdateAsync(DepartmentEditDto dto);
    }
}

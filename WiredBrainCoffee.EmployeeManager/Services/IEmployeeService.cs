using WiredBrainCoffee.EmployeeManager.Models;

namespace WiredBrainCoffee.EmployeeManager.Services
{
    public interface IEmployeeService
{
        Task<List<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(EmployeeDto employee);
        Task UpdateAsync(EmployeeDto employee);
        Task DeleteAsync(int id);
        Task<EmployeeEditDto?> GetEditAsync(int id);
        Task UpdateAsync(EmployeeEditDto employee);
        Task<int> CreateAsync(EmployeeCreateDto employee);
        Task<List<DepartmentDto>> GetAllDepartmentsAsync();







    }
}

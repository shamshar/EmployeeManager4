using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.EmployeeManager.Data;
using WiredBrainCoffee.EmployeeManager.Models;

namespace WiredBrainCoffee.EmployeeManager.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDbContextFactory<EmployeeManagerDbContext> _factory;

        public EmployeeService(IDbContextFactory<EmployeeManagerDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            using var db = _factory.CreateDbContext();

            return await db.Employee
                .Include(e => e.Department)
                .Select(e => new EmployeeDto(e.Id, e.FirstName!, e.LastName!, e.IsDeveloper, e.Department!.Name))
                .ToListAsync();
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            using var db = _factory.CreateDbContext();
            var employee = await db.Employee
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null) return null;

            return new EmployeeDto(
                employee.Id,
                employee.FirstName!,
                employee.LastName!,
                employee.IsDeveloper,
                employee.Department!.Name
            );
        }


        public async Task<int> CreateAsync(EmployeeDto dto)
        {
            using var db = _factory.CreateDbContext();

            var entity = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DepartmentId = 1 // example: assign default dept
            };

            db.Employee.Add(entity);
            await db.SaveChangesAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(EmployeeDto dto)
        {
            using var db = _factory.CreateDbContext();

            var entity = await db.Employee.FindAsync(dto.Id);
            if (entity == null) return;

            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;

            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var db = _factory.CreateDbContext();

            var employee = await db.Employee.FindAsync(id);
            if (employee == null) return;

            db.Employee.Remove(employee);
            await db.SaveChangesAsync();
        }


        public async Task<EmployeeEditDto?> GetEditAsync(int id)
        {
            using var db = _factory.CreateDbContext();

            var employee = await db.Employee
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
                return null;

            var deps = await db.Department
                .Select(d => new DepartmentDto(d.Id, d.Name))
                .ToListAsync();

            return new EmployeeEditDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                IsDeveloper = employee.IsDeveloper,
                DepartmentId = employee.DepartmentId,
                Departments = deps
            };
        }

        public async Task UpdateAsync(EmployeeEditDto dto)
        {
            using var db = _factory.CreateDbContext();

            var employee = await db.Employee.FindAsync(dto.Id);
            if (employee == null) return;

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.IsDeveloper = dto.IsDeveloper;
            employee.DepartmentId = dto.DepartmentId;

            await db.SaveChangesAsync();
        }

        public async Task<int> CreateAsync(EmployeeCreateDto dto)
        {
            using var db = _factory.CreateDbContext();

            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                IsDeveloper = dto.IsDeveloper,
                DepartmentId = dto.DepartmentId
            };

            db.Employee.Add(employee);
            await db.SaveChangesAsync();

            return employee.Id;
        }

        public async Task<List<DepartmentDto>> GetAllDepartmentsAsync()
        {
            using var db = _factory.CreateDbContext();
            return await db.Department
                .Select(d => new DepartmentDto(d.Id, d.Name))
                .ToListAsync();
        }


    }

}

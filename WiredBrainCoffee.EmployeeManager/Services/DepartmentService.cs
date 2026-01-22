using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.EmployeeManager.Data;
using WiredBrainCoffee.EmployeeManager.Models;

namespace WiredBrainCoffee.EmployeeManager.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDbContextFactory<EmployeeManagerDbContext> _db;

        public DepartmentService(IDbContextFactory<EmployeeManagerDbContext> db)
        {
            _db = db;
        }

        public async Task<List<DepartmentDto>> GetAllAsync()
        {
            using var ctx = _db.CreateDbContext();
            return await ctx.Department
                .OrderBy(d => d.Name)
                .Select(d => new DepartmentDto(d.Id, d.Name))
                .ToListAsync();
        }

        public async Task<DepartmentDto?> GetByIdAsync(int id)
        {
            using var ctx = _db.CreateDbContext();
            return await ctx.Department
                .Where(d => d.Id == id)
                .Select(d => new DepartmentDto(d.Id, d.Name))
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(string name)
        {
            using var ctx = _db.CreateDbContext();
            ctx.Department.Add(new Department { Name = name });
            await ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, string name)
        {
            using var ctx = _db.CreateDbContext();
            var dep = await ctx.Department.FindAsync(id);
            if (dep is null) return;
            dep.Name = name;
            await ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var ctx = _db.CreateDbContext();

            var dep = await ctx.Department
                .Include(d => d.Employees)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (dep is null)
                return;

            if (dep.Employees.Any())
                throw new InvalidOperationException(
                    $"Department cannot be deleted, as it has {dep.Employees.Count} employee(s)");

            ctx.Department.Remove(dep);
            await ctx.SaveChangesAsync();
        }


        public async Task CreateAsync(DepartmentCreateDto dto)
        {
            var dep = new Department
            {
                Name = dto.Name
            };

            using var ctx = _db.CreateDbContext();
            ctx.Department.Add(dep);
            await ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(DepartmentEditDto dto)
        {
            using var ctx = _db.CreateDbContext();
            var dep = await ctx.Department.FindAsync(dto.Id);
            if (dep is null)
                throw new InvalidOperationException("Department not found");

            dep.Name = dto.Name;
            await ctx.SaveChangesAsync();
        }

    }
}

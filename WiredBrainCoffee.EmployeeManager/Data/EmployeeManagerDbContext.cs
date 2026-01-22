using Microsoft.EntityFrameworkCore;

namespace WiredBrainCoffee.EmployeeManager.Data
{
    public class EmployeeManagerDbContext : DbContext
    {
        public EmployeeManagerDbContext
            (DbContextOptions<EmployeeManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; } = default!;

        public DbSet<Department> Department { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "IT" }
                );

            modelBuilder.Entity<Employee>().Property(e => e.DepartmentId)
                .HasDefaultValue(1);
        }
    }
}

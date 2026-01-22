using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.EmployeeManager.Components;
using WiredBrainCoffee.EmployeeManager.Data;
using WiredBrainCoffee.EmployeeManager.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<EmployeeManagerDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("EmployeeManagerDbContext") ?? throw new InvalidOperationException("Connection string 'EmployeeManagerDbContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

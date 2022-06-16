using DFA_CORE.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using NToastNotify;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddNToastNotifyNoty(new NotyOptions
{
    ProgressBar = true,
    Timeout = 5000
});

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<EmployeeDbContext>(x => x.UseSqlServer(connectionString));
//builder.Services.AddDbContext<MVC_EFContext>(options =>
    // options.UseSqlServer("DefaultConnection"));
builder.Services.AddDbContext<MVC_EFContext>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseNToastNotify();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using SportsRentalManagement.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient(); // Add this line

// Configurar DbContext con SQL Server
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SportsRentalManagementConnection"));
});

var app = builder.Build();
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Configuración de las rutas de los controladores
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
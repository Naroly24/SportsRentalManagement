using Microsoft.EntityFrameworkCore;
using SportsRentalManagement.Data;

var builder = WebApplication.CreateBuilder(args);

// Servicios para la aplicación web (MVC) y API
builder.Services.AddControllersWithViews(); // Para vistas y controladores
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SportsRentalManagementConnection"),
        b => b.MigrationsAssembly("SportsRentalManagement.Infrastructure")
    ));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SportsRentalManagement API v1"));
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Mapea las rutas para API y vistas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");  //HomeController y su acción Index

app.MapControllers();  // Para la API

app.Run();

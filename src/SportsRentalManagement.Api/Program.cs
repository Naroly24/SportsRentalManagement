using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using SportsRentalManagement.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllers(); // Solo los controladores API, no las vistas

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar HttpClient si lo necesitas para hacer llamadas HTTP en tu API
builder.Services.AddHttpClient();

// Configurar DbContext con SQL Server
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SportsRentalManagementConnection"));
});

// Configurar la licencia de ExcelPackage
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

var app = builder.Build();

// Configuración de la tubería de solicitud HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();  // Esta línea también se puede eliminar si no necesitas HSTS.
}

// Desactivar la redirección HTTPS
app.UseHttpsRedirection(); // Comenta o elimina esta línea si no deseas usar HTTPS


app.UseRouting();
app.UseAuthorization();

// Configurar Swagger para que funcione en la ruta /swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sports Rental API v1");
        c.RoutePrefix = string.Empty; // Esto hará que Swagger se cargue en la raíz: http://localhost:5012/
    });
}

app.MapControllers(); // Configura las rutas de los controladores

app.Run();
builder.Logging.AddConsole();

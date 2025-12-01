using Microsoft.EntityFrameworkCore;
using Proyecto2025.BE.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();






// Registrar AppDbContext para que ASP.NET Core pueda inyectarlo en los controladores
// Aquí definimos la cadena de conexión a SQL Server Express
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// -----------------------------
// 2. Construir la aplicación
// -----------------------------
var app = builder.Build();
//activar si estamos en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    //Iniciar Swagger
    app.UseSwagger();
    //activar la interfaz de swagger
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty; // Esto hace que Swagger esté en la raíz "/" sin esto estaría en "/swagger"
    }
);
}
//No usamos pipeline

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//   app.UseExceptionHandler("/Error");
//}
//app.UseStaticFiles();

//app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
//No usamos RazorPages
//app.MapRazorPages();

app.Run();
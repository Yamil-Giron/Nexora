using Nexora.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configurar DbContext con PostgreSQL
builder.Services.AddDbContext<NexoraContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("NexoraDb")));

// 🔑 Agregar soporte para sesiones
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;                 // más seguro
    options.Cookie.IsEssential = true;              // requerido para GDPR
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // importante para CSS/JS

app.UseRouting();
app.UseAuthorization();

// 🔑 Activar sesiones
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

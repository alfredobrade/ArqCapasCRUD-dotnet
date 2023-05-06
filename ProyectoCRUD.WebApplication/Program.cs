
using Microsoft.EntityFrameworkCore;
using ProyectoCRUD.BLL.Services;
using ProyectoCRUD.DAL.DataContext;
using ProyectoCRUD.DAL.Repository;
using ProyectoCRUD.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CeCrudArqcapasContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConection"));
});
// inyeccion de dependencias de servicios
builder.Services.AddScoped<IGenericRepository<Contacto>, ContactoRepository>();
builder.Services.AddScoped<IContactoService, ContactoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

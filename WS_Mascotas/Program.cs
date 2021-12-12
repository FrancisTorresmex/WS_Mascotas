using Microsoft.EntityFrameworkCore;
using WS_Mascotas.Models.Base;
using WS_Mascotas.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Inyección de dependencias
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

//Conexón con la bd
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(@"Server=LAPTOP-TF5M9SUU;Database=Mascotas;Trusted_Connection=True;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

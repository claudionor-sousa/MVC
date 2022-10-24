using Microsoft.EntityFrameworkCore;
using ProjetoEstagioMVC.data;
using ProjetoEstagioMVC.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BancoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultconnect")));
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
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
    pattern: "{controller=LoginUsuario}/{action=Index}/{id?}");

app.Run();
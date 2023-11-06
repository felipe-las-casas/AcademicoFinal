using Academico.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("AcademicoDbConnection");
builder.Services.AddDbContext<AcademicoContext>(options => options.UseSqlServer(connectionString));
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
app.MapControllerRoute(
    name: "instituicao",
    pattern: "{controller=Instituicao}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "curso",
    pattern: "{controller=Curso}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "disciplina",
    pattern: "{controller=Disciplina}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "departamento",
    pattern: "{controller=Departamento}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "cursodisciplina",
    pattern: "{controller=CursoDisciplina}/{action=Index}/{id?}");

app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using guido_sanz_parcial1.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MotoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MotoContext") ?? throw new InvalidOperationException("Connection string 'MotoContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Agency}/{action=Index}/{id?}");

app.Run();

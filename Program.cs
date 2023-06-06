using Microsoft.EntityFrameworkCore;
using guido_sanz_parcial1.Data;
using guido_sanz_parcial1.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MotoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MotoContext") ?? throw new InvalidOperationException("Connection string 'MotoContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MotoContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAgencyService, AgencyServiceImpl>();
builder.Services.AddScoped<IInventoryService, InventoryServiceImpl>();
builder.Services.AddScoped<IMotoService, MotoServiceImpl>();
builder.Services.AddScoped<IUsersService, UsersServiceImpl>();
builder.Services.AddScoped<IRolesService, RolesServiceImpl>();
builder.Services.AddScoped<IAccesoryService, AccesoryServiceImpl>();

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
app.MapRazorPages();

app.Run();

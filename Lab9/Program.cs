using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using lab9.Data;
using lab9.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("lab9ContextConnection") ?? throw new InvalidOperationException("Connection string 'lab9ContextConnection' not found.");

builder.Services.AddDbContext<lab9Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<lab9User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<lab9Context>();

builder.Services.AddControllersWithViews(); // Enable MVC
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

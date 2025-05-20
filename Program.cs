using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SUFEEASP.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Configure Entity Framework Core with SQL Server
builder.Services.AddDbContext<SUFEEASPContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SUFEEASPContext") ??
        throw new InvalidOperationException("Connection string 'SUFEEASPContext' not found.")));

// Add session support
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // Must be before UseAuthorization

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
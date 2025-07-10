using Microsoft.EntityFrameworkCore;
using OwnerApp.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add services to the container.

// 1. Connect to SQLite (for Render or cross-platform support)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Add MVC and Razor Views
builder.Services.AddControllersWithViews();

// 3. Enable session
builder.Services.AddSession();

var app = builder.Build();

// ✅ Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ✅ Use session before authorization
app.UseSession();

app.UseAuthorization();

// ✅ Configure default MVC route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ✅ Set Render-compatible port
app.Urls.Add("http://*:8080");

app.Run();

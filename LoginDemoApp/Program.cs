using LoginDemoApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
// Register session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Register IHttpContextAccessor if you plan to use it
builder.Services.AddHttpContextAccessor();
// Add MySQL DB context with a connection string from appsettings.json.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));


builder.Services.AddRazorPages(); // If you're using Razor Pages, make sure this is added as well.

// Register any other required services here, if needed.


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enables detailed error pages and exception stack traces in the development environment.
    app.UseDeveloperExceptionPage();
}
else
{
    // Configures error handling in production (redirect to a friendly error page).
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Enforces strict HTTP headers for better security.
}

app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS for better security.
app.UseStaticFiles(); // Serves static files (like CSS, JS, images).
app.UseRouting(); // Enables routing to controller actions.
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// For Razor Pages (if you're using them), you can map them like so:
// app.MapRazorPages();

app.Run(); // Starts the web application.

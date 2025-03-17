var builder = WebApplication.CreateBuilder(args);

// Lägg till stöd för MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Använd statiska filer (för CSS, JS, bilder)
app.UseStaticFiles();

// Konfigurera routing
app.UseRouting();

// Endpoints för MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Index}/{id?}");


app.Run();

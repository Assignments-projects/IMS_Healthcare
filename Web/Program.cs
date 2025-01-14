using ServiceLayer;
using DbLayer;
using AuthLayer;
using Web.Helper;
using Rotativa.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

// Add the in-memory cache and logging services
builder.Services.AddMemoryCache();
builder.Services.AddLogging();

// Add Layers's Services
builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddBusinessLogicServices(builder.Configuration);
builder.Services.AddAuthServices();

// Configure Automapper
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseRotativa();

// Initialize the static UserHelper with IHttpContextAccessor
var httpContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
UserHelper.Initialize(httpContextAccessor);

// Use refresh claims middleware
app.UseMiddleware<RefreshClaimsMiddleware>();

// Use Authorization middleware
app.UseMiddleware<AuthorizationMiddleware>();


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
    name: "login",
    pattern: "",
    defaults: new { controller = "Account", action = "Login" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using Domain;
using Domainservices.Interfaces.IRepositories;
using Domainservices.Interfaces.IServices;
using Domainservices.Services;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
// DBContext DB's configurations
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationConnectionString")));
builder.Services.AddDbContext<SecurityDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("SecurityConnectionString")));

// Add Identity services
builder.Services.AddIdentity<UserIdentity, IdentityRole>()
        .AddEntityFrameworkStores<SecurityDbContext>()
        .AddSignInManager<SignInManager<UserIdentity>>()
        .AddDefaultTokenProviders();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Repositories AddScoped
builder.Services.AddScoped<IUserRepository, IUserRepository>();
builder.Services.AddScoped<IGamenightRepository, GamenightRepository>();
builder.Services.AddScoped<IBoardgameRepository, BoardgameRepository>();

// Services AddScoped
builder.Services.AddScoped<IAccountService, AccountService>();

// Authenticated
builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", config =>
    {
        config.Cookie.Name = "AuthorizationCookieSSBG";
        config.LoginPath = "/Account/Login";
    });

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

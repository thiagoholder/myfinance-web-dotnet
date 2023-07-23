using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using MyFinance.Infrastructure;
using MyFinance.WebApp.Configs;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var ptBr = new CultureInfo("pt-BR");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(ptBr),
    SupportedCultures = new[] { ptBr },
    SupportedUICultures = new[] { ptBr }
};
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = localizationOptions.DefaultRequestCulture;
    options.SupportedCultures = localizationOptions.SupportedCultures;
    options.SupportedUICultures = localizationOptions.SupportedUICultures;
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyFinanceDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});


//Registers
builder.Services
    .RegisterPlanoConta()
    .RegisterTransacao();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRequestLocalization(localizationOptions); // Aplica as configurações de localização definidas anteriormente

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
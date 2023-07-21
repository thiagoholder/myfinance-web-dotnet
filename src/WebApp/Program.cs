using Microsoft.EntityFrameworkCore;
using MyFinance.Application;
using MyFinance.Application.Interfaces;
using MyFinance.Domain.Interfaces.Repositories;
using MyFinance.Domain.Interfaces.Services;
using MyFinance.Infrastructure;
using MyFinance.Infrastructure.Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyFinanceDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IPlanoContaRepository, PlanoContaRepository>();
builder.Services.AddScoped<IPlanoContaService, PlanoContaService>();
builder.Services.AddScoped<IGetAllPlanoConta, GetAllPlanoConta>();
builder.Services.AddScoped<IDeletePlanoConta, DeletePlanoConta>();
builder.Services.AddScoped<IGetPlanoContaById, GetPlanoContaById>();
builder.Services.AddScoped<IUpdatePlanoConta, UpdatePlanoConta>();
builder.Services.AddScoped<ICreatePlanoConta, CreatePlanoConta>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
using MyFinance.Application.Interfaces;
using MyFinance.Application;
using MyFinance.Domain.Interfaces.Repositories;
using MyFinance.Domain.Interfaces.Services;
using MyFinance.Infrastructure.Repositories;
using MyFinance.Services;
using MyFinance.Application.TransacaoUserCase;

namespace MyFinance.WebApp.Configs;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterPlanoConta(this IServiceCollection services)
    {
        services.AddScoped<IPlanoContaRepository, PlanoContaRepository>();
        services.AddScoped<IPlanoContaService, PlanoContaService>();
        services.AddScoped<IGetAllPlanoConta, GetAllPlanoConta>();
        services.AddScoped<IDeletePlanoConta, DeletePlanoConta>();
        services.AddScoped<IGetPlanoContaById, GetPlanoContaById>();
        services.AddScoped<IUpdatePlanoConta, UpdatePlanoConta>();
        services.AddScoped<ICreatePlanoConta, CreatePlanoConta>();

        return services;
    }

    public static IServiceCollection RegisterTransacao(this IServiceCollection services)
    {
        services.AddScoped<ITransacaoRepository, TransacaoRepository>();
        services.AddScoped<ITransacaoService, TransacaoService>();
        services.AddScoped<IGetAllTransacoes, GetAllTransacao>();
        services.AddScoped<IDeleteTransacao, DeleteTrancao>();
        services.AddScoped<IGetTransacaoById, GetTransacaoById>();
        services.AddScoped<IUpdateTransacao, UpdateTransacao>();

        return services;
    }
}



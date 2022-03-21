using Dutiful.Entity.Team;
using Dutiful.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Service.Injection;

public static class Injector
{
    public static IServiceCollection AddDependencies(this IServiceCollection service)
    {
        service.AddBaseDependency();
        service.AddServiceDepdency();
        service.AddToolsDependncy();
        return service;
    }

    public static IServiceCollection AddBaseDependency(this IServiceCollection service)
    {
        service.AddScoped<IBaseRules<Team>, BaseServices<Team>>();


        return service;
    }

    public static IServiceCollection AddServiceDepdency(this IServiceCollection service)
    {
        service.AddTransient<IAccountRules, AccountServices>();
        service.AddTransient<ITeamRules, TeamServices>();
        service.AddTransient<IApiCall, ApiCall>();
        service.AddTransient<HttpClient>();

        return service;
    }

    public static IServiceCollection AddToolsDependncy(this IServiceCollection service)
    {
        return service;
    }
}
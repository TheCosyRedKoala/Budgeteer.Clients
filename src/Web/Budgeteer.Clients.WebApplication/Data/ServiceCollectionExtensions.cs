using TCRK.Models.Budgeteer.Budgets;

namespace Budgeteer.Clients.WebApplication.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRestServices(this IServiceCollection services)
    {
        services.AddTransient<IBudgetService, BudgetService>();

        return services;
    }
}

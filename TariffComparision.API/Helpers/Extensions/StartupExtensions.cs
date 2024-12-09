using TariffComparision.API.Services.Tariff;

namespace TariffComparision.API.Helpers.Extensions
{
    public static class StartupExtensions
    {
        public static void AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITariffService, TariffService>();
        }
    }
}

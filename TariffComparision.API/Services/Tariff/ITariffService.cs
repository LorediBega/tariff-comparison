using TariffComparision.API.Models.DTO;

namespace TariffComparision.API.Services.Tariff
{
    public interface ITariffService
    {
        Task<List<CalculatedCostsDTO>> CalculateTariff(decimal yearlyConsumption);
    }
}

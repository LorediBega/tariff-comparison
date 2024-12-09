using TariffComparision.API.Models.DTO;
using TariffComparision.API.Models.Exceptions;
using TariffComparision.API.Models.Helpers;
using static TariffComparision.API.Helpers.Enumerations.Enumerations;

namespace TariffComparision.API.Services.Tariff
{
    public class TariffService : ITariffService
    {
        //This is a mock of the items returned by the Tariff Provider
        private readonly List<TariffType> TariffTypes = new List<TariffType> 
        {
            new TariffType
            {
                Name = "Product A",
                Type = TariffTypeEnum.BasicElecticity,
                BaseCost = 5,
                AdditionalKwhCost = 22
            },
            new TariffType
            {
                Name = "Product B",
                Type = TariffTypeEnum.Packaged,
                BaseCost = 800,
                AdditionalKwhCost = 30,
                IncludedKwh = 4000
            }
        };

        public async Task<List<CalculatedCostsDTO>> CalculateTariff(decimal yearlyConsumption)
        {
            if (yearlyConsumption <= 0)
                throw new ConsumptionValidationException("Enter a valid value for yearly consumption!");

            return TariffTypes.Select(tt => new CalculatedCostsDTO(tt, yearlyConsumption))
                .OrderBy(t => t.AnnualCost).ToList();
        }

        
    }
}

using static TariffComparision.API.Helpers.Enumerations.Enumerations;
using TariffComparision.API.Models.Helpers;

namespace TariffComparision.API.Models.DTO
{
    public class CalculatedCostsDTO
    {
        public CalculatedCostsDTO(TariffType tariffType, decimal yearlyConsumption)
        {
            TariffName = tariffType.Name;
            AnnualCost = CalculateAnnualCost(tariffType, yearlyConsumption);
        }

        public string TariffName { get; set; }
        public decimal AnnualCost { get;set; }

        #region Helper methods

        private decimal CalculateAnnualCost(TariffType tariffType, decimal yearlyConsumption)
        {
            decimal annualCost = 0;
            if (tariffType.Type == TariffTypeEnum.BasicElecticity)
                annualCost = CalculateBasicTariff(tariffType, yearlyConsumption);
            else if (tariffType.Type == TariffTypeEnum.Packaged)
                annualCost = CalculatePackagedTariff(tariffType, yearlyConsumption);

            return annualCost;
        }

        /// <summary>
        /// (<base cost>€ * 12 months) = <total base costs>€ + (<yearly consumption> * <additional cost> cent/kwh) = <total consumption costs>€
        /// </summary>
        private decimal CalculateBasicTariff(TariffType tariffType, decimal yearlyConsumption)
        {
            return (tariffType.BaseCost * 12) + (yearlyConsumption * (tariffType.AdditionalKwhCost / 100));
        }

        private decimal CalculatePackagedTariff(TariffType tariffType, decimal yearlyConsumption)
        {
            //If less or equal than included kwh range return base cost
            if (yearlyConsumption <= tariffType.IncludedKwh)
                return tariffType.BaseCost;
            //If more than included kwh range <base cost>€ + (<difference of the consumpption and value included> * <additional cost> cent/kwh) = <total consumption cost>€
            else
                return tariffType.BaseCost + ((yearlyConsumption - tariffType.IncludedKwh.Value) * (tariffType.AdditionalKwhCost / 100));
        }

        #endregion
    }
}

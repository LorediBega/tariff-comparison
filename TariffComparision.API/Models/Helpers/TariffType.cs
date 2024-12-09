using static TariffComparision.API.Helpers.Enumerations.Enumerations;

namespace TariffComparision.API.Models.Helpers
{
    public class TariffType
    {
        public string Name { get; set; }
        public TariffTypeEnum Type { get; set; }
        public decimal BaseCost { get; set; }
        public decimal AdditionalKwhCost { get; set; }
        public decimal? IncludedKwh { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TariffComparision.API.Models.DTO;
using TariffComparision.API.Services.Tariff;

namespace TariffComparision.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CostController : ControllerBase
    {
        private readonly ITariffService _tariffService;

        public CostController(ITariffService tariffService)
        {
            _tariffService = tariffService;
        }

        [SwaggerOperation("Calculate electricity yearly tariff in €, based on yearly consumption value provided")]
        [HttpGet("annual")]
        [ProducesResponseType(typeof(List<CalculatedCostsDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<CalculatedCostsDTO>>> GetAnnualCost([SwaggerParameter("Yearly consumption kwh/year")] decimal yearlyConsumption) =>
            Ok(await _tariffService.CalculateTariff(yearlyConsumption));
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TypedConfigurationsValidation_IOptions_Example.Configurations;

namespace TypedConfigurationsValidation_IOptions_Example.Controllers;
[ApiController]
[Route("/configurations")]
public class ConfigurationsController : ControllerBase
{
    [HttpGet("db")]
    public IActionResult Get([FromServices] IOptions<DatabaseOptions> dbOptions) => Ok(dbOptions);

    [HttpGet("rabbit")]
    public IActionResult Get([FromServices] IOptions<RabbitOptions> rabbitOptions) => Ok(rabbitOptions);

    [HttpGet("carrier")]
    public IActionResult Get([FromServices] IOptions<CarrierOptions> carrierOptions) => Ok(carrierOptions);
}

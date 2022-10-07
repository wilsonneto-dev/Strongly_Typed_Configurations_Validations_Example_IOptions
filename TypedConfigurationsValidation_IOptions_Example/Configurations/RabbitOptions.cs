using System.ComponentModel.DataAnnotations;

namespace TypedConfigurationsValidation_IOptions_Example.Configurations;

public class RabbitOptions
{
    public RabbitOptions() {}

    [Required(AllowEmptyStrings = false)]
    public string? Server { get; set; } = null;

    [Required(AllowEmptyStrings = false)]
    public string? Queue { get; set; } = null;

    [Required(AllowEmptyStrings = false)]
    public string? User { get; set; } = null;

    [Required(AllowEmptyStrings = false)]
    public string? Pass { get; set; } = null;
}

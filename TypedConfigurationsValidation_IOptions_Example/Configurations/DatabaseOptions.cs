using System.ComponentModel.DataAnnotations;

namespace TypedConfigurationsValidation_IOptions_Example.Configurations;

public class DatabaseOptions
{
    public DatabaseOptions() {}

    public string? User { get; set; } = null;

    public string? Pass { get; set; } = null;

    public string? DbName { get; set; } = null;

    public string? ServerUrl { get; set; } = null;
}    

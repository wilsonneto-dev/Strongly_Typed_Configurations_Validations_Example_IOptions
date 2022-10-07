using Microsoft.Extensions.Options;

namespace TypedConfigurationsValidation_IOptions_Example.Configurations;

public class DatabaseOptionsValidation : IValidateOptions<DatabaseOptions>
{
    public ValidateOptionsResult Validate(string name, DatabaseOptions options)
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(options.DbName))
            errors.Add("DbName not provided");
        if (string.IsNullOrWhiteSpace(options.Pass))
            errors.Add("Pass not provided");
        if (string.IsNullOrWhiteSpace(options.User))
            errors.Add("User not provided");

        if (errors.Any())
            return ValidateOptionsResult.Fail(errors);
 
        return ValidateOptionsResult.Success;
    }
}

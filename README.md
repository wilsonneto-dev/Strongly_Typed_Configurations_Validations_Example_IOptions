# Validating Strongly Typed Configurations (IOptions)

.Net 6 brings us some cool ways to validate the options, lazy or eager...
So, here are some examples on how to validate the strongly typed configuration

```csharp
// we can validate with data annotations
// the below validation will happens when we try to access it, not at startup
builder.Services.AddOptions<RabbitOptions>()
    .Bind(builder.Configuration.GetSection("Rabbit"))
    .ValidateDataAnnotations();

// we can use a method for the validation, this validation will happens when we try to access it
builder.Services.AddOptions<CarrierOptions>()
    .Bind(builder.Configuration.GetSection("Carrier"))
    .Validate(
        x => (!string.IsNullOrWhiteSpace(x.ApiUrl)) && (!string.IsNullOrWhiteSpace(x.Username)) && (!string.IsNullOrWhiteSpace(x.Pass)),
        "There are problems with your Carrier configurations, pls check it...");

// we also can validate using a OptionValidate class as below
// this validation will happens at the stratup time!
builder.Services.AddOptions<DatabaseOptions>()
    .Bind(builder.Configuration.GetSection("Database"))
    .ValidateOnStart();

builder.Services.AddSingleton<IValidateOptions<DatabaseOptions>, DatabaseOptionsValidation>();
```

Program file:

https://github.com/wilsonneto-dev/Strongly_Typed_Configurations_Validations_Example_IOptions/blob/master/TypedConfigurationsValidation_IOptions_Example/Program.cs

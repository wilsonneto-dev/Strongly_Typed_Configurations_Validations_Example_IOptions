using Microsoft.Extensions.Options;
using TypedConfigurationsValidation_IOptions_Example.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

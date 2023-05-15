using System;
using System.IO;
using System.Reflection;
using AzureCqrs.Api;
using AzureCqrs.Application;
using AzureCqrs.Infrastructure;
using AzureFunctions.Extensions.Swashbuckle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

[assembly: FunctionsStartup(typeof(Startup))]

namespace AzureCqrs.Api;

public class Startup : FunctionsStartup
{
    private const string FunctionKeyHeader = "x-function-key";

    public override void Configure(IFunctionsHostBuilder builder)
    {
        // Register the extension
        builder.AddSwashBuckle(Assembly.GetExecutingAssembly(), opts =>
        {
            // opts.ConfigureSwaggerGen = (options) =>
            // {
            //     options.IncludeXmlComments($"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
            //     // options.IncludeXmlComments($"{typeof(Application.StartupRegistrations).Assembly.GetName().Name}.xml");
            //     // options.AddSecurityDefinition("Function key", new OpenApiSecurityScheme
            //     // {
            //     //     Description = "Function key token",
            //     //     Type = SecuritySchemeType.ApiKey,
            //     //     In = ParameterLocation.Header,
            //     //     Name = FunctionKeyHeader,
            //     // });
            // };

            opts.AddCodeParameter = false;
        });

        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices();
    }
}
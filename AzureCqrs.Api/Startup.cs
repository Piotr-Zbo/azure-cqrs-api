using System.Reflection;
using AzureFunctions.Extensions.Swashbuckle;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(AzureCqrs.CommandApi.Startup))]

namespace AzureCqrs.CommandApi;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        // Register the extension
        builder.AddSwashBuckle(Assembly.GetExecutingAssembly(), opts =>
        {
            opts.XmlPath = "AzureCqrs.Api.xml";
            opts.AddCodeParameter = false;
        });
    }
}
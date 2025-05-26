namespace TaskTrain.Gateway;

internal static class ServerConfigure
{
    internal static void ConfigureServicesMap(this IApplicationBuilder builder, IConfiguration configuration)
    {
        var servicesMap = configuration
            .GetSection("ServicesMap")
            .GetChildren()
            .ToDictionary(x => x["Name"], y => y["Address"]);

    }
}

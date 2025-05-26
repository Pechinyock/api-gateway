namespace TaskTrain.Gateway;

internal static class AppConfigure
{
    internal static IConfigurationBuilder LoadEnvironmentVariables(this IConfigurationBuilder configBuilder) 
    {
        configBuilder.AddEnvironmentVariables("DOTNET_");
        configBuilder.AddEnvironmentVariables("ASPNETCORE_");
        return configBuilder;
    }

    internal static IConfigurationBuilder LoadAppsettingsJson(this IConfigurationBuilder configBuilder)
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        if (String.IsNullOrWhiteSpace(environmentName)) 
        {
            environmentName = "Production";
        }

        configBuilder.AddJsonFile($"Config/appsettings.{environmentName}.json");

        return configBuilder;
    }

    internal static IConfigurationBuilder LoadServicesMapJson(this IConfigurationBuilder configurationBuilder) 
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        if (String.IsNullOrWhiteSpace(environmentName))
        {
            environmentName = "Production";
        }
        configurationBuilder.AddJsonFile($"ServicesMap/services-map.{environmentName}.json");
        return configurationBuilder;
    }


}

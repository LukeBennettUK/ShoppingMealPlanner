using Microsoft.Extensions.Configuration;

namespace ShoppingMealPlanner.Configuration;

public static class ShoppingMealPlannerConfiguration
{
    public static IConfigurationBuilder AddShoppingMealPlannerConfig(this IConfigurationBuilder builder, string environmentName, string project)
    {
        return builder
            .AddJsonFile($"appsettings.{project}.json", false, true)
            .AddJsonFile($"appsettings.{project}.{environmentName}.json", true, true);
    }
    
    public static IConfigurationBuilder AddApplicationConfig(this IConfigurationBuilder builder, string environmentName)
    {
        return builder.AddShoppingMealPlannerConfig(environmentName, "application");
    }
    
    public static IConfigurationBuilder AddLocalConfig(this IConfigurationBuilder builder, string environmentName, bool optional = false)
    {
        return builder
            .AddJsonFile("appsettings.json", optional, true)
            .AddJsonFile($"appsettings.{environmentName}.json", true, true);
    }
}
using ShoppingMealPlanner.Configuration;

namespace ShoppingMealPlanner.Data.ExtensionMethods;

public static class Configuration
{
    public static IConfigurationBuilder AddDataConfig(this IConfigurationBuilder builder, string environmentName)
    {
        return builder.AddShoppingMealPlannerConfig(environmentName, "data");
    }
}
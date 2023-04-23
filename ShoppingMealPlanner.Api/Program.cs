using ShoppingMealPlanner.Data;
using Microsoft.EntityFrameworkCore;
using ShoppingMealPlanner.Configuration;
using ShoppingMealPlanner.Configuration.Models;
using ShoppingMealPlanner.Data.ExtensionMethods;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

// var webApplicationOptions = new WebApplicationOptions
// {
//     ContentRootPath = AppContext.BaseDirectory,
//     Args = args,
// };  

var builder = WebApplication.CreateBuilder();
    
// var builder = new ConfigurationBuilder()
//     .AddApplicationConfig(Environments.Development)
//     .AddLocalConfig(Environments.Development)
//     .AddDataConfig(Environments.Development);

builder.Configuration
    .SetBasePath(AppContext.BaseDirectory)
    .AddApplicationConfig(Environments.Development)
    .AddLocalConfig(Environments.Development)
    .AddDataConfig(Environments.Development);

// Each config is an api key for a specific service.
// What is the difference between each?
// AddApplicationConfig adds AddShoppingMealPlannerConfig(environmentName, "application");
    // so essentially:
    // .AddJsonFile($"appsettings.application.json", false, true)
    // .AddJsonFile($"appsettings.application.development/production.json", true, true);
// AddLocalConfig adds:
    // .AddJsonFile("appsettings.json", optional = false, true)
    // .AddJsonFile($"appsettings.development/production.json", true, true);
// AddDataConfig adds: AddShoppingMealPlannerConfig(environmentName, "data");
    // so essentially:
    // .AddJsonFile($"appsettings.data.json", false, true)
    // .AddJsonFile($"appsettings.data.development/production.json", true, true);

//Why can't I just do builder.AddShoppingMealPlannerConfig(environmentName, "application");
// 1. What does SetBasePath do?
// Sets the FileProvider for file-based providers to a PhysicalFileProvider with the base path.
// The base path is where the assembly is stored, which we get from: AppContext.BaseDirectory

// 2. sets FileProvider, what is this?
// ASP.NET Core abstracts file system access through the use of File Providers, so technically, just access to file system.

// 3. for file-based providers, what is a file-based provider?
// A file-based provider is a service that accesses files on the file system.

// 4. PhysicalFileProvider, what is this?
// PhysicalFileProvider is a file provider that accesses the file system directly.

// 5. What is the base path? Is that from the solution, or from my file system?
// builder.Configuration.SetBasePath(AppContext.BaseDirectory)
    // .AddApplicationConfig(builder.Environment.EnvironmentName)
    // .AddLocalConfig(builder.Environment.EnvironmentName)
    // .AddDataConfig(builder.Environment.EnvironmentName);

// builder.Configuration.AddJsonFile($"appsettings.development.json", false, true).AddJsonFile($"appsettings.development.{builder.Environment.EnvironmentName}.json", true, true);

// I think it is just a way of making it more readable, easier to understand, which ones do I need now then? 
// I think I currently only have a appsettings.data.development one that I'm using

// Why is dataconfig in a extension method within data, rather than within the main config itself?

// builder.Configuration.AddShoppingMealPlannerConfig(builder.Environment.EnvironmentName, "application");
// builder.Configuration.AddShoppingMealPlannerConfig(builder.Environment.EnvironmentName, "data");
// builder.Configuration.AddApplicationConfig(builder.Environment.EnvironmentName);

// Add services to the container.

// builder.Services.Configure()

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// So I think it needs the configuration files before it does this.
builder.Services.AddDbContext<ShoppingMealPlannerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins, policyBuilder =>
    {
        // can I access application config here?
        policyBuilder.WithOrigins("https://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
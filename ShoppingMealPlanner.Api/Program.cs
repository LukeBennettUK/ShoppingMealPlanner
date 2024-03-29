using ShoppingMealPlanner.Data;
using Microsoft.EntityFrameworkCore;
using ShoppingMealPlanner.Configuration;
using ShoppingMealPlanner.Configuration.Models;
using ShoppingMealPlanner.Data.ExtensionMethods;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder();

builder.Configuration
    .SetBasePath(AppContext.BaseDirectory)
    .AddApplicationConfig(Environments.Development)
    .AddLocalConfig(Environments.Development)
    .AddDataConfig(Environments.Development);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShoppingMealPlannerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins, policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:4200")
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
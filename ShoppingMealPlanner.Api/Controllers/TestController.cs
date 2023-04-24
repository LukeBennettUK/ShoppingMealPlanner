using Microsoft.AspNetCore.Mvc;
using ShoppingMealPlanner.Api.Models;

namespace ShoppingMealPlanner.Api.Controllers;

[Route("test")]
[ApiController]
public class TestController: Controller
{
    [HttpGet]
    public IActionResult MyIndex(int? id)
    {
        var model = new List<TestViewModel>
        {
            new TestViewModel()
            {
                Guid = Guid.NewGuid(),
                Title = "First post"
            },
            new TestViewModel()
            {
                Guid = Guid.NewGuid(),
                Title = "Second post"
            },
            new TestViewModel()
            {
                Guid = Guid.NewGuid(),
                Title = "Third post"
            }
        };
        
        return Ok(model);
    }
}
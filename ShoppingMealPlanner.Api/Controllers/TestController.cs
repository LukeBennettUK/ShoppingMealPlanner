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
        var model = new TestViewModel()
        {
            Test = "luke-test"
        };
        
        return Ok(model);
    }
}
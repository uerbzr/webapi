using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
       {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private static List<string> _items = new List<string>();

      
        [HttpGet]
        public async Task<IResult> GetToDoItems()
        {

            try
            {
                return Results.Ok(_items);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        [Route("")]
        [HttpPost]
        public async Task<IResult> AddToDoItem(string todoitem)
        {
            try
            {
                _items.Add(todoitem);
                return Results.Ok();                

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}

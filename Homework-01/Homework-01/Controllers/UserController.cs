using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
       public ActionResult<List<string>> GetAll()
        {

            return StatusCode(StatusCodes.Status200OK, StaticDb.Names);
        }
        [HttpGet("{index}")]
        public ActionResult<string> Get(int index)
        {
            try
            {
                if (index < 0) { return StatusCode(StatusCodes.Status400BadRequest, "index cant bew < of 0"); }

                if(index > StaticDb.Names.Count) { return StatusCode(StatusCodes.Status400BadRequest, $"There is no resource on index {index}"); }

                if(index is string ) { return StatusCode(StatusCodes.Status400BadRequest, "Index must be a number"); }

                return StatusCode(StatusCodes.Status200OK, StaticDb.Names[index]);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred.");
            }
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] string user)
        {
            try
            {
                if (string.IsNullOrEmpty(user))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "The body of the request is empty");
                }
                StaticDb.Names.Add(user);
                return StatusCode(StatusCodes.Status201Created, "New user was created");
            }
            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] string user) 
        {
          if (string.IsNullOrEmpty(user)) 
                {
                return StatusCode(StatusCodes.Status400BadRequest, "The body of the request is empty");
            }
            if (!StaticDb.Names.Contains(user))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "The User was not found");
            }
            StaticDb.Names.Remove(user);
            return StatusCode(StatusCodes.Status204NoContent, "TheUser Was removed");

        }
    }
}

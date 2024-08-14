using Homework_02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> GetAll()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, StaticDb.Books);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("index")]
        public ActionResult<Book> GetByIndex(int? index) 
        {
            try
            {
                if (index == null)
                {
                    StatusCode(StatusCodes.Status400BadRequest, "You need to enter index");
                }
                if(index  < 0)
                {
                    return BadRequest("The index can not be negative!");
                }
                if(index >= StaticDb.Books.Count)
                {
                    return NotFound($"There is no resource on index {index}");
                }
                return StatusCode(StatusCodes.Status200OK, StaticDb.Books[index.Value]);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }
        [HttpGet("multipleQueryParams")]
        public ActionResult<Book> FilterByMultipleParams([FromQuery]string? author,[FromQuery]string? title)
        {
            try
            {
                if (string.IsNullOrEmpty(author) && string.IsNullOrEmpty(title) )
                    {
                    return Ok(StaticDb.Books);
                }
                if (string.IsNullOrEmpty(author))
                {
                    List<Book> filterdBook = StaticDb.Books.Where(b => b.Title
                    .ToLower()
                    .Contains(title.ToLower())).ToList();

                    return Ok(filterdBook);
                }
                if (string.IsNullOrEmpty(title))
                {
                    List<Book> filterdTitle = StaticDb.Books.Where(b => b.Author
                    .ToLower()
                    .Contains(author.ToLower())).ToList();

                    return Ok(filterdTitle);
                }
                List<Book> bookDb = StaticDb.Books.Where(b => b.Author
                    .ToLower()
                    .Contains(author.ToLower()) && b.Title.ToLower().Contains(title.ToLower())).ToList();
                return Ok(bookDb);

            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateBook([FromBody]Book book) 
        {
            try
            {
                if (string.IsNullOrEmpty(book.Title))
                {
                    return BadRequest("Title can't be empty");
                }
                if (string.IsNullOrEmpty(book.Author))
                {
                    return BadRequest("Author can't be empty");
                }

                var existingBook = StaticDb.Books.FirstOrDefault(b => b.Title == book.Title && b.Author == book.Author);
                if (existingBook != null)
                {
                    return BadRequest("A book with the same title and author already exists.");
                }
                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created, "Book was created");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        
        }
        [HttpPost("CreateBooks")]
        public IActionResult CreateBooks([FromBody] List<Book> books)
        {
            try
            {
                if (books == null || books.Count == 0)
                {
                    return BadRequest("The book list can't be empty");
                }

                var bookTitles = new List<string>();

                foreach (var book in books)
                {
                    if (string.IsNullOrEmpty(book.Title))
                    {
                        return BadRequest("Title can't be empty");
                    }
                    if (string.IsNullOrEmpty(book.Author))
                    {
                        return BadRequest("Author can't be empty");
                    }

                   
                    var existingBook = StaticDb.Books.FirstOrDefault(b => b.Title == book.Title && b.Author == book.Author);
                    if (existingBook != null)
                    {
                        return Conflict($"A book with the title '{book.Title}' and author '{book.Author}' already exists");
                    }

                    StaticDb.Books.Add(book);
                    bookTitles.Add("Titl" +" "+ book.Title +", "+ "Author" +" "+ book.Author);
                }

                return Ok(bookTitles);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}

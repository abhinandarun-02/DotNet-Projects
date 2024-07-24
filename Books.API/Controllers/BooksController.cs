using Books.API.Repository;
using Microsoft.AspNetCore.Mvc;
using Books.API.Models;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _bookRepository.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(Guid id)
        {
            var book = _bookRepository.GetBookById(id);

            if (book == null)
            {
                return NotFound($"Book with id = {id} is not found");
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            var addedBook = _bookRepository.AddBook(book);
            return Ok(addedBook);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook([FromRoute] Guid id, [FromBody] Book book)
        {
            var updatedBook = _bookRepository.UpdateBook(id, book);

            if (updatedBook == null)
            {
                return NotFound($"Book with id = {id} is not found");
            }
            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook([FromRoute] Guid id)
        {
            var isDeleted = _bookRepository.DeleteBook(id);

            if (!isDeleted)
            {
                return NotFound($"Book with id = {id} is not found");
            }
            return Ok("Book deleted successfully");
        }

        [HttpGet("costliest")]
        public IActionResult GetCostliestBook()
        {
            var costliestBook = _bookRepository.getCostliestBook();
            return Ok(costliestBook);
        }

        [HttpGet("costliestAndCheapest")]
        public IActionResult GetCostliestAndCheapestBook()
        {
            var costliestBook = _bookRepository.getCostliestBook();
            var cheapestBook = _bookRepository.getCheapestBook();

            var costliestAndCheapest = new
            {
                CostliestBook = costliestBook,
                CheapestBook = cheapestBook
            };
            return Ok(costliestAndCheapest);
        }

        [HttpGet("namestartswitha")]
        public IActionResult GetBooksNameStartsWithA()
        {
            var books = _bookRepository.GetBooksNameStartsWithA();
            return Ok(books);
        }

        [HttpDelete]
        public IActionResult DeleteAllBooks()
        {
            _bookRepository.DeleteAllBooks();
            return Ok("All books deleted successfully");
        }

        [HttpGet("amountbetweenmaxmin")]
        public IActionResult GetBooksAmountBetweenMaxMin([FromQuery] int min, [FromQuery] int max)
        {
            if (min > max)
                return BadRequest("Min amount should be less than max amount"
            );
            var books = _bookRepository.GetBooksAmountBetweenMaxMin(min, max);
            return Ok(books);
        }
    }
}

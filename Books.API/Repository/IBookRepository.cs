using Books.API.Models;

namespace Books.API.Repository
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetAllBooks();

        public Book GetBookById(Guid id);

        public Book AddBook(Book customer);

        public Book UpdateBook(Guid id, Book customer);

        public bool DeleteBook(Guid id);

        public Book getCostliestBook();

        public Book getCheapestBook();

        public IEnumerable<Book> GetBooksNameStartsWithA();

        public bool DeleteAllBooks();

        public IEnumerable<Book> GetBooksAmountBetweenMaxMin(int min, int max);
    }
}

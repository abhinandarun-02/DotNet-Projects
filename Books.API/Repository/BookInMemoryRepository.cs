using Books.API.Models;

namespace Books.API.Repository
{
    public class BookInMemoryRepository : IBookRepository
    {
        private List<Book> _bookList = new List<Book>();

        public BookInMemoryRepository()
        {
            _bookList.Add(new Book { Name = "To Kill a Mockingbird", Description = "None", Amount = 700, Author = "Harper Lee" });
            _bookList.Add(new Book { Name = "1984", Description = "None", Amount = 800, Author = "George Orwell" });
            _bookList.Add(new Book { Name = "A Catcher in the Rye", Description = "None", Amount = 1200, Author = "J.D. Salinger" });
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return _bookList;
        }

        public Book GetBookById(Guid id)
        {
            var book = _bookList.FirstOrDefault(b => b.Id == id);
            return book;
        }

        public Book AddBook(Book book)
        {
            _bookList.Add(book);
            return book;
        }

        public Book UpdateBook(Guid id, Book book)
        {
            var existingBook = _bookList.FirstOrDefault(c => c.Id == id);
            if (existingBook != null)
            {
                existingBook.Name = book.Name;
                existingBook.Description = book.Description;
                existingBook.Amount = book.Amount;
                existingBook.Author = book.Author;
            }
            return existingBook;
        }

        public bool DeleteBook(Guid id)
        {
            var existingBook = _bookList.FirstOrDefault(c => c.Id == id);

            if (existingBook != null)
            {
                _bookList.Remove(existingBook);
                return true;
            }
            return false;
        }

        public Book getCostliestBook()
        {
            if (_bookList == null || _bookList.Count == 0)
            {
                return null;
            }

            Book costliestBook = _bookList[0];
            foreach (var book in _bookList)
            {
                if (book.Amount > costliestBook.Amount)
                {
                    costliestBook = book;
                }
            }
            return costliestBook;
        }

        public Book getCheapestBook()
        {
            if (_bookList == null || _bookList.Count == 0)
            {
                return null;
            }

            Book cheapestBook = _bookList[0];
            foreach (var book in _bookList)
            {
                if (book.Amount < cheapestBook.Amount)
                {
                    cheapestBook = book;
                }
            }
            return cheapestBook;
        }

        public IEnumerable<Book> GetBooksNameStartsWithA()
        {
            return _bookList.Where(b => b.Name.ToUpper().StartsWith("A"));
        }

        public bool DeleteAllBooks()
        {
            _bookList.Clear();
            return true;
        }

        public IEnumerable<Book> GetBooksAmountBetweenMaxMin(int min, int max)
        {
            return _bookList.Where(b => b.Amount >= min && b.Amount <= max);
        }
    }
}

namespace OBG1
{
    public class BooksRepository
    {
        private int _nextId = 1;
        private readonly List<Book> _books = new();

        public BooksRepository()
        {
            _books.Add(new Book() { Id = _nextId++, Title = "Harryspot", Price = 1000 });
            _books.Add(new Book() { Id = _nextId++, Title = "AlpsBooks", Price = 499 });
            _books.Add(new Book() { Id = _nextId++, Title = "AquaDors", Price = 399 });
            _books.Add(new Book() { Id = _nextId++, Title = "MacBooks", Price = 599 });
            _books.Add(new Book() { Id = _nextId++, Title = "Fifa101", Price = 99 });
        }
        public IEnumerable<Book> Get(string? title = null, double? price = null, string? orderBy = null)
        {
            IEnumerable<Book> result = new List<Book>(_books);

            // Filtering
            if (title != null)
            {
                result = result.Where(book => book.Title.Contains(title));
            }
            if (price != null)
            {
                result = result.Where(book => book.Price >= price);
            }

            // Ordering
            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "title":
                    case "title_asc":
                        result = result.OrderBy(book => book.Title);
                        break;
                    case "title_desc":
                        result = result.OrderByDescending(book => book.Title);
                        break;
                    case "price":
                    case "price_asc":
                        result = result.OrderBy(book => book.Price);
                        break;
                    case "price_desc":
                        result = result.OrderByDescending(book => book.Price);
                        break;
                    default:
                        return result;
                }
            }

            return result;
        }
        public List<Book> GetAllBook()
        {
            return _books;
        }

        public Book? GetById(int Id)
        {
            return _books.Find(book => book.Id == Id);
        }

        public Book Add(Book book)
        {
            book.Validate();
            book.Id = _nextId++;
            _books.Add(book);
            return book;
        }
        public Book? Remove(int id)
        {
            Book? book = GetById(id);
            if (book == null)
            {
                return null;
            }
            _books.Remove(book);
            return book;
        }

        public Book? update(int id, Book book)
        {
            book.Validate();
            Book? existingbook = GetById(id);
            if (existingbook == null)
            {
                return null;
            }
            existingbook.Title = book.Title;
            existingbook.Price = book.Price;
            return existingbook;
        }
    }
}

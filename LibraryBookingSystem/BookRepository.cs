namespace LibraryBookingSystem
{
    public class BookRepository : IRepository<Book>
    {
        private List<Book> _books = new();
        public void Add(Book book)
        {
            _books.Add(book);
        }

        public void Delete(Book book)
        {
            _books.Remove(book);
        }

        public bool Exists(int id)
        {
            return _books
                .Where(b => b.Id == id)
                .Any();
        }

        public Book? Get(int id)
        {
            return _books
                .Where(b => b.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Book> GetAll()
        {
            return _books
                .ToList();
        }

        public void Update(Book book)
        {
            Delete(Get(book.Id));
            Add(book);
        }
    }
}

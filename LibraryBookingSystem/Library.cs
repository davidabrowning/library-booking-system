namespace LibraryBookingSystem
{
    public class Library
    {
        private List<Book> _books = new();
        public List<Book> Books { get { return _books.ToList(); } }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public Book FindBookByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public void LoanBook(string isbn)
        {
            throw new NotImplementedException();
        }

        public void ReturnBook(string isbn)
        {
            throw new NotImplementedException();
        }
    }
}

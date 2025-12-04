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
            Book? foundBook = _books.Where(b => b.Title.ToLower() == title.ToLower()).FirstOrDefault();
            if (foundBook == null)
                throw new InvalidOperationException();
            return foundBook;
        }

        public Book LoanBook(string isbn)
        {
            Book? loanedBook = _books
                .Where(b => b.ISBN == isbn)
                .Where(b => b.IsLoaned == false)
                .FirstOrDefault();
            if (loanedBook == null)
                throw new InvalidOperationException();
            loanedBook.Loan();
            return loanedBook;
        }

        public void ReturnBook(string isbn)
        {
            throw new NotImplementedException();
        }
    }
}

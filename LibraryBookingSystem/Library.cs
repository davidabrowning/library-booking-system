namespace LibraryBookingSystem
{
    public class Library
    {
        private IRepository<Book> _bookRepository;
        public IEnumerable<Book> Books { get { return _bookRepository.GetAll(); } }

        public Library(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void AddBook(Book book)
        {
            _bookRepository.Add(book);
        }

        public Book FindBookByTitle(string title)
        {
            Book? foundBook = Books.Where(b => b.Title.ToLower() == title.ToLower()).FirstOrDefault();
            if (foundBook == null)
                throw new InvalidOperationException();
            return foundBook;
        }

        public Book LoanBook(string isbn)
        {
            Book? loanedBook = Books
                .Where(b => b.ISBN == isbn)
                .Where(b => b.IsLoaned == false)
                .FirstOrDefault();
            if (loanedBook == null)
                throw new InvalidOperationException();
            loanedBook.Loan();
            return loanedBook;
        }
    }
}

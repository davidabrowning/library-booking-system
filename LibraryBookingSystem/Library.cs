namespace LibraryBookingSystem
{
    public class Library
    {
        private List<Book> _books = new();
        public List<Book> Books { get { return _books.ToList(); } }
    }
}

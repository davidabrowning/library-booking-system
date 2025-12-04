namespace LibraryBookingSystem
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsLoaned { get; set; }
        public void Loan()
        {
            if (IsLoaned)
                throw new InvalidOperationException();
            IsLoaned = true;
        }
        public void Return()
        {
            if (!IsLoaned)
                throw new InvalidOperationException();
            IsLoaned = false;
        }
    }
}

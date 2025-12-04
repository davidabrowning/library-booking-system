using LibraryBookingSystem;

namespace LibraryBookingSystemTests
{
    public class LibraryTests
    {
        [Fact]
        public void BookCount_IncreasesByOne_AfterAddingBook()
        {
            // Arrange
            Library library = new();
            int initialBookCount = library.Books.Count;

            // Act
            library.AddBook(new Book());

            // Assert
            Assert.Equal(initialBookCount + 1, library.Books.Count);
        }

        [Fact]
        public void FindBookByTitle_ReturnsCorrectBook()
        {
            // Arrange
            Library library = new();
            Book uploadedBook1 = new Book() { Title = "Stora boken om katter", ISBN = "883339111" };
            Book uploadedBook2 = new Book() { Title = "Stora boken om barn", ISBN = "8880001234" };
            Book uploadedBook3 = new Book() { Title = "Stora boken om böcker", ISBN = "1133333322" };
            library.AddBook(uploadedBook1);
            library.AddBook(uploadedBook2);
            library.AddBook(uploadedBook3);

            // Act
            Book returnedBook = library.FindBookByTitle("stora boken om barn");

            // Assert
            Assert.Equal(uploadedBook2.ISBN, returnedBook.ISBN);
        }
    }
}

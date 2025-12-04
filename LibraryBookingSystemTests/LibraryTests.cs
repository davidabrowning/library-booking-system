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
    }
}

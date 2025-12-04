using LibraryBookingSystem;

namespace LibraryBookingSystemTests
{
    public class LibraryTests
    {
        [Fact]
        public void BookCount_IncreasesByOne_AfterAddingBook()
        {
            // Arrange
            Library library = new(new BookRepository());
            int initialBookCount = library.Books.ToList().Count;

            // Act
            library.AddBook(new Book());

            // Assert
            Assert.Equal(initialBookCount + 1, library.Books.ToList().Count);
        }

        [Fact]
        public void FindBookByTitle_ReturnsCorrectBook()
        {
            // Arrange
            Library library = new(new BookRepository());
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

        [Fact]
        public void FindBookByTitle_ThrowsException_IfBookNotFound()
        {
            // Arrange
            Library library = new(new BookRepository());

            // Act and assert
            Assert.ThrowsAny<Exception>(() => library.FindBookByTitle("stora boken om barn"));
        }

        [Fact]
        public void LoanBook_ReturnsALoanedBook()
        {
            // Arrange
            Library library = new(new BookRepository());
            Book book = new() { Title = "Joy at Work", ISBN = "11993322" };
            library.AddBook(book);

            // Act
            Book loanedBook = library.LoanBook(book.ISBN);

            // Assert
            Assert.True(loanedBook.IsLoaned);
        }

        [Fact]
        public void LoanBook_IncreasedNumberOfLoanedBooksByOne()
        {
            // Arrange
            Library library = new(new BookRepository());
            Book book1 = new() { ISBN = "123" };
            Book book2 = new() { ISBN = "456" };
            library.AddBook(book1);
            library.AddBook(book2);
            int initialLoanedBookCount = library.Books.Where(b => b.IsLoaned == true).Count();

            // Act
            library.LoanBook(book1.ISBN);
            int finalLoanedBookCount = library.Books.Where(b => b.IsLoaned == true).Count();

            // Assert
            Assert.Equal(initialLoanedBookCount + 1, finalLoanedBookCount);
        }

        [Fact]
        public void LoanBook_ThrowsException_IfOnlyMatchingBookIsAlreadyLoaned()
        {
            // Arrange
            Library library = new(new BookRepository());
            Book book = new() { ISBN = "123" };
            library.AddBook(book);
            library.LoanBook(book.ISBN);

            // Act and assert
            Assert.ThrowsAny<Exception>(() => library.LoanBook(book.ISBN));
        }

        [Fact]
        public void LoanBook_CanLoanThreeTimes_IfThreeCopiesOfSameISBNExist()
        {
            // Arrange
            Library library = new(new BookRepository());
            Book targetBook = new() { ISBN = "123" };
            Book extraCopy1 = new() { ISBN = "123" };
            Book extraCopy2 = new() { ISBN = "123" };
            library.AddBook(targetBook);
            library.AddBook(extraCopy1);
            library.AddBook(extraCopy2);

            // Act
            library.LoanBook(targetBook.ISBN);
            library.LoanBook(targetBook.ISBN);
            var finalResult = library.LoanBook(targetBook.ISBN);

            // Assert
            Assert.IsType<Book>(finalResult);
        }
    }
}

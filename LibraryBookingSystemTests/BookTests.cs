using LibraryBookingSystem;

namespace LibraryBookingSystemTests
{
    public class BookTests
    {
        [Fact]
        public void IsLoaned_IsFalse_Initially()
        {
            // Arrange
            Book book = new();

            // Assert
            Assert.False(book.IsLoaned);
        }

        [Fact]
        public void IsLoaned_IsTrue_AfterLoan()
        {
            // Arrange
            Book book = new();

            // Act
            book.Loan();

            // Assert
            Assert.True(book.IsLoaned);
        }

        [Fact]
        public void Loan_ThrowsException_IfBookIsAlreadyLoaned()
        {
            // Arrange
            Book book = new();

            // Act
            book.Loan();

            // Assert
            Assert.ThrowsAny<Exception>(() => book.Loan());
        }
    }
}

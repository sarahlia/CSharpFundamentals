using System;
using Xunit;

namespace Fundamentals_PS.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new Book("scores");
            book.AddGrade(80);
            book.AddGrade(100);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(90.0, result.Average, 1);

        }
    }
}

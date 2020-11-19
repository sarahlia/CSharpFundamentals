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
            book.AddGrade(85.7);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(84.5, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
        }
    }
}

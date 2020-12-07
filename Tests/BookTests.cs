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
            var book = new InMemoryBook("scores");
            book.AddGrade(80);
            book.AddGrade(100);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(90.0, result.Average, 1);
            Assert.Equal(80, result.Low);
            Assert.Equal(100, result.High);
            Assert.Equal('A', result.Letter);
        }
    }
}

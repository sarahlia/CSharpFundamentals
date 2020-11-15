using System;
using System.Collections.Generic;

namespace Fundamentals_PS
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Sarah's Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);
            book.ShowStatistics();
        }
    }
}

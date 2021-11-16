using System;
using System.Collections.Generic;

namespace Fundamentals_PS
{
    class Program
    {
        static void Main(string[] args)
        {
            // DiskBook diskBook = new DiskBook("sa");
            // diskBook.btnStart_Click();
            
            if (args.Length > 0)
            {
                Console.WriteLine($"Hello {args[0]}!");
            }
            Console.WriteLine("Hello.");
            
            // var numbers = new[] { 12.7, 10.3, 6.11, 4.1 };
            //
            // var total = 0.0;
            // foreach (var number in numbers)
            // {
            //     total += number;
            // }
            // Console.WriteLine($"The total is {total}");

            // var grades = new List<double>
            // {
            //     12.7,
            //     10.3,
            //     6.11,
            //     4.1,
            //     56.1
            // };
            //
            // var result = 0.0;
            // foreach (var grade in grades)
            // {
            //     result += grade;
            // }
            // result /= grades.Count;
            // Console.WriteLine($"The average is {result:N3}");
            
            // IBook book = new DiskBook("Sarah's Grade Book");
            // Console.WriteLine(book.Name);
            
            Book book = new InMemoryBook("Sample Book");

            EnterGrades(book);

            var stats = book.GetStatistics();
            book.Name = "November Book";

            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"the category is {InMemoryBook.CATEGORY}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The average grade is {stats.Average:N2}");
            Console.WriteLine($"Your letter grade is {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit:");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                    // book.AddGrade('A');
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }

            }
        }
    }
}

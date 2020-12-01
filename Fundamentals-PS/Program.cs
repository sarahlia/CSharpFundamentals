using System;
using System.Collections.Generic;

namespace Fundamentals_PS
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Sarah's Grade Book");
            Console.WriteLine(book.Name);
                    
            while(true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit:");
                var input = Console.ReadLine();

                if(input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }

                
            }

            var stats = book.GetStatistics();

            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The average grade is {stats.Average:N2}");
            Console.WriteLine($"Your letter grade is {stats.Letter}");
        }
    }
}

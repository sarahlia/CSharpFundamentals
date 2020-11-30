using System;
using System.Collections.Generic;

namespace Fundamentals_PS
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddLetterGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);   
            }
            else
            {
                Console.WriteLine("Invalid Value");
            }
            
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            result.Total = 0.0;
            result.Average = 0.0;

            foreach (var grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Total += grade;
            }

            result.Average = result.Total / grades.Count;

            switch(result.Average)
            {
                case var mark when mark >= 90.0:
                    result.Letter = 'A';
                    break;

                case var mark when mark >= 80.0:
                    result.Letter = 'B';
                    break;

                case var mark when mark >= 70.0:
                    result.Letter = 'C';
                    break;

                case var mark when mark >= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;
            }
            return result;


        }

        static private List<double> grades;
        public string Name;
    }
}

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
                result.Average = result.Total / grades.Count;
            }

            return result;
        }

        static private List<double> grades;
        public string Name;
    }
}

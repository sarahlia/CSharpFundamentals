using System;
using System.Collections.Generic;
using System.IO;

namespace Fundamentals_PS
{
    //public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        //event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        //public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public class DiskBook : Book
    {
        string result;

        public async void btnStart_Click()
        {
            await SaySomething(); //if the 'await' is OMITTED, the output would be an empty line. Otherwise if it's as written here, "Hello world" will appear after 1000 ms.
            string txtSomeTextBlock;
            txtSomeTextBlock = result;
            Console.WriteLine(txtSomeTextBlock);
        }

        async System.Threading.Tasks.Task<string> SaySomething()
        {
            await System.Threading.Tasks.Task.Delay(1000); 

            result = "Hello world!";
            return result;
        }
        public DiskBook(string name) : base(name)
        {
        }

        //public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);

                //if(GradeAdded != null)
                //{
                //    GradeAdded(this, new EventArgs());
                //}
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();

                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }
    
    

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }
        
        // overloading
        public void AddGrade(char letter)
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
        
        public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);   
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
            
        }

        //public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
           
            foreach (var grade in grades)
            {
                result.Add(grade);
            }
            
            return result;
        }

        static private List<double> grades;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    name = value; 
                }
            }
        }
        
        private string name;

        //public const string CATEGORY = "Science";
    }
}

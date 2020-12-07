using System;

namespace Fundamentals_PS
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Total / Count;
            }
        }
        public double Total;
        public double High;
        public double Low;

        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var mark when mark >= 90.0:
                        return 'A';

                    case var mark when mark >= 80.0:
                        return 'B';

                    case var mark when mark >= 70.0:
                        return 'C';

                    case var mark when mark >= 60.0:
                        return 'D';

                    default:
                        return 'F';
                }
            }
        }

        public int Count;

        public void Add(double number)
        {
            Total += number;
            Count += 1;

            High = Math.Max(number, High);
            Low = Math.Min(number, Low);
        }

        public Statistics()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            Total = 0.0;
            Count = 0;
        }
    }
}

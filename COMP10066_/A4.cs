using System;
using System.Collections.Generic;

namespace COMP10066_Lab4
{
    /**
     * Library of statistical functions using Generics for different statistical
     * calculations.
     * 
     * see http://www.calculator.net/standard-deviation-calculator.html
     * for sample standard deviation calculations
     *
     * @author Joey Programmer
     */

    public class A4
    {
        public static double Avg(List<double> x, bool incneg)
        {
            double s = Sum(x, incneg);
            int c = 0;
            for (int i = 0; i < x.Count; i++)
            {
                if (incneg || x[i] >= 0)
                {
                    c++;
                }
            }
            if (c == 0)
            {
                throw new ArgumentException("no values are > 0");
            }
            return s / c;
        }

        public static double Sum(List<double> x, bool incneg)
        {
            if (x.Count < 0)
            {
                throw new ArgumentException("x cannot be empty");
            }

            double sum = 0.0;
            foreach (double val in x)
            {
                if (incneg || val >= 0)
                {
                    sum += val;
                }
            }
            return sum;
        }

        public static double Median(List<double> data)
        {
            if (data.Count == 0)
            {
                throw new ArgumentException("Size of array must be greater than 0");
            }

            data.Sort();

            double median = data[data.Count / 2];
            if (data.Count % 2 == 0)
                median = (data[data.Count / 2] + data[data.Count / 2 - 1]) / 2;

            return median;
        }

        public static double SD(List<double> data)
        {
            if (data.Count <= 1)
            {
                throw new ArgumentException("Size of array must be greater than 1");
            }

            int n = data.Count;
            double s = 0;
            double a = Avg(data, true);

            for (int i = 0; i < n; i++)
            {
                double v = data[i];
                s += Math.Pow(v - a, 2);
            }
            double stdev = Math.Sqrt(s / (n - 1));
            return stdev;
        }

        // Simple set of tests that confirm that functions operate correctly
        static void Main(string[] args)
        {
            List<Double> testDataD = new List<Double> { 2.2, 3.3, 66.2, 17.5, 30.2, 31.1 };

            Console.WriteLine("The sum of the array = {0}", Sum(testDataD, true));

            Console.WriteLine("The average of the array = {0}", Avg(testDataD, true));

            Console.WriteLine("The median value of the Double data set = {0}", Median(testDataD));

            Console.WriteLine("The sample standard deviation of the Double test set = {0}\n", SD(testDataD));
        }
    }
}

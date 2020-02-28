
/*
 * Rules Applied:
 * 1. PascalCasing for method names
 * 2. camelCasing for method arguments
 * 3. PascalCasing for abbreviations
 * 4. Vertically aligned curly brackets
 */
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
     * @author Hary Ajay 000741446
     * I, Hary Ajay, student number 000741446, certify that all code submitted is my own work; that I have not copied it from any other source. 
     * I also certify that I have not allowed my work to be copied by others.
     */

    public class A4
    {   /// <summary>
        /// This method returns the average of all
        /// elements in the array
        /// </summary>
        /// <param name="dataList"></param>
        /// <returns>average of the array</returns>
        public static double Average(List<double> dataList)
        {
            // This variable holds the sum of the array
            // by calling the Sum method
            double arraySum = Sum(dataList);
            // This variable holds the count of non negative
            // Double inetegers in the array
            int count = 0;
            // This loop counts the number of non negative
            // double integers in the list
            for (int i = 0; i < dataList.Count; i++)
            {
                if (dataList[i] >= 0)
                {
                    count++;
                }
            }
            // If the count of non negative double integers
            // is zero. Then throw an exception.
            if (count == 0)
            {
                throw new ArgumentException("No values are > 0");
            }
            // Otherwise return the average as sum/count
            return arraySum / count;
        }
        /// <summary>
        /// This method returns the sum of all
        /// elements in the array
        /// </summary>
        /// <param name="dataList"></param>
        /// <returns>Sum of all elements in the array</returns>
        public static double Sum(List<double> dataList)
        {
            // If the array has no values in it, throw an
            // empty exception
            if (dataList.Count < 0)
            {
                throw new ArgumentException("Data List cannot be empty");
            }
            // Otherwise create an arrya sum variable
            double arraySum = 0.0;
            // Loop over the array and sum all positive values in it
            foreach (double value in dataList)
            {
                if (value >= 0)
                {
                    arraySum += value;
                }
            }
            // Return array sum
            return arraySum;
        }
        /// <summary>
        /// This method returns the Median of all
        /// elements in the array
        /// </summary>
        /// <param name="dataList"></param>
        /// <returns>Median of the array</returns>
        public static double Median(List<double> dataList)
        {
            // If the array has no values in it, throw an
            // empty exception
            if (dataList.Count == 0)
            {
                throw new ArgumentException("Size of the Data List must be greater than 0");
            }
            // Othereise, sort the array
            dataList.Sort();
            // COmpute the median element at the middle of the array
            double median = dataList[dataList.Count / 2];
            // If the array is even in length then get mean of the two
            // values at the middle
            if (dataList.Count % 2 == 0)
                median = (dataList[dataList.Count / 2] + dataList[dataList.Count / 2 - 1]) / 2;
            // return the median
            return median;
        }
        /// <summary>
        /// This method returns the Standard Deviation of all
        /// elements in the array
        /// </summary>
        /// <param name="dataList"></param>
        /// <returns>Standard Deviation of the array</returns>
        public static double StandardDeviation(List<double> dataList)
        {
            // If the array has less than 2 elements, throw and exception
            if (dataList.Count <= 1)
            {
                throw new ArgumentException("Size of the Data List must be greater than 1");
            }
            // Otherwise, compute the standard deviation of the array
            int size = dataList.Count;
            double sum = 0;
            double average = Average(dataList);

            for (int i = 0; i < size; i++)
            {
                double value = dataList[i];

                sum += Math.Pow(value - average, 2);
            }
            // Computing and Returning the standard deviation
            double stDev = Math.Sqrt(sum / (size - 1));
            return stDev;
        }

        /// <summary>
        /// The main method, creates a double array of integers
        /// and tests the above methods by calling them and printing
        /// the results
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Create a list of double integers
            List<double> testDataD = new List<Double> { 2.2, 3.3, 66.2, 17.5, 30.2, 31.1 };

            // Testing the sum method
            Console.WriteLine("The sum of the array = {0}", Sum(testDataD));
            // Testing the average method
            Console.WriteLine("The average of the array = {0}", Average(testDataD));
            // Testing the median method
            Console.WriteLine("The median value of the Double data set = {0}", Median(testDataD));
            // Testing the standard deviation method
            Console.WriteLine("The sample standard deviation of the Double test set = {0}\n", StandardDeviation(testDataD));
        }
    }
}

using System;

namespace SP500Simulator
{
    public class Program
    {
        const int MinimumYear = 1928;
        const int MaximumYear = 2019;
        static readonly double[] SP500HistoricalAnnualReturns = { 37.88, -11.91, -28.48, -47.07, -15.15, 46.59, -5.94, 41.37, 27.92, -38.59, 25.21, -5.45, -15.29, -17.86, 12.43, 19.45, 13.8, 30.72, -11.87, 0, -0.65, 10.26, 21.78, 16.46, 11.78, -6.62, 45.02, 26.4, 2.62, -14.31, 38.06, 8.48, -2.97, 23.13, -11.81, 18.89, 12.97, 9.06, -13.09, 20.09, 7.66, -11.36, 0.1, 10.79, 15.63, -17.37, -29.72, 31.55, 19.15, -11.5, 1.06, 12.31, 25.77, -9.73, 14.76, 17.27, 1.4, 26.33, 14.62, 2.03, 12.4, 27.25, -6.56, 26.31, 4.46, 7.06, -1.54, 34.11, 20.26, 31.01, 26.67, 19.53, -10.14, -13.04, -23.37, 26.38, 8.99, 3, 13.62, 3.53, -38.49, 23.45, 12.78, 0, 13.41, 29.6, 11.39, -0.73, 9.54, 19.42, -6.24, 28.88 };

        public static void Main(string[] args)
        {
            var initialCapital = PromptCapital("Initial investment capital:");
            var annualInvestment = PromptCapital("Annual investment capital:");            
            var startYear = PromptYear("Initial investment year: ");
            var endYear = PromptYear("Final investment year: ");

            var indexStart = startYear - MinimumYear;
            var indexEnd = endYear - MinimumYear;
            
            var currentCapital = initialCapital;
            var totalInvestment = initialCapital;

            for(var i = indexStart; i <= indexEnd; i++)
            {
                var anualReturn = SP500HistoricalAnnualReturns[i];
                totalInvestment += annualInvestment;
                currentCapital = CalculateYearReturn(currentCapital + annualInvestment, anualReturn);
                
                if (currentCapital <= 0)
                {
                    Console.WriteLine($"Final reached 0 in {startYear + i}");
                    return;
                }
            }

            var totalGain = currentCapital - totalInvestment;

            Console.WriteLine();
            Console.WriteLine($"Total investment is ${totalInvestment}.");
            Console.WriteLine($"Final capital is ${currentCapital} in {indexEnd - indexStart} years.");            
            Console.WriteLine($"Total gain is ${totalGain}, {totalGain / totalInvestment * 100}% of total investment.");
        }

        private static double CalculateYearReturn(double capital, double annualReturn)
        {
            var gain = capital * (annualReturn / 100);
            return capital + gain;
        }

        private static int PromptYear(string prompt)
        {
            int? year = null;
            Console.WriteLine(prompt);

            do
            {                
                var line = Console.ReadLine();
                int.TryParse(line,  out var value);
                
                if (value >=  MinimumYear && value <= MaximumYear)
                {
                    year = value;
                }
                else
                {
                    Console.WriteLine($"Year value must be between {MinimumYear} and {MaximumYear}.");
                }
            } while (year == null);

            return year.Value;
        }

        private static double PromptCapital(string prompt)
        {
            double? capital = null;
            Console.WriteLine(prompt);

            do
            {
                var line = Console.ReadLine();
                double.TryParse(line, out var value);

                if (value >= 0)
                {
                    capital = value;
                }
                else
                {
                    Console.WriteLine($"Capital must be positive.");
                }
            } while (capital == null);

            return capital.Value;
        }
    }
}

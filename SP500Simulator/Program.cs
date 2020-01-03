using System;
using System.Collections.Generic;

namespace SP500Simulator
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Choose Index \n S&P 500 (SP)\n DJIA (DJ)");
            var chooseIndex = Console.ReadLine().ToUpper();
            if (chooseIndex != "SP" && chooseIndex != "DJ")
            {
                do
                {
                    Console.WriteLine("Index must be (SP) or (DJ)");
                    Console.WriteLine("Choose Index \n S&P 500 (SP)\n DJIA (DJ)");
                    chooseIndex = Console.ReadLine().ToUpper();
                } while (chooseIndex != "SP" && chooseIndex != "DJ");
            }
            if (chooseIndex == "SP")
            {
                Index sp500 = new Index();
                sp500.MinimumYear = 1928;
                sp500.MaximumYear = 2019;
                sp500.Historical = new double[] { 37.88, -11.91, -28.48, -47.07, -15.15, 46.59, -5.94, 41.37, 27.92, -38.59, 25.21, -5.45, -15.29, -17.86, 12.43, 19.45, 13.8, 30.72, -11.87, 0, -0.65, 10.26, 21.78, 16.46, 11.78, -6.62, 45.02, 26.4, 2.62, -14.31, 38.06, 8.48, -2.97, 23.13, -11.81, 18.89, 12.97, 9.06, -13.09, 20.09, 7.66, -11.36, 0.1, 10.79, 15.63, -17.37, -29.72, 31.55, 19.15, -11.5, 1.06, 12.31, 25.77, -9.73, 14.76, 17.27, 1.4, 26.33, 14.62, 2.03, 12.4, 27.25, -6.56, 26.31, 4.46, 7.06, -1.54, 34.11, 20.26, 31.01, 26.67, 19.53, -10.14, -13.04, -23.37, 26.38, 8.99, 3, 13.62, 3.53, -38.49, 23.45, 12.78, 0, 13.41, 29.6, 11.39, -0.73, 9.54, 19.42, -6.24, 28.88 };
                Console.WriteLine("Index Fund : SP500");
                Console.WriteLine("Initial Capital: ");
                var initialcap = int.Parse(Console.ReadLine());
                Console.WriteLine("Annual Investment: ");
                var annualInvest = int.Parse(Console.ReadLine());
                Console.WriteLine("Start Year: ");
                var startY = int.Parse(Console.ReadLine());
                Console.WriteLine("End Year: ");
                var endY = int.Parse(Console.ReadLine());
                var sp500Result = sp500.Calculate(initialcap, annualInvest, startY, endY);
                Console.WriteLine("Final Capital : " + sp500Result.FinalCapital);
                Console.WriteLine("Total Investment : " + sp500Result.TotalInvestment);
                Console.WriteLine("Total Gain : " + sp500Result.TotalGain);
            }
            else if (chooseIndex == "DJ")
            {
                Index djia = new Index();
                djia.MinimumYear = 1916;
                djia.MaximumYear = 2019;
                djia.Historical = new double[] { -4.19, -21.71, 10.51, 30.45, -32.9, 12.3, 21.5, -2.7, 26.16, 25.37, 4.05, 27.67, 49.48, -17.17, -33.77, -52.67, -23.07, 66.69, 4.14, 38.53, 24.82, -32.82, 28.06, -2.92, -12.72, -15.38, 7.61, 13.81, 12.09, 26.65, -8.14, 2.23, -2.13, 12.88, 17.63, 14.37, 8.42, -3.77, 43.96, 20.77, 2.27, -12.77, 33.96, 16.4, -9.34, 18.71, -10.81, 17, 14.57, 10.88, -18.94, 15.2, 4.27, -15.19, 4.82, 6.11, 14.58, -16.58, -27.57, 38.32, 17.86, -17.27, -3.15, 4.19, 14.93, -9.23, 19.6, 20.27, -3.74, 27.66, 22.58, 2.26, 11.85, 26.96, -4.34, 20.32, 4.17, 13.72, 2.14, 33.45, 26.01, 22.64, 16.1, 25.22, -6.17, -7.1, -16.76, 25.32, 3.15, -0.61, 16.29, 6.43, -33.84, 18.82, 11.02, 5.53, 7.26, 26.5, 7.52, -2.23, 13.42, 25.08, -5.63, 22.34 };
                Console.WriteLine("Index Fund : DJIA");
                Console.WriteLine("Initial Capital: ");
                var initialcap = int.Parse(Console.ReadLine());
                Console.WriteLine("Annual Investment: ");
                var annualInvest = int.Parse(Console.ReadLine());
                Console.WriteLine("Start Year: ");
                var startY = int.Parse(Console.ReadLine());
                Console.WriteLine("End Year: ");
                var endY = int.Parse(Console.ReadLine());
                var djiaResult = djia.Calculate(initialcap, annualInvest, startY, endY);
                Console.WriteLine("Final Capital: " + djiaResult.FinalCapital);
                Console.WriteLine("Total Investment : " + djiaResult.TotalInvestment);
                Console.WriteLine("Total Gain : " + djiaResult.TotalGain);
            }
            Console.ReadKey();
        }    
    }
}


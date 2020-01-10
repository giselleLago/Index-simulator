using System;
using System.Collections.Generic;

namespace IndexSimulator
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Choose Index \n S&P 500 (1)\n DJIA (2)\n NASDAQ (3)");
            var chooseIndex = Console.ReadLine().ToUpper();
            if (chooseIndex != "1" && chooseIndex != "2" && chooseIndex != "3")
            {
                do
                {
                    Console.WriteLine("Index must be (1)(2)(3)");
                    Console.WriteLine("Choose Index \n S&P 500 (1)\n DJIA (2)\n NASDAQ (3)");
                    chooseIndex = Console.ReadLine().ToUpper();
                } while (chooseIndex != "1" && chooseIndex != "2" && chooseIndex != "3");
            }
            Console.WriteLine("Initial Capital: ");
            var initialcap = int.Parse(Console.ReadLine());
            Console.WriteLine("Annual Investment: ");
            var annualInvest = int.Parse(Console.ReadLine());
            Console.WriteLine("Start Year: ");
            var startY = int.Parse(Console.ReadLine());
            Console.WriteLine("End Year: ");
            var endY = int.Parse(Console.ReadLine());

            var indexFactory = new IndexFactory();
            var index = indexFactory.Create(chooseIndex);
            var result = index.Calculate(initialcap, annualInvest, startY, endY);
 
            
            Console.WriteLine(result.Name);
            Console.WriteLine("Simulation from ( " + result.StartYear + " ) to ( " + result.EndYear + " )");
            Console.WriteLine("Final Capital : " + result.FinalCapital);
            Console.WriteLine("Total Investment : " + result.TotalInvestment);
            Console.WriteLine("Total Gain : " + result.TotalGain);
            Console.ReadKey();
        }    
    }
}


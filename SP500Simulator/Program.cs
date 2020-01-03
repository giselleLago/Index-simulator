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
            var result = index.Calculate(initialcap, annualInvest, startY, endY); ;
 
            
            Console.WriteLine(result.Name);
            Console.WriteLine("Simulation from ( " + result.StartYear + " ) to ( " + result.EndYear + " )");
            Console.WriteLine("Final Capital : " + result.FinalCapital);
            Console.WriteLine("Total Investment : " + result.TotalInvestment);
            Console.WriteLine("Total Gain : " + result.TotalGain);
            Console.ReadKey();
        }    
    }
}


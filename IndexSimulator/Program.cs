using System;

namespace IndexSimulator
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Choose Index \n S&P 500 (1)\n DJIA (2)\n NASDAQ (3)");
            var chooseIndex = Console.ReadLine().ToUpper();
            while (chooseIndex != "1" && chooseIndex != "2" && chooseIndex != "3")
            {
                Console.WriteLine("Index must be (1)(2)(3)");
                Console.WriteLine("Choose Index \n S&P 500 (1)\n DJIA (2)\n NASDAQ (3)");
                chooseIndex = Console.ReadLine().ToUpper();
            }

            var indexFactory = new IndexFactory();
            var index = indexFactory.Create(chooseIndex);

            var initialCap = PromptNumber("Initial Capital: ");
            var annualInvest = PromptNumber("Annual Investment: ");
            var startY = PromptMinYear($"Start Year: ({index.MinimumYear} to {index.MaximumYear - 1})", index.MinimumYear, index.MaximumYear);
            var endY = PrompotMaxYear($"End Year: ({startY + 1} to {index.MaximumYear}) ", index.MaximumYear, startY);
            
            var result = index.Calculate(initialCap, annualInvest, startY, endY);

            Console.WriteLine(result.Name);
            Console.WriteLine("Simulation from ( " + result.StartYear + " ) to ( " + result.EndYear + " )");
            Console.WriteLine("Final Capital : " + result.FinalCapital);
            Console.WriteLine("Total Investment : " + result.TotalInvestment);
            Console.WriteLine("Total Gain : " + result.TotalGain);
            Console.ReadKey();

        }
        public static int PromptNumber(string message)
        {
            int result;
            bool success;
            do
            {
                Console.WriteLine(message);
                var input = Console.ReadLine();
                success = int.TryParse(input, out result);
            } while (!success);
            return result;
        }

        public static int PromptMinYear(string message, int startYear, int endYear)
        {
            int result;
            bool success;
            do
            {
                Console.WriteLine(message);
                var input = Console.ReadLine();
                success = int.TryParse(input, out result);
            } while (!success || result < startYear || result > (endYear - 1));
            return result;
        }

        public static int PrompotMaxYear(string message, int endYear, int startYear)
        {
            int result;
            bool success;
            do
            {
                Console.WriteLine(message);
                var input = Console.ReadLine();
                success = int.TryParse(input, out result);
            } while (!success || (startYear + 1) > result || result > endYear);
            return result;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP500Simulator
{
    public class Index
    {
        public int MinimumYear { get; set; }
        public int MaximumYear { get; set; }
        public string Name { get; set; }

        public IEnumerable<double> Historical;

        public SimulationResult Calculate(double initialcapital, double annualInvestment, int startYear, int endYear)
        {
            var indexStart = startYear - MinimumYear;
            var indexEnd = endYear - MinimumYear;
            var totalInvestment = initialcapital;
            double currentCapital = initialcapital;
            for (int i = indexStart; i <= indexEnd; i++)
            {
                var anualReturn = Historical.ElementAt(i);
                totalInvestment += annualInvestment;
                currentCapital += currentCapital * (anualReturn / 100) + annualInvestment;

            }
            var totalGain = currentCapital - totalInvestment;

            var result = new SimulationResult();
            result.TotalInvestment = totalInvestment;
            result.FinalCapital = currentCapital;
            result.TotalGain = totalGain;
            result.Name = Name;
            result.StartYear = startYear;
            result.EndYear = endYear;
            return result;
        
        }
    }
}


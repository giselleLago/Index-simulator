using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndexSimulator
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
            return new SimulationResult
            {
                TotalInvestment = totalInvestment,
                FinalCapital = currentCapital,
                TotalGain = totalGain,
                Name = Name,
                StartYear = startYear,
                EndYear = endYear
            };
        }
    }
}


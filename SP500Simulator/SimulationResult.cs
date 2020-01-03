using System;
using System.Collections.Generic;
using System.Text;

namespace SP500Simulator
{
    public class SimulationResult
    {
        public double TotalInvestment { get; set; }
        public double FinalCapital { get; set; }
        public double TotalGain { get; set; }
        public string Name { get; set; }
    }
}

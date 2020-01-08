using System;
using System.Collections.Generic;
using System.Text;

namespace SP500Simulator
{
    public class IndexFactory
    {
        public Index Create(string indexName)
        {
            if (indexName == "1")
            {
                var url = "https://www.macrotrends.net/2324/sp-500-historical-chart-data";
                Index sp500 = new Index();
                IndexResolver indexResolver = new IndexResolver(url);
                indexResolver.ExtractData();
                sp500.MinimumYear = indexResolver.GetMinimumYear();
                sp500.MaximumYear = indexResolver.GetMaximumYear();
                sp500.Historical = indexResolver.GetHistoricalData();
                sp500.Name = indexResolver.GetIndexName();
                return sp500;
            }
            else if (indexName == "2")
            {
                var url = "https://www.macrotrends.net/1319/dow-jones-100-year-historical-chart";
                Index djia = new Index();
                IndexResolver indexResolver = new IndexResolver(url);
                indexResolver.ExtractData();
                djia.MinimumYear = indexResolver.GetMinimumYear();
                djia.MaximumYear = indexResolver.GetMaximumYear();
                djia.Historical = indexResolver.GetHistoricalData();
                djia.Name = indexResolver.GetIndexName();
                return djia;
            }
            else
            {
                var url = "https://www.macrotrends.net/1320/nasdaq-historical-chart";
                Index nasdaq = new Index();
                IndexResolver indexResolver = new IndexResolver(url);
                indexResolver.ExtractData();
                nasdaq.MinimumYear = indexResolver.GetMinimumYear();
                nasdaq.MaximumYear = indexResolver.GetMaximumYear();
                nasdaq.Historical = indexResolver.GetHistoricalData();
                nasdaq.Name = indexResolver.GetIndexName();
                return nasdaq;
            }
        }
    }
}

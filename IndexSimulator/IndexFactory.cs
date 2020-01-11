namespace IndexSimulator
{
    public class IndexFactory
    {
        public Index Create(string indexName)
        {
            switch (indexName)
            {
                case "1":
                {
                    var url = "https://www.macrotrends.net/2324/sp-500-historical-chart-data";
                    Index sp500 = new Index();
                    IndexResolver indexResolver = new IndexResolver(url);
                    indexResolver.ExtractData();
                    sp500.MinimumYear = indexResolver.GetMinimumYear();
                    sp500.MaximumYear = indexResolver.GetMaximumYear();
                    sp500.Historical = indexResolver.GetHistoricalData();
                    sp500.Name = indexResolver.IndexName;
                    return sp500;
                }
                case "2":
                {
                    var url = "https://www.macrotrends.net/1319/dow-jones-100-year-historical-chart";
                    Index djia = new Index();
                    IndexResolver indexResolver = new IndexResolver(url);
                    indexResolver.ExtractData();
                    djia.MinimumYear = indexResolver.GetMinimumYear();
                    djia.MaximumYear = indexResolver.GetMaximumYear();
                    djia.Historical = indexResolver.GetHistoricalData();
                    djia.Name = indexResolver.IndexName;
                    return djia;
                }
                default:
                {
                    var url = "https://www.macrotrends.net/1320/nasdaq-historical-chart";
                    Index nasdaq = new Index();
                    IndexResolver indexResolver = new IndexResolver(url);
                    indexResolver.ExtractData();
                    nasdaq.MinimumYear = indexResolver.GetMinimumYear();
                    nasdaq.MaximumYear = indexResolver.GetMaximumYear();
                    nasdaq.Historical = indexResolver.GetHistoricalData();
                    nasdaq.Name = indexResolver.IndexName;
                    return nasdaq;
                }
            } 
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace IndexSimulator
{
    public class IndexResolver
    {
        private string _url;
        private IEnumerable<DataPoint> _serie;
        private string _indexName;

        public IndexResolver(string url)
        {
            _url = url;
        }

        public void ExtractData()
        {
            var html = GetHTML(_url);
            _serie = GetDataSerie(html);
            _indexName = GetIndexName(html);
        }

        private string GetHTML(string url)
        {
            using (WebClient client = new WebClient())
            {
                string htmlCode = client.DownloadString(url);
                return htmlCode;
            }
        }

        private IEnumerable<DataPoint> GetDataSerie(string html)
        {
            var HistoricalData = new List<DataPoint>();
            var regexp = new Regex("<td style=\"text-align:center\">(?<year>[0-9]{4}).*?(?<value>-?[0-9]+\\.*[0-9]*)%", RegexOptions.Singleline);
            foreach (Match matches in regexp.Matches(html))
            {
                int year = int.Parse(matches.Groups["year"].Value);
                var value = double.Parse(matches.Groups["value"].Value);
                var dataPoint = new DataPoint();
                dataPoint.Value = value;
                dataPoint.Year = year;
                HistoricalData.Add(dataPoint);
            }
            return HistoricalData;
        }

        private string GetIndexName(string html)
        {
            var regexp = new Regex("<title>(?<name>.*?) -", RegexOptions.Singleline);
            var indexName = regexp.Match(html).Groups["name"].Value.ToString();
            return WebUtility.HtmlDecode(indexName);
        }

        public string IndexName => _indexName;

        public int GetMinimumYear() => _serie.Min(x => x.Year);

        public int GetMaximumYear() => _serie.Max(x => x.Year);

        public IEnumerable<double> GetHistoricalData() => _serie.OrderBy(x => x.Year).Select(x => x.Value).ToList();


    }
}

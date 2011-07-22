﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using Encog.Util.CSV;

namespace Encog.ML.Data.Market.Loader
{
#if !SILVERLIGHT
    /// <summary>
    /// A loader for Google.com.
    /// 
    /// From code provided by: fxmozart
    /// http://www.heatonresearch.com/node/2102
    /// </summary>
    public class GoogleLoader: IMarketLoader
    {
        /// <summary>
        /// Construct the object.
        /// </summary>
        public GoogleLoader()
        {
            Precision = 10;
        }

        /// <summary>
        /// The percision.
        /// </summary>
        public int Precision { get; set; }


        private static Uri BuildUrl(TickerSymbol ticker, DateTime from,
                                    DateTime to)
        {
            // construct the URL  
            string uri = string.Format(
                CultureInfo.InvariantCulture,
                "http://finance.google.com/finance/historical?q={0}&histperiod=daily&startdate={1:MMM d, yyyy}&enddate={2:MMM d, yyyy}&output=csv",
                ticker.Symbol.ToUpper(),
                from,
                to);

            return new Uri(uri);
        }

        /// <summary>
        /// Load financial data from Google.
        /// </summary>
        /// <param name="ticker">The ticker to load from.</param>
        /// <param name="dataNeeded">The data needed.</param>
        /// <param name="from">The starting time.</param>
        /// <param name="to">The ending time.</param>
        /// <returns>The loaded data.</returns>
        public ICollection<LoadedMarketData> Load(TickerSymbol ticker, IList<MarketDataType> dataNeeded, DateTime from,
                                                  DateTime to)
        {
            ICollection<LoadedMarketData> result = new List<LoadedMarketData>();
            Uri url = BuildUrl(ticker, from, to);
            WebRequest http = WebRequest.Create(url);
            var response = (HttpWebResponse) http.GetResponse();

            if (response != null)
                using (Stream istream = response.GetResponseStream())
                {
                    var csv = new ReadCSV(istream, true, CSVFormat.DecimalPoint);

                    while (csv.Next())
                    {
                        DateTime date = csv.GetDate("date");

                        double open = csv.GetDouble("open");
                        double close = csv.GetDouble("close");
                        double high = csv.GetDouble("high");
                        double low = csv.GetDouble("low");
                        double volume = csv.GetDouble("volume");

                        var data =
                            new LoadedMarketData(date, ticker);

                        data.SetData(MarketDataType.Open, open);
                        data.SetData(MarketDataType.Close, close);
                        data.SetData(MarketDataType.High, high);
                        data.SetData(MarketDataType.Low, low);
                        data.SetData(MarketDataType.Open, open);
                        data.SetData(MarketDataType.Volume, volume);
                        result.Add(data);
                    }

                    csv.Close();
                    if (istream != null) istream.Close();
                }
            return result;
        }
    }
#endif
}
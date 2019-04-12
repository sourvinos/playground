using Interfaces;
using System.Collections.Generic;
using System.IO;

namespace Implementations
{
    public class StreamTradeDataProvider : ITradeDataProvider
    {
        // Variables
        private readonly Stream stream;

        // Constructor
        public StreamTradeDataProvider(Stream stream)
        {
            this.stream = stream;
        }

        // Interface implementation - Accept data from a text file, store each line in a collection and return it (no dependencies)
        public IEnumerable<string> GetTradeData()
        {
            var tradeData = new List<string>();

            using (var reader = new StreamReader(stream))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }

            return tradeData;
        }
    }
}

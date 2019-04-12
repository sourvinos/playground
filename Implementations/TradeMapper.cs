using Interfaces;

namespace Implementations
{
    public class TradeMapper : ITradeMapper
    {
        // Variables
        private readonly static float LotSize = 100000f;

        // Interface implementation - Accept a string, break it, create a new TradeRecord and return it (no dependencies)
        public TradeRecord Map(string[] fields)
        {
            var sourceCurrencyCode = fields[0].Substring(0, 3);
            var destinationCurrencyCode = fields[0].Substring(3, 3);
            var tradeAmount = int.Parse(fields[1]);
            var tradePrice = decimal.Parse(fields[2]);
            var broker = fields[3];

            var tradeRecord = new TradeRecord
            {
                SourceCurrency = sourceCurrencyCode,
                DestinationCurrency = destinationCurrencyCode,
                Lots = tradeAmount / LotSize,
                Price = tradePrice,
                Broker = broker
            };

            return tradeRecord;
        }
    }
}

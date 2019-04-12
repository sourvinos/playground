using Interfaces;

namespace Solid
{
    public class TradeProcessor
    {
        // Variables
        private ITradeDataProvider tradeDataProvider;
        private ITradeParser tradeParser;
        private ITradeStorage tradeStorage;

        // Constructor
        public TradeProcessor(ITradeDataProvider tradeDataProvider, ITradeParser tradeParser, ITradeStorage tradeStorage)
        {
            this.tradeDataProvider = tradeDataProvider;
            this.tradeParser = tradeParser;
            this.tradeStorage = tradeStorage;
        }

        // Main
        public void ProcessTrades()
        {
            var lines = tradeDataProvider.GetTradeData();
            var trades = tradeParser.Parse(lines);

            tradeStorage.Persist(trades);
        }
    }
}

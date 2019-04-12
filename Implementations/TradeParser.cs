using Interfaces;
using System.Collections.Generic;

namespace Implementations
{
    public class TradeParser : ITradeParser
    {
        // Variables
        private readonly ITradeValidator tradeValidator;
        private readonly ITradeMapper tradeMapper;

        // Constructor
        public TradeParser(ITradeValidator tradeValidator, ITradeMapper tradeMapper)
        {
            this.tradeValidator = tradeValidator;
            this.tradeMapper = tradeMapper;
        }

        // Interface implementation - Accept a collection of strings, validate them (dependency), map them into records (dependency) and return them
        public IEnumerable<TradeRecord> Parse(IEnumerable<string> tradeData)
        {
            var trades = new List<TradeRecord>();
            var lineCount = 1;

            foreach (var line in tradeData)
            {
                var fields = line.Split(new char[] { ',' });

                if (!tradeValidator.Validate(fields))
                {
                    continue;
                }

                var trade = tradeMapper.Map(fields);

                trades.Add(trade);
                lineCount++;
            }

            return trades;
        }
    }
}

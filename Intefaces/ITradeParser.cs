using System.Collections.Generic;

namespace Interfaces
{
    public interface ITradeParser
    {
        IEnumerable<TradeRecord> Parse(IEnumerable<string> tradeData);
    }
}

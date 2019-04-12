using System.Collections.Generic;

namespace Interfaces
{
    public interface ITradeStorage
    {
        void Persist(IEnumerable<TradeRecord> trades);
    }
}

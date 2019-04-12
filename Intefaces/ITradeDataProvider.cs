using System.Collections.Generic;

namespace Interfaces
{
    public interface ITradeDataProvider
    {
        IEnumerable<string> GetTradeData();
    }
}

using Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Implementations
{
    public class AdoNetTradeStorage : ITradeStorage
    {
        // Variables
        private readonly ILogger logger;

        // Constructor
        public AdoNetTradeStorage(ILogger logger)
        {
            this.logger = logger;
        }

        public void Persist(IEnumerable<TradeRecord> trades)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection("Server=lenovo\\sqlexpress;Database=trades;Trusted_Connection=true"))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    foreach (var trade in trades)
                    {
                        var command = connection.CreateCommand();
                        command.Transaction = transaction;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "dbo.insert_trade";
                        command.Parameters.AddWithValue("@sourceCurrency", trade.SourceCurrency);
                        command.Parameters.AddWithValue("@destinationCurrency", trade.DestinationCurrency);
                        command.Parameters.AddWithValue("@lots", trade.Lots);
                        command.Parameters.AddWithValue("@price", trade.Price);
                        command.Parameters.AddWithValue("@broker", trade.Broker);
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }

                connection.Close();
            }

            logger.LogInfo("INFO: {0} trades processed", trades.Count());
        }
    }
}

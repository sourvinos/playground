using System;
using System.Collections.Generic;
using System.Linq;

/* Break into small pieces for clarity but not yet for adaptability! */

namespace Solid
{
    public class TradeProcessor
    {
        // Variables
        private static float LotSize = 100000f;

        // Main Process
        public void ProcessTrades(System.IO.Stream stream)
        {
            // Read data from file (1)
            var lines = ReadTradeData(stream);

            // Add the data to a collection of objects (2)
            var trades = ParseTrades(lines);

            // Store the collection to the database (3)
            StoreTrades(trades);
        }

        // Read data from file (1)
        public IEnumerable<string> ReadTradeData(System.IO.Stream stream)
        {
            var tradeData = new List<string>();

            using (var reader = new System.IO.StreamReader(stream))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }

            return tradeData;
        }

        // Add the data to a collection of objects (2)
        private IEnumerable<TradeRecord> ParseTrades(IEnumerable<string> tradeData)
        {
            var trades = new List<TradeRecord>();
            var lineCount = 1;

            foreach (var line in tradeData)
            {
                var fields = line.Split(new char[] { ',' });

                if (!ValidateTradeData(fields, lineCount))
                {
                    continue;
                }

                var trade = MapTradeDataToTradeRecord(fields);

                trades.Add(trade);
                lineCount++;
            }

            return trades;
        }

        // Store the collection to the database (3)
        private void StoreTrades(IEnumerable<TradeRecord> trades)
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
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }

                connection.Close();
            }

            LogMessage("INFO: {0} trades processed", trades.Count());
        }

        // Helper: Validation
        private bool ValidateTradeData(string[] fields, int currentLine)
        {
            // Total fields
            if (fields.Length != 3)
            {
                LogMessage("WARN: Line {0} malformed. Only {1} field(s) found.", currentLine, fields.Length);

                return false;
            }

            // Currency 
            if (fields[0].Length != 6)
            {
                LogMessage("WARN: Trade currencies on line {0} malformed: '{1}'", currentLine, fields[0]);

                return false;
            }

            // Amount
            int tradeAmount;

            if (!int.TryParse(fields[1], out tradeAmount))
            {
                LogMessage("WARN: Trade amount on line {0} not a valid integer: '{1}'", currentLine, fields[1]);

                return false;
            }

            // Price
            decimal tradePrice;

            if (!decimal.TryParse(fields[2], out tradePrice))
            {
                LogMessage("WARN: Trade price on line {0} not a valid decimal: '{1}'", currentLine, fields[2]);
            }

            return true;
        }

        // Helper: LogMessage
        private void LogMessage(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }

        // Helper: Create Trade Records
        private TradeRecord MapTradeDataToTradeRecord(string[] fields)
        {
            var sourceCurrencyCode = fields[0].Substring(0, 3);
            var destinationCurrencyCode = fields[0].Substring(3, 3);
            var tradeAmount = int.Parse(fields[1]);
            var tradePrice = decimal.Parse(fields[2]);

            var tradeRecord = new TradeRecord
            {
                SourceCurrency = sourceCurrencyCode,
                DestinationCurrency = destinationCurrencyCode,
                Lots = tradeAmount / LotSize,
                Price = tradePrice
            };

            return tradeRecord;
        }
    }
}


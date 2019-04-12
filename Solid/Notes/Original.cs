using System;
using System.Collections.Generic;

namespace Solid
{
    public class TradeProcessor
    {
        private static float LotSize = 100000f;

		// ProcessTrades does everything!
		public void ProcessTrades(System.IO.Stream stream)
        {
            // Variables
            var lines = new List<string>();

            // Task 1: Read each line and add it to the lines collection
            using (var reader = new System.IO.StreamReader(stream))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            // Variables
            var trades = new List<TradeRecord>();
            var lineCount = 1;

            // Task 2: Read each line from the lines collection, do some error checking and add it to a new TradeRecord object
            foreach (var line in lines)
            {
                var fields = line.Split(new char[] { ',' });

                // Check for error
                if (fields.Length != 3)
                {
                    Console.WriteLine("WARN: Line {0} malformed. Only {1} field(s) found.",
                    lineCount, fields.Length);
                    continue;
                }

                // Check for error
                if (fields[0].Length != 6)
                {
                    Console.WriteLine("WARN: Trade currencies on line {0} malformed: '{1}'",
                    lineCount, fields[0]);
                    continue;
                }

                // Check for error

                int tradeAmount;

                if (!int.TryParse(fields[1], out tradeAmount))
                {
                    Console.WriteLine("WARN: Trade amount on line {0} not a valid integer: '{1}'", lineCount, fields[1]);
                }

                // Check for error
                decimal tradePrice;

                if (!decimal.TryParse(fields[2], out tradePrice))
                {
                    Console.WriteLine("WARN: Trade price on line {0} not a valid decimal: '{1}'", lineCount, fields[2]);
                }

                // Break the string
                var sourceCurrencyCode = fields[0].Substring(0, 3);
                var destinationCurrencyCode = fields[0].Substring(3, 3);

                // Create a new TradeRecord
                var trade = new TradeRecord
                {
                    SourceCurrency = sourceCurrencyCode,
                    DestinationCurrency = destinationCurrencyCode,
                    Lots = tradeAmount / LotSize,
                    Price = tradePrice
                };

                // Add the TradeRecord to the collection
                trades.Add(trade);
                lineCount++;
            }

            // Task 3: Store the collection to the database
            using (var connection = new System.Data.SqlClient.SqlConnection("Data Source=(local); Initial Catalog=Trades; Integrated Security=True"))
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

            // Finally
            Console.WriteLine("INFO: {0} trades processed", trades.Count);
        }
    }
}


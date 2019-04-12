using Implementations;
using System;
using System.IO;

namespace Solid
{
    class Program
    {
        static void Main(string[] args)
        {
            var tradeStream = new FileStream("trades.txt", FileMode.Open, FileAccess.Read);

            var logger = new ConsoleLogger();
            var tradeValidator = new TradeValidator(logger);
            var tradeDataProvider = new StreamTradeDataProvider(tradeStream);
            var tradeMapper = new TradeMapper();
            var tradeParser = new TradeParser(tradeValidator, tradeMapper);
            var tradeStorage = new AdoNetTradeStorage(logger);

            var tradeProcessor = new TradeProcessor(tradeDataProvider, tradeParser, tradeStorage);

            tradeProcessor.ProcessTrades();

            Console.ReadKey();
        }
    }
}
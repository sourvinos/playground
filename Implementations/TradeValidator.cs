using Interfaces;

namespace Implementations
{
    public class TradeValidator : ITradeValidator
    {
        // Variables
        private readonly ILogger logger;

        // Constructor
        public TradeValidator(ILogger logger)
        {
            this.logger = logger;
        }

        // Interface implementation - Accept a string, log if error is found (dependency) and return true if it's error-free
        public bool Validate(string[] field)
        {
            // Total fields
            if (field.Length != 4)
            {
                logger.LogError("WARN: Line malformed at symbol {0}. Only {1} field(s) found.", field[0], field.Length);

                return false;
            }

            // Currency 
            if (field[0].Length != 6)
            {
                logger.LogError("WARN: Trade currencies malformed: '{0}'", field[0]);

                return false;
            }

            // Amount
            if (!int.TryParse(field[1], out int tradeAmount))
            {
                logger.LogError("WARN: Trade amount is not a valid integer: '{0}'", field[1]);

                return false;
            }

            // Price
            if (!decimal.TryParse(field[2], out decimal tradePrice))
            {
                logger.LogError("WARN: Trade price on is not a valid decimal: '{0}'", field[2]);

                return false;
            }

            // Broker
            if (field[3].Length == 0)
            {
                logger.LogError("WARN: Broker is missing at symbol {0}", field[0]);

                return false;
            }

            return true;
        }
    }
}

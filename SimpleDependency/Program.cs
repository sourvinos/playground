using MessagePrinter;

namespace SimpleDependency
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = new MessagePrintingService();

            message.PrintMessage();
        }
    }
}

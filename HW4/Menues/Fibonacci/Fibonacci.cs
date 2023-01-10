using ConsoleManagement;

namespace HW4.Menues.Fibonacci
{
    internal class Fibonacci : IOption
    {
        public string OptionName { get => "Calculate number"; }

        public void Run()
        {
            ExecuteFibonacci();
        }

        private static void ExecuteFibonacci()
        {
            Console.Clear();

            ConsoleHelper.WriteService("Enter sequence number");
            string input = Console.ReadLine();

            long sequenceNumber;
            while (!long.TryParse(input, out sequenceNumber) || sequenceNumber < 1)
            {
                ConsoleHelper.WriteError("Enter correct number > 0");
                input = Console.ReadLine();
            }

            ShowFibonacciNumber(sequenceNumber);
        }

        private static void ShowFibonacciNumber(long sequenceNumber)
        {
            ConsoleHelper.WriteResult("Result");
            ConsoleHelper.WriteResult(CalculateFibonacciNumber(sequenceNumber).ToString());

            ConsoleHelper.WriteService("Tap anything");
            Console.ReadKey();
        }

        private static long CalculateFibonacciNumber(long sequenceNumber)
        {
            if (sequenceNumber == 2)
            {
                return 1;
            }

            if (sequenceNumber == 1)
            {
                return 0;
            }

            long a = 0, b = 1;
            long temp;
            for(long i = 3; i <= sequenceNumber; i++)
            {
                temp = a + b;
                a = b;
                b = temp;
            }

            return b;
        }
    }
}

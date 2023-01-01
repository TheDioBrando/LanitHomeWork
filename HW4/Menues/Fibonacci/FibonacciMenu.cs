namespace HW4.Menues.Fibonacci
{
    public class FibonacciMenu : Menu, IOption
    {
        public FibonacciMenu(List<IOption> options) : base(options)
        {
        }

        public string OptionName { get => "Fibonacci number"; }
    }
}

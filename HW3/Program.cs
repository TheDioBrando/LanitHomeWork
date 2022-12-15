using HW3.Menues.Database;
using HW3.Menues.Fibonacci;
using HW3.Menues.ReadFromFile;
using HW3.Menues.WriteWebPageToFile;
using HW3.Menues;

namespace HW3
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Menu menu = new MainMenu(new List<IOption>
            {
                new ReadMenu( new List<IOption> { new FileReader() }),
                new WriteMenu( new List<IOption> { new FileWriter() }),
                new FibonacciMenu( new List<IOption> { new Fibonacci() }),
                new DataBaseMenu( new List<IOption>{ new User(), new Books(), new Libraries(), new Orders()})
            });
            menu.Run();
        }
    }
}
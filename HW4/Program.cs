using HW4.Menues.Fibonacci;
using HW4.Menues.ReadFromFile;
using HW4.Menues.WriteWebPageToFile;
using HW4.Menues;
using HW4.Data;
using Microsoft.EntityFrameworkCore;
using HW4.Menues.DB;

namespace HW4
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (LibDbContext context = new LibDbContext())
            {
                context.Database.Migrate();
            }

            Menu menu = new MainMenu(new List<IOption>
            {
                new ReadMenu( new List<IOption> { new FileReader() }),
                new WriteMenu( new List<IOption> { new FileWriter() }),
                new FibonacciMenu( new List<IOption> { new Fibonacci() }),
                new DBMenu( new List<IOption>{new UserCommand(), new BookCommand(), new LibraryCommand(), new OrderCommand()})
            });

            menu.Run();
        }
    }
}
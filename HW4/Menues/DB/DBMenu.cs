
using ConsoleManagement;
using HW4.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HW4.Menues.DB
{
    public class DBMenu : Menu, IOption
    {
        private readonly LibContext _context;
        private IController _controller;

        public DBMenu(List<IOption> options, LibContext context) : base(options)
        {
            _context = context;
        }

        public string OptionName => "DataBase";

        protected override void SelectMenuItem()
        {
            char choice = Console.ReadKey().KeyChar;

            while (choice < '1' || choice > '5')
            {
                ConsoleHelper.WriteError("Write correct menu item");
                choice = Console.ReadKey().KeyChar;
            }

            switch (choice)
            {
                case '1':
                    _controller = new UserController();
                    break;
                case '2':
                    _controller = new BookController();
                    break;
                case '3':
                    _controller = new LibraryController();
                    break;
                case '4':
                    _controller = new OrderController();
                    break;
                case '5':
                    _active = false;
                    return;
            }

            ShowCommands();
        }

        public void ShowCommands()
        {
            ConsoleHelper.WriteMenu($"Select menu item: \n" +
               $"1) Insert;\n" +
               $"2) Read;\n" +
               $"3) Update;\n" +
               $"4) Delete; \n" +
               $"5) Exit");
            SelectCommand();
        }

        public void SelectCommand()
        {
            char choice = Console.ReadKey().KeyChar;

            while (choice < '1' || choice > '5')
            {
                ConsoleHelper.WriteError(" Write correct menu item");
                choice = Console.ReadKey().KeyChar;
            }

            switch (choice)
            {
                case '1':
                    _controller.Create(_context);
                    break;
                case '2':
                    _controller.Read(_context);
                    break;
                case '3':
                    _controller.Update(_context);
                    break;
                case '4':
                    _controller.Delete(_context);
                    break;
                case '5':
                    return;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                ConsoleHelper.WriteError(e.Message);
            }
        }
    }
}

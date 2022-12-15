using System.Data.SqlClient;

namespace HW3.Menues.Database
{
    public class DataBaseMenu : Menu, IOption
    {
        private const string CONNECTION_STRING = @"Server=Uvarov;Database=Libs;Trusted_Connection=True"; // You should name const with first capitalize letter (e.x. CONNECTION_STRING) or UPPER_CASE (e.x. CONNECTION_STRING)
        private SqlConnection _connection;
        private ITable table;

        public DataBaseMenu(List<IOption> options) : base(options)
        {
            _connection = new SqlConnection(CONNECTION_STRING);
        }

        public string OptionName => "Database";

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
                    table = new User();
                    break;
                case '2':
                    table = new Books();
                    break;
                case '3':
                    table = new Libraries();
                    break;
                case '4':
                    table = new Orders();
                    break;
                case '5':
                    _active = false;
                    return;
            }

            ShowCommands();
        }

        private void ShowCommands()
        {
            ConsoleHelper.WriteMenu("Select menu item: \n" + // You don't need interpolation here ($)
               "1) Insert;\n" +
               "2) Read;\n" +
               "3) Update;\n" +
               "4) Delete; \n" +
               "5) Exit");

            SelectCommand();
        }

        private void SelectCommand()
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
                    table.Create(_connection);
                    break;
                case '2':
                    table.Read(_connection);
                    break;
                case '3':
                    table.Update(_connection);
                    break;
                case '4':
                    table.Delete(_connection);
                    break;
                case '5':
                    _active = false;
                    return;
            }
        }
    }
}

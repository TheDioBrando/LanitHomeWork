using System.Data.SqlClient;

namespace HW3.Menues.Database
{
    public class Orders : ITable, IOption
    {
        public string OptionName => "Orders";

        public void Run() // This is not so good.. may be you need to refactor your architecture. But not necessary.
        {
            //nothing
        }

        public void Create(SqlConnection connection)
        {
            connection.Open();

            (int userId, int bookId) = ReceiceInputForCreate();

            string query = @$"INSERT INTO Orders VALUES ({userId}, {bookId}) ";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    ConsoleHelper.WriteError(e.Message);
                }
            }

            connection.Close();
        }

        private (int, int) ReceiceInputForCreate()
        {
            ConsoleHelper.WriteService("Enter user id");
            string input = Console.ReadLine();
            int userId;
            while (!int.TryParse(input, out userId) && userId > 0)
            {
                ConsoleHelper.WriteError("Enter correct number > 0");
                input = Console.ReadLine();
            }

            ConsoleHelper.WriteService("Enter book id");
            input = Console.ReadLine();
            int bookId;
            while (!int.TryParse(input, out bookId) && bookId > 0)
            {
                ConsoleHelper.WriteError("Enter correct number > 0");
                input = Console.ReadLine();
            }

            return (userId, bookId);
        }

        public void Delete(SqlConnection connection)
        {
            connection.Open();

            int id = ReceiveInputForDelete();

            string query = $"DELETE FROM Orders WHERE userID = {id}";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    ConsoleHelper.WriteError(e.Message);
                }
            }

            connection.Close();
        }

        private int ReceiveInputForDelete()
        {
            ConsoleHelper.WriteService("Enter userid for delete");
            string input = Console.ReadLine();
            int id;
            while (!int.TryParse(input, out id) && id > 0)
            {
                ConsoleHelper.WriteError("Enter correct number > 0");
                input = Console.ReadLine();
            }

            return id;
        }

        public void Update(SqlConnection connection)
        {
            ConsoleHelper.WriteService("You have not rules to update me");
        }

        public void Read(SqlConnection connection)
        {
            connection.Open();
            string query = @"SELECT * FROM Orders";

            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataReader read = command.ExecuteReader())
            {
                try
                {
                    while (read.Read())
                    {
                        Console.WriteLine($"user:{read[0]} book:{read[1]}");
                    }
                }
                catch (Exception e)
                {
                    ConsoleHelper.WriteError(e.Message);
                }
            }

            connection.Close();

            ConsoleHelper.WriteService("Tap anything");
            Console.ReadKey();
        }
    }
}

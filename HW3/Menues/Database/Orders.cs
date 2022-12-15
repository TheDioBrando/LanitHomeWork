using System.Data.SqlClient;

namespace HW3.Menues.Database
{
    public class Orders:ITable, IOption
    {
        public string OptionName { get => "Orders"; }

        public void Run()
        {
            //nothing
        }

        public void Create(SqlConnection connection)
        {
            connection.Open();

            ConsoleHelper.WriteService("Enter user id");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int userId) && userId > 0)
            {
                ConsoleHelper.WriteError("Enter correct number > 0");
                input = Console.ReadLine();
            }

            ConsoleHelper.WriteService("Enter book id");
            input = Console.ReadLine();
            if (!int.TryParse(input, out int bookId) && bookId > 0)
            {
                ConsoleHelper.WriteError("Enter correct number > 0");
                input = Console.ReadLine();
            }

            string query = @$"insert into Orders values ({userId}, {bookId}) ";
            using (SqlCommand comm = new SqlCommand(query, connection))
            {
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    ConsoleHelper.WriteError(e.Message);
                }
            }
            connection.Close();
        }

        public void Delete(SqlConnection connection)
        {
            connection.Open();

            ConsoleHelper.WriteService("Enter userid for delete");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int id) && id > 0)
            {
                ConsoleHelper.WriteError("Enter correct number > 0");
                input = Console.ReadLine();
            }

            string query;
            query = $"delete from Orders where userID = {id}";

            using (SqlCommand comm = new SqlCommand(query, connection))
            {
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    ConsoleHelper.WriteError(e.Message);
                }
            }

            connection.Close();
        }

        public void Update(SqlConnection connection)
        {
            ConsoleHelper.WriteService("You have not rules to update me");
        }

        public void Read(SqlConnection connection)
        {
            connection.Open();
            string query = @"Select * from Orders";

            using (SqlCommand comm = new SqlCommand(query, connection))
            {
                try
                {
                    using (SqlDataReader read = comm.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            Console.WriteLine($"user:{read[0]} book:{read[1]}");
                        }
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

using System.Data.SqlClient;

namespace HW3.Menues.Database
{
    public class User : ITable, IOption
    {
        public string OptionName => "User";

        public void Run()
        {
            //nothing
        }

        public void Create(SqlConnection connection)
        {
            connection.Open();

            string name = ReceiveInputForCreate();

            string query = @$"INSERT INTO Users VALUES ('{name}') ";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    command.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    ConsoleHelper.WriteError(e.Message);
                }
            }
            connection.Close();
        }

        private string ReceiveInputForCreate()
        {
            ConsoleHelper.WriteService("Enter user name");
            string name = Console.ReadLine();

            return name;
        }

        public void Delete(SqlConnection connection)
        {
            connection.Open();

            string nameForDelete = ReceiveInputForDelete();

            string query = string.IsNullOrEmpty(nameForDelete) ?
                $"DELETE FROM Users" :
                $"DELETE FROM Users WHERE name='{nameForDelete}'";

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

        private string ReceiveInputForDelete()
        {
            ConsoleHelper.WriteService("Enter name for delete \n or leave empty for delete all rows");
            string nameForDelete = Console.ReadLine();

            return nameForDelete;
        }

        public void Update(SqlConnection connection)
        {
            connection.Open();

            (string nameForUpdate, string newName) = ReceiveInputForUpdate();

            string query = string.IsNullOrEmpty(nameForUpdate) ?
                query = $"UPDATE Users SET name='{newName}'" :
                query = $"UPDATE Users SET name = '{newName}' WHERE name='{nameForUpdate}'";

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

        private (string, string) ReceiveInputForUpdate()
        {
            ConsoleHelper.WriteService("Enter name for update \n or leave empty for update all rows");
            string nameForUpdate = Console.ReadLine();

            ConsoleHelper.WriteService("Enter new name");
            string newName = Console.ReadLine();

            return (nameForUpdate, newName);
        }

        public void Read(SqlConnection connection)
        {
            connection.Open();
            string query = @"SELECT * FROM Users";

            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataReader read = command.ExecuteReader())
            {
                try
                {
                    while (read.Read())
                    {
                        Console.WriteLine($"{read["name"]} ");
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

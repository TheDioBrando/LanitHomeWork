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

            ConsoleHelper.WriteService("Enter user name");
            string name = Console.ReadLine();

            string query = @$"insert into Users values ('{name}') ";
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

        public void Delete(SqlConnection connection)
        {
            connection.Open();

            ConsoleHelper.WriteService("Enter name for delete \n or leave empty for delete all rows");
            string nameForDelete = Console.ReadLine();

            string query;
            if (string.IsNullOrEmpty(nameForDelete))
            {
                query = $"delete from Users";
            }
            else
            {
                query = $"delete from Users where name='{nameForDelete}'";
            }

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

        public void Update(SqlConnection connection)
        {
            connection.Open();

            ConsoleHelper.WriteService("Enter name for update \n or leave empty for update all rows");
            string nameForUpdate = Console.ReadLine();

            ConsoleHelper.WriteService("Enter new name");
            string newName = Console.ReadLine();

            string query;
            if (string.IsNullOrEmpty(nameForUpdate))
            {
                query = $"update Users set name='{newName}'";
            }
            else
            {
                query = $"update Users set name = '{newName}' where name='{nameForUpdate}'";
            }

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

        public void Read(SqlConnection connection)
        {
            connection.Open();
            string query = @"Select * from Users";

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


using System.Data.SqlClient;

namespace HW3.Menues.Database
{
    public class Libraries : ITable, IOption
    {
        public string OptionName => "Libraries";

        public void Run()
        {
            //nothing
        }

        public void Create(SqlConnection connection)
        {
            connection.Open();

            ConsoleHelper.WriteService("Enter address");
            string address = Console.ReadLine();

            string query = @$"insert into Libraries values ('{address}') ";
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

        public void Delete(SqlConnection connection)
        {
            connection.Open();

            ConsoleHelper.WriteService("Enter address for delete \n or leave empty for delete all rows");
            string addressForDelete = Console.ReadLine();

            string query;
            if (string.IsNullOrEmpty(addressForDelete))
            {
                query = $"delete from Libraries";
            }
            else
            {
                query = $"delete from Libraries where address='{addressForDelete}'";
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

            ConsoleHelper.WriteService("Enter address for update \n or leave empty for update all rows");
            string addressForUpdate = Console.ReadLine();

            ConsoleHelper.WriteService("Enter new name");
            string newAddress = Console.ReadLine();

            string query;
            if (string.IsNullOrEmpty(addressForUpdate))
            {
                query = $"update Libraries set name='{newAddress}'";
            }
            else
            {
                query = $"update Libraries set name = '{newAddress}' where name='{addressForUpdate}'";
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
            string query = @"Select * from Libraries";

            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataReader read = command.ExecuteReader())
            {
                try
                {
                    while (read.Read())
                    {
                        Console.WriteLine($"{read["address"]} ");
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

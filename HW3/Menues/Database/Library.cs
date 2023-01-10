
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

            string query = $"INSERT INTO Libraries VALUES ('{ReceiveInputForCreate()}') ";
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

        private string ReceiveInputForCreate()
        {
            ConsoleHelper.WriteService("Enter address");
            string address = Console.ReadLine();

            return address;
        }

        public void Delete(SqlConnection connection)
        {
            connection.Open();

            var addressForDelete = ReceiveInputForDelete();

            string query = string.IsNullOrEmpty(addressForDelete)?
                $"DELETE FROM Libraries":
                $"DELETE FROM Libraries WHERE address='{addressForDelete}'";

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
            ConsoleHelper.WriteService("Enter address for delete \n or leave empty for delete all rows");
            string addressForDelete = Console.ReadLine();

            return addressForDelete;
        }

        public void Update(SqlConnection connection)
        {
            connection.Open();

            (string addressForUpdate, string newAddress) = ReceiveInputForUpdate();

            string query=string.IsNullOrEmpty(addressForUpdate)?
                $"UPDATE Libraries SET name='{newAddress}'":
                $"UPDATE Libraries SET name = '{newAddress}' WHERE  name='{addressForUpdate}'";

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

        private (string,string) ReceiveInputForUpdate()
        {
            ConsoleHelper.WriteService("Enter address for update \n or leave empty for update all rows");
            string addressForUpdate = Console.ReadLine();

            ConsoleHelper.WriteService("Enter new name");
            string newAddress = Console.ReadLine();

            return (addressForUpdate, newAddress);
        }

        public void Read(SqlConnection connection)
        {
            connection.Open();
            string query = "SELECT * FROM Libraries";

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

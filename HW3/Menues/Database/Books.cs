
using System.Data.SqlClient;

namespace HW3.Menues.Database
{
    public class Books:ITable, IOption
    {
        public string OptionName => "Books";

        public void Run()
        {
            //nothing
        }

        public void Create(SqlConnection connection)
        {
            connection.Open();

            (string name, int id) = ReceiveInputForCreate();

            string query = @$"INSERT INTO Books VALUES ('{name}', {id}) ";
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

        private (string, int) ReceiveInputForCreate()
        {
            ConsoleHelper.WriteService("Enter book's name");
            string name = Console.ReadLine();

            ConsoleHelper.WriteService("Enter library's id of the book");
            string input = Console.ReadLine();
            int id;
            while (!int.TryParse(input, out id) && id > 0)
            {
                ConsoleHelper.WriteError("Enter correct number > 0");
                input = Console.ReadLine();
            }

            return (name, id);
        }

        public void Delete(SqlConnection connection)
        {
            connection.Open();

            string nameForDelete = ReceiveInputForDelete();

            string query = string.IsNullOrEmpty(nameForDelete) ? 
                "DELETE FROM Books" :
                $"DELETE FROM Books WHERE name='{nameForDelete}'";

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

            string query = string.IsNullOrWhiteSpace(nameForUpdate) ?
                $"UPDATE Books SET name='{newName}'" :
                $"UPDATE Books SET name = '{newName}' where name='{nameForUpdate}'";

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
            string query = @"SELECT * FROM Books"; 

            using (SqlCommand comm = new SqlCommand(query, connection))
            using (SqlDataReader read = comm.ExecuteReader()) 
            {
                try
                {
                    while (read.Read())
                    {
                        Console.WriteLine($"{read["name"]} in lib {read["lib_id"]}");
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

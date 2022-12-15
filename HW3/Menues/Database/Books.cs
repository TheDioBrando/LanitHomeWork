
using System.Data.SqlClient;

namespace HW3.Menues.Database
{
    public class Books:ITable, IOption
    {
        public string OptionName { get => "Books"; }

        public void Run()
        {
            //nothing
        }

        public void Create(SqlConnection connection)
        {
            connection.Open();

            ConsoleHelper.WriteService("Enter book's name");
            string name = Console.ReadLine();

            ConsoleHelper.WriteService("Enter library of the book");
            string input = Console.ReadLine();
            if(!int.TryParse(input, out int id) && id > 0)
            {
                ConsoleHelper.WriteError("Enter correct number > 0");
                input = Console.ReadLine();
            }

            string query = @$"insert into Books values ('{name}', {id}) ";
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

            ConsoleHelper.WriteService("Enter name for delete \n or leave empty for delete all rows");
            string nameForDelete = Console.ReadLine();

            string query;
            if (string.IsNullOrEmpty(nameForDelete))
            {
                query = $"delete from Books";
            }
            else
            {
                query = $"delete from Books where name='{nameForDelete}'";
            }

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
            connection.Open();

            ConsoleHelper.WriteService("Enter name for update \n or leave empty for update all rows");
            string nameForUpdate = Console.ReadLine();

            ConsoleHelper.WriteService("Enter new name");
            string newName = Console.ReadLine();

            string query;
            if (string.IsNullOrEmpty(nameForUpdate))
            {
                query = $"update Books set name='{newName}'";
            }
            else
            {
                query = $"update Books set name = '{newName}' where name='{nameForUpdate}'";
            }

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

        public void Read(SqlConnection connection)
        {
            connection.Open();
            string query = @"Select * from Books";

            using (SqlCommand comm = new SqlCommand(query, connection))
            {
                try
                {
                    using (SqlDataReader read = comm.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            Console.WriteLine($"{read["name"]} in lib {read["lib_id"]}");
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

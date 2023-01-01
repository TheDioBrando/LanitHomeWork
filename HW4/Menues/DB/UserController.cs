using ConsoleManagement;
using HW4.Data;
using HW4.Models;

namespace HW4.Menues.DB
{
    internal class UserController : IController, IOption
    {
        public string OptionName => "User";

        public void Create(LibContext context)
        {
            context.Users.Add(ReceiveInputForCreate());
        }

        private DbUsers ReceiveInputForCreate()
        {
            ConsoleHelper.WriteService("Enter user name");
            string name = Console.ReadLine();
            return new DbUsers
            {
                Id=Guid.NewGuid(),
                Name=name
            };
        }

        public void Delete(LibContext context)
        {
            string name = ReceiveInputForDelete();
            var user = context.Users.FirstOrDefault(u => u.Name == name); 

            if (user == null)
            {
                ConsoleHelper.WriteError("This user does'nt exist");
                return;
            }

            context.Users.Remove(user);
        }

        private string ReceiveInputForDelete()
        {
            ConsoleHelper.WriteService("Enter name for delete");
            return Console.ReadLine();
        }

        public void Read(LibContext context)
        {
            var users = context.Users.ToList();

            foreach (var user in users)
                ConsoleHelper.WriteResult(String.Join(',', user.Id, user.Name));

            ConsoleHelper.WriteService("Tap anything");
            Console.ReadKey();
        }

        public void Update(LibContext context)
        {
            (string nameForUpdate, string newName) = ReceiveInputForUpdate();
            var user = context.Users.FirstOrDefault(u => u.Name == nameForUpdate);
            
            if(user == null)
            {
                ConsoleHelper.WriteError("This user does'nt exist");
                return;
            }

            user.Name = newName;
        }

        private (string, string) ReceiveInputForUpdate()
        {
            ConsoleHelper.WriteService("Enter name for update");
            string nameForUpdate = Console.ReadLine();

            ConsoleHelper.WriteService("Enter new name");
            string newName = Console.ReadLine();

            return (nameForUpdate, newName);
        }

        public void Run()
        {
            //not implemented
        }
    }
}

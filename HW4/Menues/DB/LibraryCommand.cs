using ConsoleManagement;
using HW4.Data;
using HW4.Models;

namespace HW4.Menues.DB
{
    internal class LibraryCommand : ICommand, IOption
    {
        public string OptionName => "Library";

        private DbLibraries ReceiveInputForCreate()
        {
            ConsoleHelper.WriteService("Enter address");
            string address = Console.ReadLine();

            return new DbLibraries
            {
                Id = Guid.NewGuid(),
                Address = address
            };
        }

        private string ReceiveInputForDelete()
        {
            ConsoleHelper.WriteService("Enter address for delete");
            return Console.ReadLine();
        }

        private (string, string) ReceiveInputForUpdate()
        {
            ConsoleHelper.WriteService("Enter address for update");
            string addressForUpdate = Console.ReadLine();

            ConsoleHelper.WriteService("Enter new address");
            string newAddress = Console.ReadLine();

            return (addressForUpdate, newAddress);
        }

        public void Create(LibDbContext context)
        {
            context.Libraries.Add(ReceiveInputForCreate());
        }

        public void Delete(LibDbContext context)
        {
            var lib = context.Libraries.FirstOrDefault(l => l.Address == ReceiveInputForDelete());

            if (lib == null)
            {
                ConsoleHelper.WriteError("This address does'nt exist");
                return;
            }

            context.Libraries.Remove(lib);
        }

        public void Read(LibDbContext context)
        {
            var libs = context.Libraries.ToList();

            foreach (var lib in libs)
            {
                Console.WriteLine(String.Join(',', lib.Id, lib.Address));
            }

            ConsoleHelper.WriteService("Tap anything");
            Console.ReadKey();
        }

        public void Update(LibDbContext context)
        {
            (string addressForUpdate, string newAddress) = ReceiveInputForUpdate();
            var lib = context.Libraries.FirstOrDefault(l => l.Address == addressForUpdate);

            if (lib == null)
            {
                ConsoleHelper.WriteError("This address does'nt exist");
                return;
            }

            lib.Address = newAddress;
        }

        public void Run()
        {
            //not implemented;
        }
    }
}

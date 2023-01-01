using ConsoleManagement;
using HW4.Data;
using HW4.Models;

namespace HW4.Menues.DB
{
    internal class LibraryController : IController, IOption
    {
        public string OptionName => "Library";

        public void Create(LibContext context)
        {
            context.Libraries.Add(ReceiveInputForCreate());
        }

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

        public void Delete(LibContext context)
        {
            var lib = context.Libraries.FirstOrDefault(l => l.Address == ReceiveInputForDelete());

            if (lib == null)
            {
                ConsoleHelper.WriteError("This address does'nt exist");
                return;
            }

            context.Libraries.Remove(lib);
        }

        private string ReceiveInputForDelete()
        {
            ConsoleHelper.WriteService("Enter address for delete");
            return Console.ReadLine();
        }

        public void Read(LibContext context)
        {
            var libs = context.Libraries.ToList();

            foreach (var lib in libs)
                Console.WriteLine(String.Join(',', lib.Id, lib.Address));

            ConsoleHelper.WriteService("Tap anything");
            Console.ReadKey();
        }

        public void Update(LibContext context)
        {
            (string addressForUpdate, string newAddress) = ReceiveInputForUpdate();
            var lib = context.Libraries.FirstOrDefault(l => l.Address == addressForUpdate);

            if (lib == null)
            {
                ConsoleHelper.WriteError("This address does'nt exist");
                return;
            }

            lib.Address=newAddress;
        }

        private (string,string) ReceiveInputForUpdate()
        {
            ConsoleHelper.WriteService("Enter address for update");
            string addressForUpdate = Console.ReadLine();

            ConsoleHelper.WriteService("Enter new address");
            string newAddress = Console.ReadLine();

            return (addressForUpdate, newAddress);
        }

        public void Run()
        {
            //not implemented;
        }
    }
}

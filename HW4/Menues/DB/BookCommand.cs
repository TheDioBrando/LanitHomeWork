using ConsoleManagement;
using HW4.Data;
using HW4.Models;

namespace HW4.Menues.DB
{
    internal class BookCommand : ICommand, IOption
    {
        public string OptionName => "Book";

        private DbBooks ReceiveInputForCreate()
        {
            ConsoleHelper.WriteService("Enter book's name");
            string name = Console.ReadLine();

            ConsoleHelper.WriteService("Enter library of the book");
            Guid libId;
            
            while(!Guid.TryParse(Console.ReadLine(), out libId))
            {
                ConsoleHelper.WriteError("Write correct id");
            }

            return new DbBooks
            {
                Id = Guid.NewGuid(),
                Title = name,
                LibraryId = libId
            };
        }

        private string ReceiveInputForDelete()
        {
            ConsoleHelper.WriteService("Enter name for delete");
            string nameForDelete = Console.ReadLine();

            return nameForDelete;
        }

        private (string, string) ReceiveInputForUpdate()
        {
            ConsoleHelper.WriteService("Enter name for update");
            string nameForUpdate = Console.ReadLine();

            ConsoleHelper.WriteService("Enter new name");
            string newName = Console.ReadLine();

            return (nameForUpdate, newName);
        }

        public void Create(LibDbContext context)
        {
            context.Books.Add(ReceiveInputForCreate());
        }

        public void Delete(LibDbContext context)
        {
            var book = context.Books.FirstOrDefault(b => b.Title == ReceiveInputForDelete());

            if(book == null)
            {
                ConsoleHelper.WriteError("Wrong input");
                return;
            }

            context.Books.Remove(book);
        }

        public void Read(LibDbContext context)
        {
            var books = context.Books.ToList();

            foreach (var book in books)
            {
                Console.WriteLine(String.Join(';', book.Id, book.Title, book.LibraryId));
            }

            ConsoleHelper.WriteService("Tap anything");
            Console.ReadKey();
        }

        public void Update(LibDbContext context)
        {
            (string nameForUpdate, string newName) = ReceiveInputForUpdate();

            var book = context.Books.FirstOrDefault(b => b.Title == nameForUpdate);

            if (book == null)
            {
                ConsoleHelper.WriteError("Wrong input");
                return;
            }

            book.Title = newName;
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}

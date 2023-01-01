using ConsoleManagement;
using HW4.Data;
using HW4.Models;

namespace HW4.Menues.DB
{
    internal class BookController : IController, IOption
    {
        public string OptionName => "Book";

        public void Create(LibContext context)
        {
            context.Books.Add(ReceiveInputForCreate());
        }

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

        public void Delete(LibContext context)
        {
            var book = context.Books.FirstOrDefault(b => b.Title == ReceiveInputForDelete());

            if(book == null)
            {
                ConsoleHelper.WriteError("Wrong input");
                return;
            }

            context.Books.Remove(book);
        }

        private string ReceiveInputForDelete ()
        {
            ConsoleHelper.WriteService("Enter name for delete");
            string nameForDelete = Console.ReadLine();

            return nameForDelete;
        }

        public void Read(LibContext context)
        {
            var books = context.Books.ToList();

            foreach (var book in books)
                Console.WriteLine(String.Join(';', book.Id, book.Title, book.LibraryId));

            ConsoleHelper.WriteService("Tap anything");
            Console.ReadKey();
        }

        public void Update(LibContext context)
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
            throw new NotImplementedException();
        }
    }
}

using ConsoleManagement;
using HW4.Data;
using HW4.Models;

namespace HW4.Menues.DB
{
    internal class OrderController : IController,  IOption
    {
        public string OptionName => "Orders";

        public void Create(LibContext context)
        {
            context.Orders.Add(ReceiveInputForCreate());
        }

        private DbOrders ReceiveInputForCreate()
        {
            ConsoleHelper.WriteService("Enter user id");
            Guid userId;

            while (!Guid.TryParse(Console.ReadLine(), out userId))
            {
                ConsoleHelper.WriteError("Write correct id");
            }

            ConsoleHelper.WriteService("Enter book id");
            Guid bookId;

            while (!Guid.TryParse(Console.ReadLine(), out bookId))
            {
                ConsoleHelper.WriteError("Write correct id");
            }

            return new DbOrders
            {
                Id = Guid.NewGuid(),
                BookId = bookId,
                UserId = userId
            };
        }

        public void Delete(LibContext context)
        {
            var order = context.Orders.FirstOrDefault(o => o.UserId == ReceiveInputForDelete());

            if (order == null)
            {
                ConsoleHelper.WriteError("Wrong input");
                return;
            }

            context.Orders.Remove(order);
        }

        private Guid ReceiveInputForDelete()
        {
            ConsoleHelper.WriteService("Enter userid for delete");
            Guid userId;

            while (!Guid.TryParse(Console.ReadLine(), out userId))
            {
                ConsoleHelper.WriteError("Write correct id");
            }

            return userId;
        }

        public void Read(LibContext context)
        {
            var orders = context.Orders.ToList();

            foreach(var order in orders)
            {
                Console.WriteLine(String.Join(',', order.Id, order.UserId, order.BookId));
            }

            ConsoleHelper.WriteService("Tap anything");
            Console.ReadKey();
        }

        public void Update(LibContext context)
        {
            (Guid userId, Guid newUserId) = ReceiveInputForUpdate();

            var order = context.Orders.FirstOrDefault(o => o.UserId == userId);

            if (order == null)
            {
                ConsoleHelper.WriteError("Wrong input");
                return;
            }

            order.UserId = newUserId;
        }

        private (Guid, Guid) ReceiveInputForUpdate()
        {
            ConsoleHelper.WriteService("Enter userid for update");
            Guid userId;

            while (!Guid.TryParse(Console.ReadLine(), out userId))
            {
                ConsoleHelper.WriteError("Write correct id");
            }

            ConsoleHelper.WriteService("Enter userid for update");
            Guid newUserId;

            while (!Guid.TryParse(Console.ReadLine(), out newUserId))
            {
                ConsoleHelper.WriteError("Write correct id");
            }

            return (userId, newUserId);
        }

        public void Run()
        {
            //not implemented;
        }
    }
}

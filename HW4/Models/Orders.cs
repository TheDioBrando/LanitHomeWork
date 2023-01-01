
namespace HW4.Models
{
    public class DbOrders
    {

        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public DbUsers User { get; set; }

        public Guid BookId  { get; set; }
        public DbBooks Book { get; set; } 
    }
}

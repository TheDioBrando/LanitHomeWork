namespace HW4.Models
{
    public class DbBooks
    {
        //public const string TABLE_NAME = "Books";

        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid LibraryId { get; set; }
        public DbLibraries Library { get; set; }

        public ICollection<DbOrders> Orders { get; set; }

        public DbBooks()
        {
                Orders = new HashSet<DbOrders>();
        }
    }
}

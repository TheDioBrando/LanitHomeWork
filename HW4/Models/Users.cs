namespace HW4.Models
{
    public class DbUsers
    {
        //public const string TABLE_NAME = "Users";

        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<DbOrders> Orders { get; set; }

        public DbUsers()
        {
                Orders = new HashSet<DbOrders>();
        }
    }
}

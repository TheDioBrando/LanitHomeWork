
namespace HW4.Models
{
    public class DbLibraries
    {
        //public const string TABLE_NAME = "Libraries";

        public Guid Id { get; set; }
        public string Address { get; set; }
        public ICollection<DbBooks> Books { get; set; }

        public DbLibraries()
        {
            Books = new HashSet<DbBooks>();
        }
    }
}

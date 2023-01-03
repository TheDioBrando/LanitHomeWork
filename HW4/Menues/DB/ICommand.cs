using HW4.Data;

namespace HW4.Menues.DB
{
    public interface ICommand
    {
        public void Create(LibDbContext context);
        public void Read(LibDbContext context);
        public void Update(LibDbContext context);
        public void Delete(LibDbContext context);
    }
}

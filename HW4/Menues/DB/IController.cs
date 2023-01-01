using HW4.Data;

namespace HW4.Menues.DB
{
    public interface IController
    {
        public void Create(LibContext context);
        public void Read(LibContext context);
        public void Update(LibContext context);
        public void Delete(LibContext context);
    }
}

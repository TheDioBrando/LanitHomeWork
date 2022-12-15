using System.Data.SqlClient;

namespace HW3.Menues.Database
{
    internal interface ITable
    {
        public void Create(SqlConnection conn);
        public void Delete(SqlConnection conn);
        public void Update(SqlConnection conn);
        public void Read(SqlConnection conn);
    }
}

using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CTSImp1.DataLayer
{
   public interface IDbContext
    {
        IDbSet<T> Set<T>() where T : class;
        int SaveChanges();
        DbEntityEntry Entry(object o);
        void Dispose();
    }
}

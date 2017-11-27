using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTSImp1.DataLayer
{
  public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteAll(IEnumerable<TEntity> entity);
        IEnumerable<TEntity> GetAll();
        TEntity FindById(object id);
        int ExecuteProcedure(string Query, params object[] Parameters);
        IEnumerable<TEntity> ExecuteProcedureForList(string Query, params object[] Parameters);
        bool Any();
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> ExecuteProcedureForListBD(string Query, params object[] Parameters);
        
    }
}

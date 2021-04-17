using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFunctionsLibrary.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entityToDelete);
        void Delete(object id);
        TEntity GetByID(object id);
        TEntity Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
        void Commit();
    }
}

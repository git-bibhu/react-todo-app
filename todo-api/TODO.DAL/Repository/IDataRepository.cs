using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TODO.DAL.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        Task<int> Add(TEntity entity);
        Task<int> Update(TEntity dbEntity, TEntity entity);
        Task<int> Delete(TEntity entity);
    }
}

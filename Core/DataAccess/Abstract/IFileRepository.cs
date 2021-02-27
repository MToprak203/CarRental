using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess.Abstract
{
    public interface IFileRepository<TEntity>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.Abstract
{
    public interface ICrudService<TEntity> where TEntity: class, IEntity, new()
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        List<TEntity> GetAll();

        TEntity GetById(int entityId);
    }
}

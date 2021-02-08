using Core.Business.Abstract;
using Core.DataAccess.Abstract;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.Concrete
{
    public class CrudManager<TEntity> : ICrudService<TEntity>
        where TEntity : class, IEntity, new()
    {
        public IEntityRepository<TEntity> _entityDal;

        public void Add(TEntity entity)
        {
            _entityDal.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _entityDal.Delete(entity);
        }

        public List<TEntity> GetAll()
        {
            return _entityDal.GetAll();
        }

        public TEntity GetById(int entityId)
        {
            return _entityDal.Get(e => e.Id == entityId);
        }

        public void Update(TEntity entity)
        {
            _entityDal.Update(entity);
        }
    }
}

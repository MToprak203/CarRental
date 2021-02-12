using Business.Abstract;
using Business.Constants;
using Core.DataAccess.Abstract;
using Core.Entities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CrudManager<TEntity> : ICrudService<TEntity>
        where TEntity : class, IEntity, new()
    {
        public IEntityRepository<TEntity> _entityDal;

        public virtual IResult Add(TEntity entity)
        {
            _entityDal.Add(entity);
            return new SuccessfullResult(Messages<TEntity>.Added);
        }

        public virtual IResult Delete(TEntity entity)
        {
            _entityDal.Delete(entity);
            return new SuccessfullResult(Messages<TEntity>.Deleted);
        }

        public virtual IDataResult<List<TEntity>> GetAll()
        {
            return new SuccessfulDataResult<List<TEntity>>(_entityDal.GetAll(), Messages<TEntity>.GotAll);
        }

        public virtual IDataResult<TEntity> GetById(int entityId)
        {
            return new SuccessfulDataResult<TEntity>(_entityDal.Get(e => e.Id == entityId));
        }

        public virtual IResult Update(TEntity entity)
        {
            _entityDal.Update(entity);
            return new SuccessfullResult(Messages<TEntity>.Updated);
        }
    }
}

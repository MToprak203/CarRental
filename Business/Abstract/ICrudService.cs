using Core.Entities;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICrudService<TEntity> where TEntity: class, IEntity, new()
    {
        IResult Add(TEntity entity);

        IResult Update(TEntity entity);

        IResult Delete(TEntity entity);

        IDataResult<List<TEntity>> GetAll();

        IDataResult<TEntity> GetById(int entityId);
    }
}

using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : CrudManager<User>, IUserService
    {
        public UserManager(IUserDal userDal)
        {
            _entityDal = userDal;
        }
    }
}

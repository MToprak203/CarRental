using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : CrudManager<Customer>, ICustomerService
    {
        public CustomerManager(ICustomerDal customerDal)
        {
            _entityDal = customerDal;
        }
    }
}

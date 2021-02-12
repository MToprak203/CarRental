using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : CrudManager<Rental>, IRentalService
    {
        public RentalManager(IRentalDal rentalDal)
        {
            _entityDal = rentalDal;
        }

        public override IResult Add(Rental rental)
        {
            var testRental = _entityDal.Get(r => r.CarId == rental.CarId);
            if(testRental != null && testRental.ReturnDate == null)
            {
                return new ErrorDataResult<Rental>(rental, Messages<Rental>.Unsuccessfull + " -> " + Messages<Car>.NotAvaible);
            }
            _entityDal.Add(rental);
            return new SuccessfullResult(Messages<Rental>.Added);
        }
    }
}

using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : CrudManager<Rental>, IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal) : base(rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public override IResult Add(Rental rental)
        {
            IResult result = BusinessRules<IResult>.Run(CarAvaibleCheck(rental.CarId));

            if(result != null)
            {
                return result;
            }

            _entityDal.Add(rental);
            return new SuccessfullResult(Messages<Rental>.Added);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessfulDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        /****** Business Rules ******/

        private IResult CarAvaibleCheck(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarIsOccupied);
            }
            return new SuccessfullResult();
        }
    }
}

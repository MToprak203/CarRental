using Business.Abstract;
using Business.Constants;
using Core.Business;
using Core.DataAccess.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InFile;
using Entities.Concrete.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : CrudManager<CarImage>, ICarImageService
    {
        ICarImageDal _carImagesDal;
        IFileRepository<CarImage> _systemRepository;
        private string _archivePath = @"InFile\CarImages\";

        public CarImageManager(ICarImageDal carImageDal) : base(carImageDal)
        {
            _carImagesDal = carImageDal;
            _systemRepository = new FileCarImageDal(_archivePath);
        }

        public override IResult Add(CarImage carImage)
        {
            var result = BusinessRules<IResult>.Run(
                CarIsUsedFiveTimesBeforeCheck(carImage.CarId));

            if(result != null)
            {
                return result;
            }

            ConfigureImage(carImage);
            _systemRepository.Add(carImage);
            _entityDal.Add(carImage);
            return new SuccessfullResult(Messages<CarImage>.Added);
        }

        public override IResult Update(CarImage carImage)
        {
            ConfigureImage(carImage);
            _systemRepository.Update(carImage);
            return base.Update(carImage);
        }

        public override IResult Delete(CarImage carImage)
        {
            ConfigureImage(carImage);
            _systemRepository.Delete(carImage);
            return base.Delete(carImage);
        }
        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {
            // var result = BusinessRules<IResult>.Run();
            var resultWithData = BusinessRules<IDataResult<List<CarImage>>>.Run(
                CarHasImageCheck(carId));

            if (resultWithData != null)
            {
                return resultWithData;
            }
            return new SuccessfulDataResult<List<CarImage>>(
                _entityDal.GetAll(r => r.CarId == carId), 
                Messages<CarImage>.GotAll);
        }

        /****** Business Rules ******/

        private IResult CarIsUsedFiveTimesBeforeCheck(int carId)
        {
            var result = _entityDal.GetAll(c => c.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarHaveMoreThanFiveImage);
            }

            return null;
        }

        private IDataResult<List<CarImage>> CarHasImageCheck(int carId)
        {
            var result = _entityDal.GetAll(c => c.CarId == carId).Any();

            if(result)
            {
                return new ErrorDataResult<List<CarImage>>(_carImagesDal.GetDefaultImage(), Messages.CarHasNoImage);
            }
            return null;
        }

        private void ConfigureImage(CarImage carImage)
        {
            string ImageName = "Image";
            carImage.Date = DateTime.Now;
            carImage.Name = ImageName + "_" + (carImage.Id).ToString();
        }


    }
}

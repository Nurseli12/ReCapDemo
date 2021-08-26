using Business.Abstract;
using Business.Conscants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car entity)
        {
            //if(entity.Description.Length<2 && entity.DailyPrice<=0)
            //{
            //    return new ErrorResult(Messages.ProductAddError);
            //}
            _carDal.Add(entity);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Car entity)
        {
            if(entity.Description == "")
            {
                return new ErrorResult(Messages.ProductDeleteError);
            }
            _carDal.Deleted(entity);
            return new SuccessResult(Messages.ProductDelete);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==08)
            {
                return new ErrorDataResult<List<Car>>(_carDal.GetAll(),Messages.ProductErrorListed);
            }
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id),Messages.ProductListed );
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max), Messages.ProductListed);
        }

        public IDataResult<List<Car>> GetCarByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(p => p.BrandId == id),Messages.ProductListed);
        }

        public IDataResult<List<Car>> GetCarByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(p => p.ColorId == id), Messages.ProductListed);
        }

        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(Messages.ProductUpdate);
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetailsBrand()
        {
            return new SuccessDataResult<List<CarDetailsDto>>( _carDal.GetCarDetailsBrand(),Messages.ProductListed);
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetailsColor()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetailsColor(),Messages.ProductListed);
        }


    }
}

using Business.Abstract;
using Business.Conscants;
using Core.Utilities.BusinessRules;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(IsOverflowCarImageCount(carImage.CarId));
            if (result != null)
            {
                return new ErrorResult(result.Message);
            }
            var imageResult = _fileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            try
            {
                var imageDelete = _carImageDal.Get(c => c.Id == carImage.Id);
                if (imageDelete == null)
                {
                    return new ErrorResult(Messages.CarImageNotFound);
                }
                _carImageDal.Deleted(carImage);

                return new SuccessResult(Messages.CarImageDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult("Resim Silinemedi");
            }
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll()); 
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            try
            {
                var imagedelete = _carImageDal.Get(i => i.CarId == carImage.Id);
                if (imagedelete == null)
                {
                    return new ErrorResult("Image couldn't be found");
                }
                var updatedFile = _fileHelper.Update(file,carImage.ImagePath);
                if (!updatedFile.Success)
                {
                    return new ErrorResult(updatedFile.Message);
                }

                carImage.ImagePath = updatedFile.Message;
                _carImageDal.Update(carImage);
                return new SuccessResult(Messages.CarImageUpdated);

            }
            catch (Exception)
            {

                return new ErrorResult("Unexpected Error");
            }
        }
        private IResult IsOverflowCarImageCount(int carId)
        {
            var containt = _carImageDal.GetAll(i => i.CarId == carId);
            if (containt.Count >= 5)
            {
                return new ErrorResult("Overflow");
            }
            return new SuccessResult();
        }
    }
}
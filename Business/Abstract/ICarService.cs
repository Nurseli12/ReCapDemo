using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        IDataResult<List<Car>> GetCarByBrandId(int id);
        IDataResult<List<Car>> GetCarByColorId(int id);
        IDataResult<List<CarDetailsDto>> GetCarDetailsBrand();
        IDataResult<List<CarDetailsDto>> GetCarDetailsColor();
        IResult Add(Car entity);
        IResult Update(Car entity);
        IResult Delete(Car entity);

       
    }
}

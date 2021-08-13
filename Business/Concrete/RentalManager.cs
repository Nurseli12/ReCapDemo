using Business.Abstract;
using Business.Conscants;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
             var results = _rentalDal.GetAll(re => re.CarId == rental.CarId);

             foreach (var result in results)
             {
                 if ((rental.RentDate >= result.RentDate && rental.RentDate <= result.ReturnDate) || (rental.ReturnDate >= result.RentDate && rental.RentDate <= result.ReturnDate))
                 {
                     return new ErrorResult(Messages.isnotAvailable);
                 }

             }
             if (rental.ReturnDate <= rental.RentDate)
             {
                 return new ErrorResult(Messages.isnotAvailable);
             }
 
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.isAvailable);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Deleted(rental);
            return new SuccessResult(Messages.ProductDelete);
        }

        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<RentalDetailsCarDto>> GetDetailsCar()
        {
            return new SuccessDataResult<List<RentalDetailsCarDto>>(_rentalDal.GetRentalDetailsCar());
        }

        public IDataResult<List<RentalDetailsCustomerDto>> GetDetailsCustomer()
        {
            return new SuccessDataResult<List<RentalDetailsCustomerDto>>(_rentalDal.GetRentalDetailsCustomer());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.ProductUpdate);
        }
    }
}

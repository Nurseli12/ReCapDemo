using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> Get(int id);
        IDataResult<List<RentalDetailsCarDto>> GetDetailsCar();
        IDataResult<List<RentalDetailsCustomerDto>> GetDetailsCustomer();
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);


    }
}

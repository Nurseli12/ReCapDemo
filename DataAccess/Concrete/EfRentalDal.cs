using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, DataContext>, IRentalDal
    {
       public List<RentalDetailsCarDto> GetRentalDetailsCar()
        {
            using (DataContext conn = new DataContext())
            {
                var detailsCar = from r in conn.Rentals
                                 join c in conn.Cars
                                 on r.CarId equals c.CarId
                                 select new RentalDetailsCarDto
                                 {
                                     RentalId = r.RentalId,
                                     CarDescription = c.Description,
                                     RentDate = r.RentDate,
                                     ReturnDate = r.ReturnDate

                                 };
                return detailsCar.ToList();

            }
        }

        public List<RentalDetailsCustomerDto> GetRentalDetailsCustomer()
        {
            using (DataContext conn = new DataContext())
            {
                var detailsCustomer = from r in conn.Rentals
                                      join c in conn.Customers
                                      on r.CustomerId equals c.CustomerId
                                      select new RentalDetailsCustomerDto
                                      {
                                          RentalId = r.RentalId,
                                          CustomerName = c.CompanyName,
                                          RentDate = r.RentDate,
                                          ReturnDate =r.ReturnDate
                                      };
                return detailsCustomer.ToList();
            }
        }
    }
}

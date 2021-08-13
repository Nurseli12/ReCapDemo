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
    public class EfCarDal : EfEntityRepositoryBase<Car, DataContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetailsBrand()
        {
            using (DataContext conn = new DataContext())
            {
                var detailsCarBrand = from c in conn.Cars
                                 join b in conn.Brands
                                 on c.BrandId equals b.BrandId
                                 select new CarDetailsDto{
                                     CarId = c.CarId,
                                     BrandName = b.BrandName,
                                     Description = c.Description
                                    
                                 };
                return detailsCarBrand.ToList();

            }
        }

        public List<CarDetailsDto> GetCarDetailsColor()
        {
            using (DataContext conn = new DataContext())
            {
                var detailsCarColor = from c in conn.Cars
                                      join color in conn.Colors
                                      on c.ColorId equals color.ColorId
                                      select new CarDetailsDto
                                      {
                                          CarId = c.CarId,
                                          ColorName = color.ColorName
                                      };
                return detailsCarColor.ToList();

            }
        }
    }
}

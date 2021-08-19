using Business.Concrete;
using DataAccess.Concrete;
using System;

namespace CUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarDetail();
            //GetAll();
            //GetDetailsBrand();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            if (result.Success == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.CustomerId);
                }
            }

            Console.ReadLine();
        }

        private static void GetDetailsBrand()
        {
            CarManager carMAnager = new CarManager(new EfCarDal());
            var result = carMAnager.GetCarDetailsBrand();
            if (result.Success == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.BrandName);
                }
            }
        }

        private static void GetAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.Description);
                }
            }
        }

        private static void CarDetail()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetailsBrand();
            if (result.Success == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.Description + "/" + item.BrandName);
                }

            }
        }
    }
}

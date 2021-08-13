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
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if(result.Success == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.Description);
                }
            }
            Console.ReadLine();
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

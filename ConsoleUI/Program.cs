using Business.Concrete;
using System;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new EfCarDal());
            CarDetailTest();

            //FirstOtomation(carManager);
        }

        private static void CarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
              Console.WriteLine( "Marka : {0} /  Model : {1} /  Renk : {2} /  Günlük Ücret : {3}",car.BrandName, car.CarName, car.ColorName, car.DailyPrice);
            }
        }
        private static void FirstOtomation(CarManager carManager)
        {
            Console.WriteLine("Here are all of our cars you can rent: ");
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine("Marka: {0} Renk: {1} Model Yılı: {2} Günlük Fiyat: {3} Araç Açıklaması: {4}", cars.BrandId, cars.ColorId, cars.ModelYear, cars.DailyPrice, cars.Description);
            }

            Console.WriteLine("------------------------------Rengi 1 Olan Araçlar------------------------------");
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine("Marka: {0} Renk: {1} Model Yılı: {2} Günlük Fiyat: {3} Tanımlama: {4}", car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
            }

            Console.WriteLine("------------------------------Markası 4 Olan Araçlar------------------------------");
            foreach (var car in carManager.GetCarsByBrandId(4))
            {
                Console.WriteLine("Marka: {0} Renk: {1} Model Yılı: {2} Günlük Fiyat: {3} Tanımlama: {4}", car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
            }

            Console.WriteLine("------------------------------Hatalı araç ekleme------------------------------");

            CarManager carManager2 = new CarManager(new EfCarDal());

            carManager2.Add(new Car { BrandId = 2, ColorId = 1, DailyPrice = 500, Description = "A" });
        }
    }
}

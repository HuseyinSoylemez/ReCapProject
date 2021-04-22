using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new InMemoryCarDal());
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}

            //CarTest();

            //ColorTest();

            //BrandTest();

            CarDetailsTest();
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Araba Adı: {0} - Marka: {1} - Renk: {2} - Günlük Fiyat: {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message); 
            }

            
        }

        private static void BrandTest()
        {
            Console.WriteLine("-----------------------M A R K A---------------------------");
            BrandManager brandManager = new BrandManager(new EfBrandDal());
             var result2 = brandManager.GetAll();
            foreach (var brand in result2.Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Araba Adı: {0} - Özellik: {1}",car.CarName,car.Description);
            }
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(carManager.GetCarsById(2).Data.CarName);
            Console.WriteLine("--------------------------------------------------");
            foreach (var car in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine("Araba Adı: {0} - Özellik: {1}", car.CarName, car.Description);
            }
            Console.WriteLine("--------------------------------------------------");
            foreach (var car in carManager.GetByDailyPrice(500, 800).Data)
            {
                Console.WriteLine("Araba Adı: {0} - Özellik: {1}", car.CarName, car.Description);
            }
            Console.WriteLine("--------------------------------------------------");
            foreach (var car in carManager.GetCarsByColorId(3).Data)
            {
                Console.WriteLine("Araba Adı: {0} - Özellik: {1}", car.CarName, car.Description);
            }
            Console.WriteLine("---------------------A R A B A EKLEME-----------------------------");
            carManager.Add(new Car { BrandId = 2, ColorId = 2, CarName = "M", ModelYear = 2010, DailyPrice = 500, Description = "Benzin+Otomatik" });
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Araba Adı: {0} - Özellik: {1}", car.CarName, car.Description);
            }
        }

        private static void ColorTest()
        {
            Console.WriteLine("-----------------------R E N K---------------------------");
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
            Color color1 = new Color();
            color1.ColorName = "Gri";
            colorManager.Add(color1);

            Console.WriteLine("-----------------------R E N K EKLENDİ---------------------------");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("-----------------------R E N K Silindi---------------------------");
            colorManager.Delete(color1);
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
            Console.WriteLine("-----------------------R E N K Güncellendi---------------------------");
            colorManager.Update(new Color { ColorId=1005,ColorName="Mavi"});
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }
    }
}

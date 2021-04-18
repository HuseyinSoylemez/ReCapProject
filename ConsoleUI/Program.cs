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

            CarTest();

            //ColorTest();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Araba Adı: {0} - Özellik: {1}",car.CarName,car.Description);
            }
            Console.WriteLine("--------------------------------------------------");
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine("Araba Adı: {0} - Özellik: {1}", car.CarName, car.Description);
            }
            Console.WriteLine("--------------------------------------------------");
            foreach (var car in carManager.GetByDailyPrice(500, 800))
            {
                Console.WriteLine("Araba Adı: {0} - Özellik: {1}", car.CarName, car.Description);
            }
            Console.WriteLine("--------------------------------------------------");
            foreach (var car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine("Araba Adı: {0} - Özellik: {1}", car.CarName, car.Description);
            }
            Console.WriteLine("---------------------A R A B A EKLEME-----------------------------");
            carManager.Add(new Car { BrandId = 2, ColorId = 2, CarName = "Mondeo", ModelYear = 2010, DailyPrice = 500, Description = "Benzin+Otomatik" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Araba Adı: {0} - Özellik: {1}", car.CarName, car.Description);
            }
        }

        private static void ColorTest()
        {
            Console.WriteLine("-----------------------R E N K---------------------------");
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
            Color color1 = new Color();
            color1.ColorName = "Gri";
            colorManager.Add(color1);

            Console.WriteLine("-----------------------R E N K EKLENDİ---------------------------");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("-----------------------R E N K Silindi---------------------------");
            colorManager.Delete(color1);
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }
    }
}

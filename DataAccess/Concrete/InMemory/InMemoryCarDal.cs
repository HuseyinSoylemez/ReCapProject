using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                 new Car {Id = 1, BrandId = 1, ColorId = 1,CarName="Polo", ModelYear = 2018, DailyPrice = 500, Description = "Benzin"},
                new Car {Id = 2, BrandId = 1, ColorId = 3, CarName="Focus",ModelYear = 2021, DailyPrice = 450, Description = "Benzin"},
                new Car {Id = 3, BrandId = 2, ColorId = 2,CarName="Polo", ModelYear = 2020, DailyPrice = 800, Description = "Benzin+LPG"},
                new Car {Id = 4, BrandId = 3, ColorId = 4, CarName="Polo",ModelYear = 2015, DailyPrice = 600, Description = "Dizel"},
                new Car {Id = 5, BrandId = 3, ColorId = 2, CarName="Polo",ModelYear = 2016, DailyPrice = 300, Description = "Dizel"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
           _cars.Remove(_cars.SingleOrDefault(c=>c.Id==car.Id));
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.Id == carId).ToList();
        }

        public void Update(Car car)
        {
           Car carToUpdate= _cars.SingleOrDefault(c => c.Id == car.Id);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.CarName = car.CarName;
            
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}

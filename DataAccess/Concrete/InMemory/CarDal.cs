using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    public class CarDal : IProductDal
    {
        List<Car> _CarInMemory;

        public CarDal()
        {
            _CarInMemory = new List<Car>{
                new Car(){Id=1,BrandId=1,ColorId=2,ModelYear=2017,DailyPrice=350,Description="Temiz Ford Connect 2017"},
                new Car(){Id=2,BrandId=2,ColorId=2,ModelYear=2005,DailyPrice=150,Description="Az km'li BMW x5 2005"},
                new Car(){Id=3,BrandId=3,ColorId=2,ModelYear=2021,DailyPrice=650,Description="Sıfır Fiat Egea Sedan"},
                new Car(){Id=4,BrandId=4,ColorId=2,ModelYear=2013,DailyPrice=250,Description="Sahibinden Ford focus 2013"},
                new Car(){Id=5,BrandId=5,ColorId=2,ModelYear=2009,DailyPrice=180,Description="İkinci el wolkswagen Gold"}
            };
        }

        public void Add(Car car)
        {
            _CarInMemory.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _CarInMemory.SingleOrDefault(p=>p.Id==car.Id);
            _CarInMemory.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _CarInMemory;
        }

        public Car GetById(int Id)
        {
            return _CarInMemory.SingleOrDefault(p=>p.Id==Id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _CarInMemory.SingleOrDefault(p=>p.Id==car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
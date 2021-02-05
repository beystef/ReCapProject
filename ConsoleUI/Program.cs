using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new CarDal());
            Car car1 = new Car(){Id=1,BrandId=2,ColorId=2,ModelYear=2015,DailyPrice=265,Description="Clio Campus 2007"};
            Car car2 = new Car(){Id=2,BrandId=1,ColorId=2,ModelYear=2017,DailyPrice=350,Description="Temiz Ford Connect 2017"};
            Car car3 = new Car(){Id=3,BrandId=2,ColorId=2,ModelYear=2005,DailyPrice=150,Description="Az km'li BMW x5 2005"};
            Car car4 = new Car(){Id=4,BrandId=3,ColorId=2,ModelYear=2021,DailyPrice=650,Description="Sıfır Fiat Egea Sedan"};
            Car car5 = new Car(){Id=5,BrandId=4,ColorId=2,ModelYear=2013,DailyPrice=250,Description="Sahibinden Ford focus 2013"};
            Car car6 = new Car(){Id=6,BrandId=5,ColorId=2,ModelYear=2009,DailyPrice=180,Description="İkinci el wolkswagen Gold"};
            carManager.Add(car1);
            carManager.Add(car2);
            carManager.Add(car3);
            carManager.Add(car4);
            carManager.Add(car5);
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("Id:{0} - Description:{1} - Daily Price:{2}", car.Id, car.Description, car.DailyPrice);
            }
            Console.WriteLine("------------------------");
            carManager.Add(car6);
            Console.WriteLine("After Adding car has Id 6");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("Id:{0} - Description:{1} - Daily Price:{2}", car.Id, car.Description, car.DailyPrice);
            }
            Console.WriteLine("------------------------");
            carManager.Delete(car1);
            Console.WriteLine("After Deleting Car has Id 1");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("Id:{0} - Description:{1} - Daily Price:{2}", car.Id, car.Description, car.DailyPrice);
            }
            Console.WriteLine("------------------------");
            car3.DailyPrice = 90;
            carManager.Update(car3);
            Console.WriteLine("After Updating car has id 3 with making DailyPrice 90");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("Id:{0} - Description:{1} - Daily Price:{2}", car.Id, car.Description, car.DailyPrice);
            }
            Console.WriteLine("------------------------");
            Console.ReadLine();
        }
    }
}

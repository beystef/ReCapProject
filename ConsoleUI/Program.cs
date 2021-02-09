using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Car car1 = new Car(){Id=1,BrandId=2,ColorId=5,ModelYear=2015,DailyPrice=265,Description="Reno Clio Campus 2007"};
            Car car2 = new Car(){Id=2,BrandId=1,ColorId=1,ModelYear=2017,DailyPrice=350,Description="Temiz Ford Connect 2017"};
            Car car3 = new Car(){Id=3,BrandId=2,ColorId=3,ModelYear=2005,DailyPrice=150,Description="Az km'li BMW x5 2005"};
            Car car4 = new Car(){Id=4,BrandId=3,ColorId=2,ModelYear=2021,DailyPrice=650,Description="Sıfır Fiat Egea Sedan"};
            Car car5 = new Car(){Id=5,BrandId=4,ColorId=6,ModelYear=2013,DailyPrice=250,Description="Sahibinden Ford focus 2013"};
            Car car6 = new Car(){Id=6,BrandId=5,ColorId=4,ModelYear=2009,DailyPrice=180,Description="İkinci el wolkswagen Golf"};
            Color c1 = new Color(){ColorId=1, ColorName="Beyaz"};
            Color c2 = new Color(){ColorId=2, ColorName="Siyah"};
            Color c3 = new Color(){ColorId=3, ColorName="Platinum"};
            Color c4 = new Color(){ColorId=4, ColorName="Gri"};
            Color c5 = new Color(){ColorId=5, ColorName="Lacivert"};
            Color c6 = new Color(){ColorId=6, ColorName="Kırmızı"};
            Brand b1 = new Brand(){BrandId=1, BrandName="Ford"};
            Brand b2 = new Brand(){BrandId=2, BrandName="BMW"};
            Brand b3 = new Brand(){BrandId=3, BrandName="Fiat"};
            Brand b4 = new Brand(){BrandId=4, BrandName="Wolkswagen"};
            Brand b5 = new Brand(){BrandId=5, BrandName="Renault"};
            colorManager.Add(c1);
            colorManager.Add(c2);
            colorManager.Add(c3);
            colorManager.Add(c4);
            colorManager.Add(c5);
            colorManager.Add(c6);
            brandManager.Add(b1);
            brandManager.Add(b2);
            brandManager.Add(b3);
            brandManager.Add(b4);
            brandManager.Add(b5);               
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
            Console.WriteLine("GetCarDetails:");
            foreach (var c in carManager.GetCarDetails())
            {
                Console.WriteLine(" Car Name:{0} \n Brand Name:{1} \n Color Name {2} \n Daily Price:{3}\n\n", 
                                    c.CarName, c.BrandName, c.ColorName, c.DailyPrice);
            }
            Console.WriteLine("------------------------");
            Console.ReadLine();
            colorManager.Delete(c1);
            colorManager.Delete(c2);
            colorManager.Delete(c3);
            colorManager.Delete(c4);
            colorManager.Delete(c5);
            colorManager.Delete(c6);
            carManager.Delete(car2);
            carManager.Delete(car3);
            carManager.Delete(car4);
            carManager.Delete(car5);
            carManager.Delete(car6);
            brandManager.Delete(b1);
            brandManager.Delete(b2);
            brandManager.Delete(b3);
            brandManager.Delete(b4);
            brandManager.Delete(b5);
            Console.ReadLine();
        }
    }
}

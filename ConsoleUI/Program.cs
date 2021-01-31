using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new CarDal());
            Console.WriteLine("---GetAll---");
            foreach (Car car in productManager.GetAll())
            {
                Console.WriteLine("Id:{0} - Description:{1}", car.Id, car.Description);
            }
            Console.WriteLine("------------------------");
            Car car1 = new Car(){Id=6,ColorId=2,BrandId=2,ModelYear=2015,DailyPrice=265,Description="Clio Campus 2007"};
            productManager.Add(car1);
            Console.WriteLine("After Adding car has Id 6");
            foreach (Car car in productManager.GetAll())
            {
                Console.WriteLine("Id:{0} - Description:{1}", car.Id, car.Description);
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("---GetById(Id=1)---");
            Car car2 = productManager.GetById(1);
            Console.WriteLine("Id:{0} - Description:{1}", car2.Id, car2.Description);
            Console.WriteLine("------------------------");
            productManager.Delete(car2);
            Console.WriteLine("After Deleting Car has Id 1");
            foreach (Car car in productManager.GetAll())
            {
                Console.WriteLine("Id:{0} - Description:{1}", car.Id, car.Description);
            }
            Console.WriteLine("------------------------");
            Car car3 = productManager.GetById(3);
            Console.WriteLine("Id:{0} - DailyPrice:{1}", car3.Id, car3.DailyPrice);
            car3.DailyPrice = 90;
            productManager.Update(car3);
            Console.WriteLine("After Update with making DailyPrice 90");
            Car carx = productManager.GetById(3);
            Console.WriteLine("Id:{0} - DailyPrice:{1}", carx.Id, carx.DailyPrice);
            Console.WriteLine("------------------------");
            Console.ReadLine();
        }
    }
}

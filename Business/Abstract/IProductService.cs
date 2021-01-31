using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Car> GetAll();
        Car GetById(int Id);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
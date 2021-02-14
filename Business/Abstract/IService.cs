using System.Collections.Generic;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IService<T>
    {
        IDataResult<List<T>> GetAll();
        IResult Add(T product);
        IResult Update(T product);
        IResult Delete(T product);
        IDataResult<T> GetById(int productId);
    }
}
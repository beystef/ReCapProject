using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(p=>p.ColorId==colorId), Messages.ProductsListed);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
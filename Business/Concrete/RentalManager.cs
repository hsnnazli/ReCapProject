using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {

            _rentalDal.Add(rental);
            return new SuccesResult(Messages.EntityAdded);

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccesResult(Messages.EntityDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.EntitiyListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id), Messages.EntitiyListed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccesResult(Messages.EntityUpdated);
        }
    }
}

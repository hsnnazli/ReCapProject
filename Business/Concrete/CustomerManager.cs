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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {

            _customerDal.Add(customer);
            return new SuccesResult(Messages.EntityAdded);

        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccesResult(Messages.EntityDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.EntitiyListed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id), Messages.EntitiyListed);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccesResult(Messages.EntityUpdated);
        }
    }
}

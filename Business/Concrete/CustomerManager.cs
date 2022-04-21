﻿using Business.Abstract;
using Business.Constants;
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

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessDataResult<Customer>(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new Result(true, Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new DataResult<List<Customer>>(_customerDal.GetAll(), true, Messages.CustomersListed);
        }

        public IDataResult<Customer> GetById(int CustomerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.UserId == CustomerId));
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new Result(true);
        }

    }
}

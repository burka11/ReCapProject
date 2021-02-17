using Business.Abstract;
using Business.Constants;
using Core.Results;
using Core.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
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
            if (customer.CustomerName.Length<0)
            {
                return new ErrorResult(CustomerMessages.CompanyNameInvalid);
                
            }
            _customerDal.Add(customer);
            return new SuccessResult(CustomerMessages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(CustomerMessages.CustomerAdded);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
        }

        public IDataResult<List<Customer>> GetCustomersById(int id)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c=> c.CustomerId == id));
        }

        public IResult Update(Customer customer)
        {
            if (customer.CustomerName.Length > 0)
            {
                _customerDal.Update(customer);
                return new SuccessResult(CustomerMessages.CustomerUpdated);
            }
            else
            {
                return new ErrorResult(CustomerMessages.CompanyNameInvalid);
            }
        }
    }
}

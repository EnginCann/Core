using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate != null)
            {
                _rentalDal.Add(rental);
                return new SuccessDataResult<Rental>(Messages.RentalAdded);
            }
            else
                return new ErrorDataResult<Rental>(Messages.RentalFailed);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new Result(true, Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new DataResult<List<Rental>>(_rentalDal.GetAll(), true, Messages.RentalsListed);
        }

        public IDataResult<Rental> GetById(int RentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == RentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetCarDetails()
        {
           
                var result = _rentalDal.GetDetails();
                return new SuccessDataResult<List<RentalDetailDto>>(result);
            
        }

        public IResult Update(Rental rental)
        {
            if (rental.ReturnDate != null)
            {
                _rentalDal.Update(rental);
                return new SuccessDataResult<Rental>(Messages.RentalAdded);
            }
            else
                return new ErrorDataResult<Rental>(Messages.RentalFailed);
        }

    }
}

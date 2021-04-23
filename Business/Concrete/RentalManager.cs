using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null);
            if (result.Any())
            {
                return new ErrorResult(Messages.RentalAddedError);
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.Added);
            }
            
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalid)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalid));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
         
                Thread.Sleep(1000);
                return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
            

            
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
    }
}

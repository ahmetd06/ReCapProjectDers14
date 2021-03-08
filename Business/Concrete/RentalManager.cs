using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        [SecuredOperation("admin,rental.add")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        [SecuredOperation("admin,rental.update")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        [SecuredOperation("admin,rental.delete")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listelendi);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id));
        }

       

        public IResult CheckReturnDate(int carId)
        {
            var result = _rentalDal.GetAll(p => p.CarId == carId && p.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        [ValidationAspect(typeof(RentalValidator))]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult RentACar(Car car, Customer customer)
        {
            if (CheckReturnDate(car.Id) is SuccessResult)
            {
              _rentalDal.Add(new Rental { CarId = car.Id, CustomerId = customer.Id, RentDate = DateTime.Now.Date, ReturnDate = null });
                return new SuccessResult(Messages.AracKiralandı);
            }
            return new ErrorResult(Messages.AracKiralanamadı +  " : " +Messages.AracKirada);
        }

        public IDataResult<List<RentDetailDto>> GetRentDetailList()
        {
            return new SuccessDataResult<List<RentDetailDto>>(_rentalDal.GetAllRentDetails());
        }

        public IResult UpdateReturnDate(int rentId, DateTime returnDate)
        {
            Rental rental = _rentalDal.Get(p => p.Id == rentId);
            rental.ReturnDate = returnDate;
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}

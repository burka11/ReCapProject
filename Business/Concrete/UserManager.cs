using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userdal)
        {

            _userDal = userdal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(UserMessages.UserAdded);

        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new ErrorResult(UserMessages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<List<UserDetailDto>> GetUserDetails()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails());
        }

        public IDataResult<List<User>> GetUsersById(int id)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.UserId == id));
        }

        public IResult Update(User user)
        {
            if (user.FirstName.Length > 3 && user.LastName.Length > 2 && user.Email != null && user.Password.Length >= 4)
            {
                _userDal.Update(user);
                return new SuccessResult(UserMessages.UserUpdated);
            }
            else
            {
                return new ErrorResult(UserMessages.UserNameInvalid);
            }
        }
    }
}

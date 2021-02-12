using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<User> GetByEmailAndPassword(string email, string password)
        {
            var result = _userDal.Get(u => u.Email == email && u.Password == password);
            if (result != null)
            {
                return new SuccessDataResult<User>(result, Messages.UserVerified);
            }
            return new ErrorDataResult<User>(result, Messages.UserNotVerified);
        }

        public IDataResult<int> GetUserId(User user)
        {
            return new SuccessDataResult<int>(_userDal.Get(u => u.FirstName == user.FirstName && u.LastName == user.LastName && u.Email == user.Email).Id);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}

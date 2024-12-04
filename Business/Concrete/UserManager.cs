using Business.Abstract;
using Core.Entities.Concrete;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager(IUserDal userDal) : IUserService
    {
        private readonly IUserDal _userDal = userDal;
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public IDataResult<User> GetById(int userId)
        {
            var result = _userDal.Get(u => u.Id == userId);
            if (result != null)
            {
                return new SuccessDataResult<User>(result,"loaded");    
            }
            else return new ErrorDataResult<User>(result, "tapilmadi");

        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        //public List<OperationClaim> GetClaims(User user)
        //{
        //    return _userDal.GetClaims(user);
        //}
    }
}

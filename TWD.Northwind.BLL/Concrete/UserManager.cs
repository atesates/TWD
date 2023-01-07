using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Core.Entities.Concrete;
using TWD.Northwind.BLL.Abstract;
using TWD.Northwind.DAL.Abstract;
using TWD.Northwind.Entities.Concrete;

namespace TWD.Northwind.BLL.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u=>u.Email == email);   
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Core.Entities.Concrete;
using TWD.Northwind.Entities.Concrete;

namespace TWD.Northwind.BLL.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);

        void Add(User user);

        User GetByMail(string email);
    }
}

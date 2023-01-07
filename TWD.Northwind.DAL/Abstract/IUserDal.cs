using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Core.DataAccess;
using TWD.Core.Entities.Concrete;
using TWD.Northwind.Entities.Concrete;

namespace TWD.Northwind.DAL.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Core.DataAccess.EntityFramework;
using TWD.Core.Entities.Concrete;
using TWD.Northwind.DAL.Abstract;
using TWD.Northwind.Entities.Concrete;

namespace TWD.Northwind.DAL.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            //This can be done with Dto:
            using(var context = new NorthwindContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

                return result.ToList();
            }
        }
    }
}

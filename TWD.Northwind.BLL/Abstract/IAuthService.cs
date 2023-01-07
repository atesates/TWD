using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Core.Entities.Concrete;
using TWD.Core.Utilities.Results;
using TWD.Core.Utilities.Security.Jwt;
using TWD.Northwind.Entities.Dtos;

namespace TWD.Northwind.BLL.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);

        IDataResult<User> Login(UserForLoginDto userForLoginDto);

        IResult UserExists(string email);

        IDataResult<AccessToken> CreateAccesToken(User user);

    }
}

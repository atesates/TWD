using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWD.Core.Utilities.Security.Jwt
{
    public class TokenOptions
    {
        public string Audience { get; set; }//who will use tokens

        public string Issuer { get; set; }//who generate tokens

        public int AccessTokenExpiration { get; set; }

        public string SecurityKey { get; set; } 
    }
}

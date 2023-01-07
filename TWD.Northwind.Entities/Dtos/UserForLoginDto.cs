using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Core.Entities;

namespace TWD.Northwind.Entities.Dtos
{
    public class UserForLoginDto :IDto
    {
        public string Email  { get; set; }
        public string Password { get; set; }
    }
}

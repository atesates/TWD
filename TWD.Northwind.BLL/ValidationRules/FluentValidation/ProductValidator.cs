using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Northwind.BLL.Constants;
using TWD.Northwind.Entities.Concrete;

namespace TWD.Northwind.BLL.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage(ValidationsMessages.ProductNameCanNotBeEmpty);
            RuleFor(p => p.ProductName).Length(2, 30).WithMessage(ValidationsMessages.ProductNameLengthCanNotBeLessThan2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(1);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(19).When(p => p.CategoryID == 1);
            RuleFor(p => p.ProductName).Must(StartWithA);



        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}

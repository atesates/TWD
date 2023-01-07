
using Castle.DynamicProxy;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Core.Utilities.Interceptors;
using TWD.Core.Utilities.Messages;
using TWD.Core.CrossCuttingConcerns.Validation;

namespace TWD.Northwind.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//if validatorType is not an IValidator type
            {
                throw new Exception(AspectMessages.WrongValidationType);
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//created insatance in memory using reflection method
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//ProductValidator:AbstractValidator<Product>, [0] => Product for example
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //validate all entities in  product public. IResult Add(Product product)
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}

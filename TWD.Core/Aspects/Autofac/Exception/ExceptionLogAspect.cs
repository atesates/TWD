using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Core.CrossCuttingConcerns.Logging.Log4Net;
using TWD.Core.CrossCuttingConcerns.Logging;
using TWD.Core.Utilities.Interceptors;
using TWD.Core.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using TWD.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace TWD.Core.Aspects.Autofac.Exception
{
    public class ExceptionLogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;
        private IHttpContextAccessor _httpContextAccessor;

        public ExceptionLogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }
        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            LogDetailWithException logDetailWithException = GetLogDetail(invocation);
            logDetailWithException.ExceptionMessage = e.Message;
            _loggerServiceBase.Error(logDetailWithException);
        }

        private LogDetailWithException GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();

            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name,
                    User = _httpContextAccessor.HttpContext.User.Identity.Name

                });
            }

            var logDetailWithException = new LogDetailWithException
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetailWithException;
        }
    }
}

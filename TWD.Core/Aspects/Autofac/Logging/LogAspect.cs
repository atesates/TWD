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

namespace TWD.Core.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;
        private IHttpContextAccessor _httpContextAccessor;

        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                 //throw new Exception(AspectMessages.WrongLoggerType);
                 throw new ArgumentException(AspectMessages.WrongLoggerType);
            }

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            _loggerServiceBase.Info(GetLogDetail(invocation));
        }

        private LogDetail GetLogDetail(IInvocation invocation)
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
                }) ;
            }

            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetail;
        }
    }
}

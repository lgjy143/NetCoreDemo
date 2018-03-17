using IOC.Application;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOC
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly LogService _logService;
        public ExceptionFilter(LogService logService)
        {
            _logService = logService;
        }
        public void OnException(ExceptionContext context)
        {
            _logService.Error(context.Exception.Message);
        }
    }
}

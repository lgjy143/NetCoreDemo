using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IOC.Application;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IOC.Controllers
{
    public class Demo2Controller : Controller
    {
        private readonly IDemo2Service _demoService;

        public Demo2Controller(IDemo2Service demoService)
        {
            _demoService = demoService;
        }

        public IActionResult Index()
        {
            return Json(_demoService.Test());
        }
    }
}

using IOC.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOC.Controllers
{
    public class DemoController : Controller
    {
        private readonly DemoService _demoService;

        public DemoController(DemoService demoService)
        {
            _demoService = demoService;
        }

        public IActionResult Index()
        {
            return Json(_demoService.Test());
        }
    }
}

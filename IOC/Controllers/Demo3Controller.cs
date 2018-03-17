using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IOC.Services;

namespace IOC.Controllers
{
    public class Demo3Controller : Controller
    {
        private readonly IDemo3Service _demoService;
        public Demo3Controller(IDemo3Service demoService)
        {
            _demoService = demoService;
        }
        public IActionResult Index()
        {
            return Json(_demoService.Test());
            //return View();
        }
    }
}
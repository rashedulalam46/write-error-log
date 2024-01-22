using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WriteErrorLog.Models;
using WriteErrorLog.Service;

namespace WriteErrorLog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ErrorLogService _errorLogService;

        public HomeController(
           ErrorLogService errorLogService
           )
        {

            _errorLogService = errorLogService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            try
            {
                var a = 4;
                var b = 0;
                var c = a / b;
                return View("Index");
            }
            catch (Exception ex)
            {
                _errorLogService.WriteErrorLog(ex.ToString());
                return View("Index");
            }

        }
    }
}

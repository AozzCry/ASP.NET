using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kolokwium.ViewModel;
using Microsoft.Extensions.Localization;

namespace Kolokwium.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ILogger logger, IMapper mapper, IStringLocalizer localizer)
            : base(logger, mapper, localizer)
        {
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

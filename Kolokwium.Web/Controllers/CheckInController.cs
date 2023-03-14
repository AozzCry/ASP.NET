using AutoMapper;
using Kolokwium.Services.Interfaces;
using Kolokwium.ViewModel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Kolokwium.Web.Controllers
{
    public class CheckInController : BaseController
    {
        private readonly ICheckInService _checkISnervice;

        public CheckInController(ILogger logger, IMapper mapper, IStringLocalizer localizer, ICheckInService checkISnervice) : base(logger, mapper, localizer)
        {
            _checkISnervice = checkISnervice;
        }

        // GET: CheckIn
        public ActionResult Index()
        {
            return View(_checkISnervice.GetCheckIns());
        }

        // GET: CheckIn/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CheckIn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheckIn/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CheckInVm checkInVm)
        {
            try
            {
                _checkISnervice.AddCheckIn(checkInVm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckIn/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CheckIn/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckIn/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CheckIn/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

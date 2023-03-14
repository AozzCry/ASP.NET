using AutoMapper;
using Kolokwium.Services.Interfaces;
using Kolokwium.ViewModel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Kolokwium.Web.Controllers
{
    public class RoomController : BaseController
    {
        private readonly IRoomService _roomService;
        public RoomController(ILogger logger, IMapper mapper, IStringLocalizer localizer, IRoomService roomService) : base(logger, mapper, localizer)
        {
            _roomService = roomService;
        }

        // GET: RoomController
        public ActionResult Index()
        {
            return View(_roomService.GetRooms());
        }

        // GET: RoomController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoomController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomVm room)
        {
            try
            {
                _roomService.AddRoom(room);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoomController/Edit/5
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

        // GET: RoomController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoomController/Delete/5
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

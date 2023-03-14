using AutoMapper;
using Kolokwium.Model;
using Kolokwium.Services.Interfaces;
using Kolokwium.ViewModel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Kolokwium.Web.Controllers
{
    public class ClientController : BaseController
    {
        private readonly IClientService _clientService;
        private readonly UserManager<User> _userManager;
        public ClientController(ILogger logger, IMapper mapper, IStringLocalizer localizer, UserManager<User> userManager, IClientService clientService) : base(logger, mapper, localizer)
        {
            _clientService = clientService;
            _userManager = userManager;
        }

        // GET: ClientController
        public ActionResult Index()
        {
            return View(_clientService.GetClients());
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View(_clientService.GetClient(x => x.Id == id));
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientVm clientVm)
        {
            try
            {
                _clientService.AddClient(clientVm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_clientService.GetClient(x => x.Id == id));
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClientVm clientVm)
        {
            try
            {
                _clientService.UpdateClient(id, clientVm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            _clientService.DeleteClient(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult AddCheckInToClient(int ClientId)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCheckInToClient(AddCheckInToClientVm addCheckInToClientVm)
        {
            try
            {
                _clientService.AddCheckInToClient(addCheckInToClientVm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}

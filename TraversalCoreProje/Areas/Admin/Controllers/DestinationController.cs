﻿using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(Destination p)
        {
            p.Description = "asdsa";
            _destinationService.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestination(int id)
        {
            var value = _destinationService.TGetByID(id);
            _destinationService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var value = _destinationService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateDestination(Destination p)
        {
            p.Description = "asdsa";
            _destinationService.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}

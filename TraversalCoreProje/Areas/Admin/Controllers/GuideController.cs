using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            guide.Status = true;
            _guideService.TAdd(guide);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var value = _guideService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {  
            _guideService.TUpdate(guide);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeToTrue(int id)
        {
            var value = _guideService.TGetByID(id);
            value.Status = true;
            _guideService.TUpdate(value);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeToFalse(int id)
        {
            var value = _guideService.TGetByID(id);
            value.Status = false;
            _guideService.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}

using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private IAppUserService _userService;
        private IReservationService _reservationService;

        public UserController(IAppUserService userService, IReservationService reservationService)
        {
            _userService = userService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var userList = _userService.TGetList();
            return View(userList);
        }
        public IActionResult DeleteUser(int id)
        {
            var value = _userService.TGetByID(id);
            _userService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var value = _userService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
            _userService.TUpdate(appUser);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CommentUser(int id)
        {
            var value = _userService.TGetList();
            return View(value);
        }
        [HttpGet]
        public IActionResult ReservationUser(int id)
        {
            var values = _reservationService.GetListWithReservationByAcceptedl(id);
            return View(values);
        }
    }
}

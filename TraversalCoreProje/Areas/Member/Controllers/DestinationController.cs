using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager manager = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var vaules = manager.TGetList();
            return View(vaules);
        }
    }
}

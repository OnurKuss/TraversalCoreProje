using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.AdminDashboard
{
    public class _Card1Statistic:ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.TurSayisi = context.Destinations.Count();
            ViewBag.MisafirSayisi = context.Users.Count();
            return View();
        }
    }
}

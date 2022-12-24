using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardChartPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.bugday = 88;
            ViewBag.arpa = 150;
            ViewBag.mercimek = 120;
            ViewBag.pirinc = 45;
            ViewBag.mısır = 65;
            return View();
        }
    }
}

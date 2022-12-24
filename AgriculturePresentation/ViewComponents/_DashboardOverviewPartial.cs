using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardOverviewPartial : ViewComponent
    {
        Context context = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.employeeCount = context.Employees.Count();
            ViewBag.serviceCount = context.Services.Count();
            ViewBag.messageCount = context.Contacts.Count();
            ViewBag.announcementCount = context.Announcements.Count();

            ViewBag.announcementTrueCount = context.Announcements.Where(x => x.Status == true).Count();
            ViewBag.announcementFalseCount = context.Announcements.Where(x => x.Status == false).Count();
            ViewBag.imageCount = context.Images.Count();
            ViewBag.userCount = context.Users.Count();

            return View();
        }
    }
}

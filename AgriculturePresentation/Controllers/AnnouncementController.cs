using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementSevice;

        public AnnouncementController(IAnnouncementService announcementSevice)
        {
            _announcementSevice = announcementSevice;
        }

        public IActionResult Index()
        {
            var values = _announcementSevice.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncement(Announcement announcement)
        {
            AnnouncementValidation validationRules = new AnnouncementValidation();
            ValidationResult validationResult = validationRules.Validate(announcement);

            if (validationResult.IsValid)
            {
                announcement.Status = false;
                _announcementSevice.Add(announcement);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var value = _announcementSevice.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateAnnouncement(Announcement announcement)
        {
            AnnouncementValidation validationRules = new AnnouncementValidation();
            ValidationResult validationResult = validationRules.Validate(announcement);

            if (validationResult.IsValid)
            {
                _announcementSevice.Update(announcement);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public IActionResult DeleteAnnouncement(int id)
        {
            var value = _announcementSevice.GetById(id);
            _announcementSevice.Delete(value);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateAnnouncementStatusToTrue(int id)
        {
            _announcementSevice.AnnouncementStatusToTrue(id);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateAnnouncementStatusToFalse(int id)
        {
            _announcementSevice.AnnouncementStatusToFalse(id);
            return RedirectToAction("Index");
        }
    }
}

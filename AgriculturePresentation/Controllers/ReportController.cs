using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AgriculturePresentation.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticReport()
        {
            ExcelPackage excelPackage = new ExcelPackage();
            var workBook = excelPackage.Workbook.Worksheets.Add("WorkBook");

            workBook.Cells[1, 1].Value = "Ad";
            workBook.Cells[1, 2].Value = "Kategori";
            workBook.Cells[1, 3].Value = "Stok";

            workBook.Cells[2, 1].Value = "Mercimek";
            workBook.Cells[2, 2].Value = "Bakliyat";
            workBook.Cells[2, 3].Value = "7855";

            workBook.Cells[3, 1].Value = "Buğday";
            workBook.Cells[3, 2].Value = "Bakliyat";
            workBook.Cells[3, 3].Value = "3551";

            workBook.Cells[4, 1].Value = "Havuç";
            workBook.Cells[4, 2].Value = "Sebze";
            workBook.Cells[4, 3].Value = "8954";

            var bytes = excelPackage.GetAsByteArray();

            return File(bytes, "application/vnd.openxmlformat-officedocument.spreadsheedml.sheet", "Report.xlsx");
        }

        public IActionResult ContactReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("WorkBook");
                workSheet.Cell(1, 1).Value = "ID";
                workSheet.Cell(1, 2).Value = "Ad";
                workSheet.Cell(1, 3).Value = "E-Posta";
                workSheet.Cell(1, 4).Value = "Mesaj";
                workSheet.Cell(1, 5).Value = "Tarih";

                int contactRowCount = 2;
                foreach (var item in ContactList())
                {
                    workSheet.Cell(contactRowCount, 1).Value = item.ContactId;
                    workSheet.Cell(contactRowCount, 2).Value = item.Name;
                    workSheet.Cell(contactRowCount, 3).Value = item.Email;
                    workSheet.Cell(contactRowCount, 4).Value = item.Message;
                    workSheet.Cell(contactRowCount, 5).Value = item.Date;
                    contactRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformat-officedocument.spreadsheedml.sheet", "Report.xlsx");
                }
            }
        }

        public List<Contact> ContactList()
        {
            List<Contact> contacts = new List<Contact>();
            using (var context = new Context())
            {
                contacts = context.Contacts.Select(x => new Contact
                {
                    ContactId = x.ContactId,
                    Name = x.Name,
                    Email = x.Email,
                    Date = x.Date,
                    Message = x.Message
                }).ToList();
            }

            return contacts;
        }

        public IActionResult AnnouncementReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("WorkBook");
                workSheet.Cell(1, 1).Value = "ID";
                workSheet.Cell(1, 2).Value = "Başlık";
                workSheet.Cell(1, 3).Value = "Açıklama";
                workSheet.Cell(1, 4).Value = "Tarih";

                int announcementRowCount = 2;
                foreach (var item in AnnouncementList())
                {
                    workSheet.Cell(announcementRowCount, 1).Value = item.AnnouncementId;
                    workSheet.Cell(announcementRowCount, 2).Value = item.Title;
                    workSheet.Cell(announcementRowCount, 3).Value = item.Description;
                    workSheet.Cell(announcementRowCount, 4).Value = item.Date;
                    announcementRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformat-officedocument.spreadsheedml.sheet", "Report.xlsx");
                }
            }
        }

        public List<Announcement> AnnouncementList()
        {
            List<Announcement> announcements = new List<Announcement>();
            using (var context = new Context())
            {
                announcements = context.Announcements.Select(x => new Announcement
                {
                    AnnouncementId = x.AnnouncementId,
                    Title = x.Title,
                    Description = x.Description,
                    Date = x.Date
                }).ToList();
            }

            return announcements;
        }
    }
}

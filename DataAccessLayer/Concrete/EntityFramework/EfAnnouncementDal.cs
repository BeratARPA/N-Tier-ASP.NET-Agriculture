using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfAnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal
    {
        public void AnnouncementStatusToFalse(int id)
        {
            using var context = new Context();
            Announcement announcement = context.Announcements.Find(id);
            announcement.Status = false;
            context.Entry(announcement).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void AnnouncementStatusToTrue(int id)
        {
            using var context = new Context();
            Announcement announcement = context.Announcements.Find(id);
            announcement.Status = true;
            context.Entry(announcement).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

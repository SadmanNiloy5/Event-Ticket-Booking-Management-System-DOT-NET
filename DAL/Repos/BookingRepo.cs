using DAL.EF;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repos
{
    public class BookingRepo
    {
        EventTicketBookingDbContext db;

        public BookingRepo(EventTicketBookingDbContext db)
        {
            this.db = db;
        }

        public bool Create(Booking b)
        {
            db.Bookings.Add(b);

            return db.SaveChanges() > 0;
        }

        public List<Booking> Get()
        {
            return db.Bookings
                .Include(b => b.User)
                .Include(b => b.Event)
                .ToList();
        }

        public Booking Get(int id)
        {
            return db.Bookings.Find(id)!;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);

            db.Bookings.Remove(exobj);

            return db.SaveChanges() > 0;
        }
    }
}
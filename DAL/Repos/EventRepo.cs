using DAL.EF;
using DAL.EF.Tables;

namespace DAL.Repos
{
    public class EventRepo
    {
        EventTicketBookingDbContext db;

        public EventRepo(EventTicketBookingDbContext db)
        {
            this.db = db;
        }

        public bool Create(Event e)
        {
            db.Events.Add(e);

            return db.SaveChanges() > 0;
        }

        public List<Event> Get()
        {
            return db.Events.ToList();
        }

        public Event Get(int id)
        {
            return db.Events.Find(id)!;
        }

        public bool Update(Event e)
        {
            var exobj = Get(e.Id);

            db.Entry(exobj).CurrentValues.SetValues(e);

            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);

            db.Events.Remove(exobj);

            return db.SaveChanges() > 0;
        }

        public List<Event> Search(string txt)
        {
            return db.Events
                .Where(e => e.Name.Contains(txt)
                || e.Location.Contains(txt))
                .ToList();
        }
    }
}
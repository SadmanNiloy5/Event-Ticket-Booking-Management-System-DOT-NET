using DAL.EF;
using DAL.EF.Tables;

namespace DAL.Repos
{
    public class UserRepo
    {
        EventTicketBookingDbContext db;

        public UserRepo(EventTicketBookingDbContext db)
        {
            this.db = db;
        }

        public bool Create(User u)
        {
            db.Users.Add(u);

            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public User Authenticate(string email, string password)
        {
            return db.Users.FirstOrDefault(u =>
                u.Email.Equals(email)
                && u.Password.Equals(password))!;
        }
    }
}
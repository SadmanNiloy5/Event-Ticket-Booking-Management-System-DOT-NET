using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class DashboardController : Controller
    {
        EventService eventService;

        BookingService bookingService;

        public DashboardController
        (
            EventService eventService,
            BookingService bookingService
        )
        {
            this.eventService = eventService;

            this.bookingService = bookingService;
        }

        public IActionResult Index()
        {
               var role = HttpContext.Session.GetString("Role");

            if (role == null || !role.Equals("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }

                var events = eventService.Get();

            var bookings = bookingService.Get();

                   ViewBag.TotalEvents = events.Count();

            ViewBag.TotalBookings = bookings.Count();

                ViewBag.TotalRevenue =
                  bookings.Sum(b => b.TotalAmount);

             ViewBag.SoldOutEvents =
                         events.Where(e => e.Status.Equals("Sold Out")).Count();

            return View();
        }
    }
}


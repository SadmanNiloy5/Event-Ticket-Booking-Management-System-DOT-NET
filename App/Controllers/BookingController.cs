using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class BookingController : Controller
    {
        BookingService bookingService;

         EventService eventService;

        public BookingController
        (
            BookingService bookingService,
            EventService eventService
        )
        {
            this.bookingService = bookingService;

             this.eventService = eventService;
        }

        [HttpGet]
             public IActionResult Create()
        {
            ViewBag.Events = eventService.Get();

              return View(new BookingDTO());
        }

        [HttpPost]
        public IActionResult Create(BookingDTO b)
        {
               if (ModelState.IsValid)
            {
                 var res = bookingService.Create(b);

                 if (res == true)
                {
                    TempData["msg"] = "Booking Successful";

                        return RedirectToAction("Index");
                }
                else
                {
                      TempData["msg"] = "Seats Not Available";
                }
            }

               ViewBag.Events = eventService.Get();

              return View(b);
        }

           public IActionResult Index()
        {
            var data = bookingService.Get();

               return View(data);
        }

        [HttpGet]
          public IActionResult Delete(int id)
        {
              var data = bookingService.Get(id);

            return View(data);
        }

        [HttpPost]
            public IActionResult Delete(int id, string Decision)
        {
                if (Decision.Equals("Yes"))
            {
                var res = bookingService.Delete(id);

                if (res == true)
                {
                     return RedirectToAction("Index");
                }
            }

             return RedirectToAction("Index");
        }
    }
}
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class EventController : Controller
    {
        EventService eventService;

        public EventController(EventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public IActionResult Create()
        {
               return View(new EventDTO());
        }

        [HttpPost]
           public IActionResult Create(EventDTO e)
        {
            if (ModelState.IsValid)
            {
                    var res = eventService.Create(e);

                if (res == true)
                 {
                     return RedirectToAction("Index");
                }
            }

            return View(e);
        }

        public IActionResult Index()
        {
               var data = eventService.Get();
 
            return View(data);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
              var data = eventService.Get(id);

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(EventDTO e)
        {
                if (ModelState.IsValid)
            {
                var res = eventService.Update(e);

                if (res == true)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(e);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
                var data = eventService.Get(id);

            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(int id, string Decision)
        {
            if (Decision.Equals("Yes"))
            {
                     var res = eventService.Delete(id);

                 if (res == true)
                {
                      return RedirectToAction("Index");
                }
            }

             return RedirectToAction("Index");
        }

        [HttpGet]
          public IActionResult Search()
        {
              return View();
        }

        [HttpPost]
        public IActionResult Search(string txt)
        {
               var data = eventService.Search(txt);

             return View("Index", data);
        }
    }
}
using Concretos.Data;
using Concretos.Migrations;
using Concretos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Concretos.Controllers
{
    public class ReactiveController : Controller
    {

        private readonly ApplicationDbContext _db;
        private List<Reactive> Reactives;
        private Reactive Reactive { get; set; }

        public ReactiveController(ApplicationDbContext db)
        {
            this._db = db;

            this.LoadReactives();
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["Reactives"] = this.Reactives;

            return View();
        }

        [HttpGet("/Reactive/Management/{reactiveId}")]
        public async Task<IActionResult> Management(int reactiveId)
        {
            this.Reactive = new Reactive();

            return View(this.Reactive);
        }

        [HttpPost]
        public async Task<IActionResult> Management(Reactive reactive)
        {
            if (ModelState.IsValid)
            {
                if (reactive.Id == 0)
                {
                    _db.Reactives.Add(reactive);
                }
                else
                {
                    _db.Reactives.Update(reactive);
                }

                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        private void LoadReactives() 
        {
            this.Reactives = (from element in _db.Reactives
                              select new Reactive
                              {
                                  Id = element.Id,
                                  Name = element.Name
                              }).ToList();
        }

    }
}
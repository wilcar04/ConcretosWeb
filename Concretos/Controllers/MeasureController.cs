using Concretos.Data;
using Concretos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Concretos.Controllers
{
    public class MeasureController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly List<FabricationMethod> FabricationMethods;
        private readonly List<Reactive> Reactives;
        private Measure Measure { get; set; }

        public MeasureController(ApplicationDbContext db)
        {
            this._db = db;

            this.FabricationMethods = (from element in _db.FabricationMethods
                                         select new FabricationMethod
                                         {
                                             Id = element.Id,
                                             Name = element.Name
                                         }).ToList<FabricationMethod>();

            this.Reactives = (from element in _db.Reactives
                              select new Reactive 
                              {
                                  Id = element.Id,
                                  Name = element.Name
                              }).ToList();
        }

        public IActionResult Management()
        {
            ViewData["FabricationMethods"] = this.FabricationMethods;
            ViewData["Reactives"] = this.Reactives;

            this.Measure = new Measure();

            return View(this.Measure);
        }

        [HttpPost]
        public async Task<IActionResult> Management(Measure measure)
        {
            ViewData["FabricationMethods"] = this.FabricationMethods;
            ViewData["Reactives"] = this.Reactives;

            measure.Id = 1;

            return View(measure);
        }

    }
}

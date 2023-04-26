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
        private List<Measure> Measures; 
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

        [HttpGet()]
        public IActionResult Management([FromQuery(Name = "study-id")] int studyId)
        {
            this.loadMeasures(studyId);

            ViewData["FabricationMethods"] = this.FabricationMethods;
            ViewData["Reactives"] = this.Reactives;
            ViewData["Measures"] = this.Measures;

            this.Measure = new Measure();
            this.Measure.Id = 0;
            this.Measure.StudyId = studyId;
            this.Measure.Study = _db.Studies.Find(studyId);
            this.Measure.Date = DateTime.Now;
            this.Measure.ExperimentalDate = DateTime.Now;

            return View(this.Measure);
        }

        [HttpPost]
        public async Task<IActionResult> Management(Measure measure)
        {
            ViewData["FabricationMethods"] = this.FabricationMethods;
            ViewData["Reactives"] = this.Reactives;
            
            if (ModelState.IsValid)
            {
                if(measure.Id == 0)
                {
                    this.loadMeasures(measure.StudyId);

                    if (this.Measures.Count > 0)
                    {
                        measure.Consecutive = this.Measures.Last().Consecutive + 1;
                    }
                    else
                    {
                        measure.Consecutive = 1;
                    }

                    _db.Measures.Add(measure);
                }
                else
                {
                    _db.Measures.Update(measure);
                    this.loadMeasures(measure.StudyId);
                }

                _db.SaveChanges();
            }

            ViewData["Measures"] = this.Measures;

            return View(measure);
        }

        private void loadMeasures(int studyId) 
        {
            this.Measures = (from element in _db.Measures
                             where element.StudyId == studyId
                             orderby element.Consecutive ascending
                             select new Measure
                            {
                                Id = element.Id,
                                Consecutive = element.Consecutive,
                                Date = element.Date,
                                ExperimentalPorosity = element.ExperimentalPorosity
                            }).ToList();
        }

    }
}

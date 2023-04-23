using Concretos.Data;
using Concretos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Concretos.Controllers
{
    public class StudyController : Controller
    {

        private readonly ApplicationDbContext _db;
        private Study Study { get; set; }

        public StudyController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Study> objStudyList = _db.Studies;
            return View(objStudyList);
        }

        //GET
        public IActionResult Create()
        {
            this.Study = new Study();

            return View(this.Study);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Study obj)
        {
            if (ModelState.IsValid)
            {
                _db.Studies.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}

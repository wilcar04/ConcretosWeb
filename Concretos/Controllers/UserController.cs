using Concretos.Data;
using Concretos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Concretos.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContext _db;
        private List<User> Users;
        private User User { get; set; }
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<User> usersFromDb = _db.Users;
            return View(usersFromDb);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpGet("User/Management/{userId}")]
        public IActionResult Management(int userId)
        {   

            this.User = _db.Users.Find(userId);
            this.loadUsers(userId);
            


            this.User = new User();
            this.User.Id = userId;


            return View(this.User);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Userid)
        {
                this.loadUsers(Userid);
                if (this.Users.Count == 1)
                {
                    User user = this.Users.FirstOrDefault();
                    if (user.Enable == false)
                    {
                        user.Enable = true;
                        _db.Entry(user).State = EntityState.Modified;
                        _db.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
        }

        private void loadUsers(int UserId)
        {
            this.Users = (from element in _db.Users
                             where element.Id == UserId
                            select new User
                             {
                                 Id = element.Id,
                                 Email = element.Email,
                                 Enable = element.Enable
                             }).ToList();
        }
    }
}

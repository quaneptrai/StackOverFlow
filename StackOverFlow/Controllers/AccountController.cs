using Microsoft.AspNetCore.Mvc;
using StackOverFlow.Data;
using StackOverFlow.Models;

namespace StackOverFlow.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult SignInTest()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult Manage()
        {
            var userList = _db.Users.ToList();
            return View(userList);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var user = _db.Users.Find(id);
            if (user == null) return NotFound();
            return View(user);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var user = _db.Users.Find(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            bool checkEmail = _db.Users.Any(u => u.Email == user.Email);
            if (checkEmail)
            {
                ModelState.AddModelError("Email", "This email is already registered.");
            }

            if (ModelState.IsValid)
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                TempData["AuthCheck"] = "Sign up successful!";
                return RedirectToAction("SignIn");
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            bool checkEmail = _db.Users.Any(u => u.Email == user.Email);
            if (checkEmail)
            {
                ModelState.AddModelError("Email", "This email is already registered.");
            }

            if (ModelState.IsValid)
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                TempData["Success"] = "Account created successfully!";
                return RedirectToAction("Manage");
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult SignIn(string email, string password)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetString("Role", user.Role);
                HttpContext.Session.SetInt32("UserID", user.UsernameId);
                HttpContext.Session.SetString("UserEmail", user.Email);
                TempData["AuthCheckSignin"] =$"Login sucessfully , welcome back! {user.Firstname} {user.LastName}";
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid email or password";
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["AuthCheck"] = "You have been logged out.";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Update(user);
                _db.SaveChanges();
                TempData["Success"] = "Account updated successfully!";
                return RedirectToAction("Manage");
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _db.Users.Remove(user);
            _db.SaveChanges();
            TempData["Success"] = "Account deleted successfully!";
            return RedirectToAction("Manage");
        }
    }
}
    
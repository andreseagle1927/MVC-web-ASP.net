using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRankMVC.Models;

namespace MovieRankMVC.Controllers
{
    public class UsersController : Controller
    {
        // GET: HomeController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View(new User()); 
        }

        // GET: HomeController1/Create
        public ActionResult Login()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (user.Password == user.ConfirmPassword)
                    {
                        return View("Login");
                    }
                    else
                    {
                        ModelState.AddModelError("ConfirmPassword", "Password do not match.");
                        ModelState.AddModelError("Password", "Confirm Password do not match.");
                    }
                }
                return View(user);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(IFormCollection collection)
        {
            try
            {
                string userEmail = collection["UserEmail"];
                string userPassword = collection["Password"];

                if (userEmail.Equals("ad@g.com"))
                {
                    // Código a ejecutar si la condición es verdadera
                    return View("~/Views/Home/Index.cshtml");
                }
                else
                {
                    return View("Login");
                }

            }
            catch
            {
                return View();
            }
        }
        
        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

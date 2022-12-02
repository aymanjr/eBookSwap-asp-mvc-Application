using ebookSwapApllication.Data;
using ebookSwapApllication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ebookSwapApllication.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext? _context;

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginSignupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var User = from m in _context.Users select m;
                User = User.Where(s => s.UserName.Contains(model.UserName));
                if (User.Count() != 0)
                {
                    if (User.First().UserPassword == model.UserPassword)
                    {
                        return RedirectToAction("Index", "Book");
                    }
                }
            }

            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }
        public IActionResult Signup()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Signup(LoginSignupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var data = new User()
                {
                    UserFullName = model.UserName,
                    UserName = model.UserName,
                    UserPassword = model.UserPassword,
                    UserEmail = model.UserEmail,
                    UserCity = model.UserCity,
                    UserCountry = model.UserCountry,
                    Userphonenumber = model.Userphonenumber,
                    UserAdress = model.UserAdress,
                    UserDateCreating = DateTime.Now.ToShortTimeString().ToString()
                    


                };
                _context.Users.Add(data);
                _context.SaveChanges();
                TempData["successMessage"] = "created successfully";

                return RedirectToAction("Index","Users");


            }
            else
            {
                TempData["errorMessage"] = "Empty form can't be submitted";
            }
            return View();
        }

        public ActionResult Validate(User user)
        {
            var _admin = _context.Users.Where(s => s.UserName == user.UserName);
            if (_admin.Any())
            {
                if (_admin.Where(s => s.UserPassword == user.UserPassword).Any())
                {

                    return Json(new { status = true, message = "Login Successfull!" });
                }
                else
                {
                    return Json(new { status = false, message = "Invalid Password!" });
                }
            }
            else
            {
                return Json(new { status = false, message = "Invalid Username!" });
            }
        }
    }
}

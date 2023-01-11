using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ebookSwapApllication.Data;
using ebookSwapApllication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace ebookSwapApllication.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;


        public UsersController(AppDbContext context)
        {
            _context = context;
          
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public  ActionResult Login(User user)
        {


            var result =  _context.Users.Where(a => a.UserName.Equals(user.UserName) && a.UserPassword.Equals(user.UserPassword)).FirstOrDefault();

            if (result != null)
            {
      
                HttpContext.Session.SetInt32("sessionKeyUserId", result.UserId);
                HttpContext.Session.SetString("sessionKeyUsername", result.UserName);


                //Session["UserID"] = obj.UserId.ToString();
                //Session["UserName"] = obj.UserName.ToString();
                ViewBag.profile = "true";
                ViewBag.checkiflogin = "true";

                return RedirectToAction("Index","Books");
            }
            else
            {

                return RedirectToAction("Login", "Users");

            }

           

        }

        public ActionResult Logout()
        {

            if (HttpContext.Session.GetInt32("sessionKeyUserId") == 0 || string.IsNullOrEmpty(HttpContext.Session.GetString("sessionKeyUsername")))
            {
                return RedirectToAction("Login", "Users");
            }
            else
            {
                HttpContext.Session.SetInt32("sessionKeyUserId", 0);
                HttpContext.Session.SetString("sessionKeyUsername", "");
                ViewBag.profile = "false";
                ViewBag.checkiflogin = "false";
                return RedirectToAction("Login", "Users");
            }

        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("sessionKeyUserId") == 0 || string.IsNullOrEmpty(HttpContext.Session.GetString("sessionKeyUsername")))
            {
                return RedirectToAction("Login", "Users");
            }
            else 
           
                return View(await _context.Users.ToListAsync());
            
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (HttpContext.Session.GetInt32("sessionKeyUserId") == 0 || string.IsNullOrEmpty(HttpContext.Session.GetString("sessionKeyUsername")))
            {
                return RedirectToAction("Login", "Users");
            }
            else
            {

                if (id == null || _context.Users == null)
                {
                    return NotFound();
                }

                if (HttpContext.Session.GetInt32("sessionKeyUserId") == id)
                {
                    ViewBag.personalprofileconfirmation = "confirmationprofile";
                }
                else
                {
                    ViewBag.personalprofileconfirmation = "nonprofile";

                }

                var user = await _context.Users.Include(x => x.Books)
                    .FirstOrDefaultAsync(m => m.UserId == id);

                ViewBag.count = _context.Books.Where(x => x.UserId == id).Count();

                var books = await _context.Books.Where(x => x.UserId == id).ToListAsync();

                if (user == null)
                {
                    return NotFound();
                }
                return View(user);

            }
        }

        public ActionResult Chekin()
        {

            if (HttpContext.Session.GetInt32("sessionKeyUserId") == 0 || string.IsNullOrEmpty(HttpContext.Session.GetString("sessionKeyUsername")))
            {
                return RedirectToAction("Login", "Users");
            }
            else
                return View();

        }


        // GET: Users/Create
        public IActionResult Create()
        {
            return RedirectToAction("Login");
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserName,UserFullName,UserEmail,UserPassword,Userphonenumber,UserCity,UserCountry,UserAdress,UserDateCreating")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return RedirectToAction("Login");

        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return RedirectToAction("Details");
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserName,UserFullName,UserEmail,UserPassword,Userphonenumber,UserCity,UserCountry,UserAdress,UserDateCreating")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'AppDbContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return _context.Users.Any(e => e.UserId == id);
        }
    }
}

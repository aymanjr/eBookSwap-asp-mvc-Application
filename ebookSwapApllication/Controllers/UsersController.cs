using ebookSwapApllication.Data;
using Microsoft.AspNetCore.Mvc;

namespace ebookSwapApllication.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Users.ToList();
            return View();
        }
    }
}

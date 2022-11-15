using ebookSwapApllication.Data;
using Microsoft.AspNetCore.Mvc;

namespace ebookSwapApllication.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

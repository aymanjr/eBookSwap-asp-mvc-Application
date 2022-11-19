using ebookSwapApllication.Data;
using ebookSwapApllication.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace ebookSwapApllication.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _service;

        public UsersController(IUsersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.Getall();
            return View(data); 
        }
    }
}

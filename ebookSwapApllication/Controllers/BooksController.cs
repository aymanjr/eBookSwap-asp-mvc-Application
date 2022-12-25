using ebookSwapApllication.Data;
using ebookSwapApllication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ebookSwapApllication.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("sessionKeyUserId") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            else
            { 
                var allbooks = await _context.Books.Include(n => n.User).ToListAsync();
                return View(allbooks);
            }


        }

        [HttpGet]
        public async Task<IActionResult> Index(string booksearch)
        {
            if (HttpContext.Session.GetInt32("sessionKeyUserId") == null)
            {
                return RedirectToAction("Login", "Users");
            }else
            {

            

            ViewData["getbookdetail"] = booksearch;

            var bookquery = from x in _context.Books.Include(n => n.User) select x;

            if (!string.IsNullOrEmpty(booksearch))
            {
                bookquery = bookquery.Where(x => x.BookTitle.Contains(booksearch) || x.BookISBN13.Contains(booksearch) || x.BookAuthor.Contains(booksearch) || x.BookCategory.Contains(booksearch) || x.BookLanguage.Contains(booksearch)|| x.User.UserCity.Contains(booksearch));
            }

            return View(await bookquery.AsNoTracking().ToListAsync());
            }

        }



        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetInt32("sessionKeyUserId") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            else
            {

                if (id == null || _context.Books == null)
                {
                    return NotFound();
                }

                var book = await _context.Books.Include(n => n.User)
                     .FirstOrDefaultAsync(m => m.BookId == id);

                ViewBag.countbookbookdetail = _context.Books.Where(x=>x.UserId == book.UserId).Count();


                if (book == null)
                {
                    return NotFound();
                }

                return View(book);
            }
        }
    
        // GET: Books/Create
        public IActionResult Create()
        {
            //Book book = new Book();
            //book.BookCategoryList = new SelectList(_context.Books.ToList(), "BookCategory", "BookCategory");

            if (HttpContext.Session.GetInt32("sessionKeyUserId") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            else
            {
                var catgorylist = (from book in _context.Books
                                   select new SelectListItem()
                                   {

                                       Text = book.BookCategory,
                                       Value = book.BookCategory.ToString()

                                   }).ToList();
                catgorylist.Insert(0, new SelectListItem()
                {

                    Text = "--Select--",
                    Value = String.Empty
                });

                ViewBag.Catgorylist = catgorylist;



                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookTitle","BookLanguage","BookAuthor","BookCondition","UserId","BookNotes","BookCategory", "BookISBN13", "BookNumPages", "BookPublicationDate", "BookPublisherID", "BookDescription")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }


        //[HttpPost] 
        //public IActionResult Create(CategoryViewModel categoryViewModel,Book book)
        //{

        //   var selectedValue = categoryViewModel.Listofcategories;

        //    var newbook = new Book()
        //    {
        //        BookTitle = book.BookTitle,
        //        BookCondition  = book.BookCondition,
        //        BookAuthor = book.BookAuthor,
        //        BookDescription = book.BookDescription,
        //        BookLanguage =     book.BookLanguage,
        //        BookNotes = book.BookNotes,
        //        BookPublisherID = book.BookPublisherID,
        //        BookNumPages = book.BookNumPages,
        //        BookCategory = selectedValue.ToString(),
        //    };


        //    return View(categoryViewModel);

        //}
    }
}

using Microsoft.AspNetCore.Mvc;
using OwnerApp.Data;             // 🔁 Your DbContext namespace
using OwnerApp.Models;           // 🔁 Your Contact model namespace
using System.Threading.Tasks;

namespace OwnerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitContact(Contact model)
        {
            if (ModelState.IsValid)
            {
                // Save to DB (if you're using Entity Framework)
                _context.Contacts.Add(model);
                _context.SaveChanges();

                // Show confirmation using TempData
                TempData["SuccessMessage"] = "✅ Thank you! Your message has been sent successfully.";

                return RedirectToAction("Contact");
            }

            return View("Contact", model);
        }


        // 🔁 Optional: Error handler (404/500 pages)
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}

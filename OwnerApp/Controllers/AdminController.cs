using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OwnerApp.Data;
using OwnerApp.Models;

namespace OwnerApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        private const string AdminUsername = "admin";
        private const string AdminPassword = "Admin@8282"; // 🔐 Change this for security

        // ✅ Login Page (GET)
        public IActionResult Login()
        {
            return View();
        }

        // ✅ Login Submit (POST)
        [HttpPost]
        public IActionResult Login(AdminLogin model)
        {
            if (ModelState.IsValid)
            {
                if (model.Username == AdminUsername && model.Password == AdminPassword)
                {
                    HttpContext.Session.SetString("IsAdmin", "true");
                    return RedirectToAction("Index");
                }

                // ❌ Wrong credentials
                ModelState.AddModelError(string.Empty, "❌ Invalid username or password.");
            }

            return View(model);
        }

        // ✅ Admin Dashboard (Contact Messages)
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return RedirectToAction("Login");
            }

            var contacts = await _context.Contacts
                .OrderByDescending(c => c.SubmittedAt)
                .ToListAsync();

            return View(contacts);
        }

        // ✅ Logout Admin
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("IsAdmin");
            return RedirectToAction("Login");
        }
    }
}

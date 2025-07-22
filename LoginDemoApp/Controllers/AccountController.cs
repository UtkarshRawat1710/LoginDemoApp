using LoginDemoApp.Data;
using LoginDemoApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LoginDemoApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

       [HttpPost]
public IActionResult Login(string email, string password, string role)
{
    var user = _context.Users.FirstOrDefault(u => u.Email == email);

    if (user != null && user.Password == password)
    {

        if (user.Role == role)
        {
                    // Redirect based on role
                    if (user.Role == "Admin")
                    {
                        return RedirectToAction("AdminDashboard", "Admin", new { name = user.Name, email = user.Email,id=user.Id,role=user.Role });
                    }
                    else
                    {
                        return RedirectToAction("Welcome", "User", new { name = user.Name, email = user.Email, id = user.Id,role=user.Role });
                    }
          }
        else
        {
            TempData["ErrorMessage"] = "Incorrect role selected.";
            return RedirectToAction("Login");
        }
    }

    TempData["ErrorMessage"] = "Invalid email or password.";
    return RedirectToAction("Login");
}
        public IActionResult Logout()
        {
            // Clear the session
            HttpContext.Session.Clear();

            // Optional: TempData message
            TempData["LogoutMessage"] = "You have been logged out successfully.";

            // Redirect to Login page
            return RedirectToAction("Login", "Account");
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string name, string email, string password)
        {
            var newUser = new User
            {
                Name = name,
                Email = email,
                Password = password,
                Role = "User" // this is the key!
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            TempData["Message"] = $"Welcome {newUser.Name}! Please log in.";
            return RedirectToAction("Login");
        }



       
      
    }
}

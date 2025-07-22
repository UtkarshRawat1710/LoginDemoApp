using System.Xml.Linq;
using LoginDemoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using LoginDemoApp.Data;

using Microsoft.AspNetCore.Http;
using System.Security.Claims;
namespace LoginDemoApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult AdminDashboard(string name,string email,int id,string password,string role)
        {
           
            HttpContext.Session.SetString("UserName", name);
            HttpContext.Session.SetString("UserEmail", email);
            HttpContext.Session.SetInt32("UserId", id);
            HttpContext.Session.SetString("UserPassword", password);
            HttpContext.Session.SetString("UserRole", role);
            return View();
           
        }
        public IActionResult ViewBooking()
        {

            var bookings = _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Car)
                .ToList();

            return View(bookings);
        }

        [HttpPost]
      
        [ValidateAntiForgeryToken] // Optional but recommended
        public async Task<IActionResult> AddCar(Car car)
        {
            if (ModelState.IsValid && car.ImageFile != null)
            {
                var fileName = Path.GetFileName(car.ImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/cars", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await car.ImageFile.CopyToAsync(stream);
                }
                car.ImageUrl = "/images/cars/" + fileName; // ✅ Leading slash

                _context.Cars.Add(car);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Car added successfully!";
                return RedirectToAction("AddCar"); // Redirect to the GET AddCar
            }

            return View(car); // In case of validation failure
        }

        [HttpGet]
        public IActionResult AddCar()
        {
            return View();
        }

        public IActionResult SearchCustomers()
        {
            var user = _context.Users
               .Where(f => f.Role == "User")
               .ToList();

            return View(user);
        }

        public IActionResult ViewFeedback()
        {
            var feedbacks = _context.Feedbacks.Include(f => f.User).ToList();
            return View(feedbacks);
        }
    }
}

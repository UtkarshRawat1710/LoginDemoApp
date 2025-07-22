using LoginDemoApp.Data;
using LoginDemoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;

namespace LoginDemoApp.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Welcome(string name, string email, int id,string role)
        {
            HttpContext.Session.SetString("UserName", name);
            HttpContext.Session.SetString("UserEmail", email);
            HttpContext.Session.SetInt32("UserId", id);
       
            HttpContext.Session.SetString("UserRole", role);
            return View();
        }

        public IActionResult SearchCar()
        {
            var cars = _context.Cars.ToList();
            return View(cars);
        }

        public IActionResult BookCar(int? carId)
        {
            var cars = _context.Cars.ToList(); // or where Available
            ViewBag.SelectedCarId = carId;
            return View(cars);
        }

        [HttpPost]
        public IActionResult SubmitBooking(int CarId, DateTime StartDate, DateTime EndDate)
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == CarId);
            if (car == null) return NotFound();

            var userId = _httpContextAccessor.HttpContext?.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Account");

            var totalAmount = car.BookingPrice * (EndDate - StartDate).Days;
            var booking = new Booking
            {
                CarId = CarId,
                UserId = userId.Value,
                StartDate = StartDate,
                EndDate = EndDate,
                TotalAmount = totalAmount,
                Status = "Pending",
                PaymentMode = "Pending",
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return RedirectToAction("Payment", new { bookingId = booking.Id });
        }

        public IActionResult Payment(int bookingId)
        {
            var booking = _context.Bookings
                .Include(b => b.Car)
                .FirstOrDefault(b => b.Id == bookingId);

            if (booking == null) return NotFound();

            return View(booking);
        }

        [HttpPost]
        public IActionResult ConfirmPayment(int bookingId, string paymentMode)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.Id == bookingId);
            if (booking == null) return NotFound();

            booking.Status = "Confirmed";
            booking.PaymentMode = paymentMode;

            _context.Update(booking);
            _context.SaveChanges();

            return RedirectToAction("BookingConfirmation", new { id = booking.Id });
        }

        public IActionResult BookingConfirmation(int id)
        {
            var booking = _context.Bookings
                .Include(b => b.Car)
                .FirstOrDefault(b => b.Id == id);

            if (booking == null) return NotFound();

            return View(booking);
        }

        public IActionResult BookingHistory()
        {
            var userId = _httpContextAccessor.HttpContext?.Session.GetInt32("UserId");
            var bookings = _context.Bookings
                .Include(b => b.Car)
                .Where(b => b.UserId == userId)
                .ToList();

            if (!bookings.Any())
            {
                ViewBag.Message = "No booking till now.";
            }

            return View(bookings);
        }
        [HttpGet]
        public IActionResult Feedback()
        {
            return View(new Feedback()); // pass empty model
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Feedback(Feedback model)
        {
            if (ModelState.IsValid)
            {
                
                var userId = _httpContextAccessor.HttpContext?.Session.GetInt32("UserId");

                if ( userId == null)
                {
                    TempData["Error"] = "User session expired. Please login again.";
                    return RedirectToAction("Login", "Account");
                }

                var feedback = new Feedback
                {
                    
                    Message = model.Message,
                    SubmittedAt = DateTime.Now,
                    UserId = userId.Value
                };

                _context.Feedbacks.Add(feedback);
                _context.SaveChanges();

                TempData["Success"] = "Thank you for your feedback!";
                return RedirectToAction("Feedback");
            }

            return View(model);
        }


        [HttpPost]
        [HttpPost]
        [HttpPost]
        public IActionResult UpdateProfile(User model)
        {
            // Console pe model se aaya data print karo
            Console.WriteLine("User Model Data:");
            Console.WriteLine($"Name: {model.Name}");
            Console.WriteLine($"Email: {model.Email}");
           

            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetString("UserId");
                if (userId == null || !int.TryParse(userId, out int parsedId))
                {
                    TempData["Error"] = "Session expired. Please log in again.";
                    return RedirectToAction("Login", "Account");
                }

                var user = _context.Users.FirstOrDefault(u => u.Id == parsedId);
                if (user != null)
                {
                    user.Name = model.Name;

                    if (!string.IsNullOrWhiteSpace(model.Password))
                    {
                        user.Password = model.Password;
                    }

                    _context.SaveChanges();

                    HttpContext.Session.SetString("UserName", user.Name);

                    TempData["Success"] = "Profile updated successfully!";
                }
                else
                {
                    TempData["Error"] = "User not found.";
                }

            return RedirectToAction("Welcome", "User", new { name = model.Name, email = model.Email, id = model.Id, role = model.Role });

            }

            TempData["Error"] = "Invalid input!";
            return RedirectToAction("Welcome", "User", new { name = model.Name, email = model.Email, id = model.Id, role = model.Role });
        }


        public IActionResult Dashboard()
        {
            return View(); // pass empty model
        }

    }
}

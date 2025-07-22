using Microsoft.EntityFrameworkCore;
using LoginDemoApp.Models;

using System.Collections.Generic;



namespace LoginDemoApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Feedback> Feedbacks{ get; set; }
    }
}

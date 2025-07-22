using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginDemoApp.Models
{
    public class Booking
    {
        [Key] // Marks the primary key of the entity
        public int Id { get; set; }

        [Required] // Specifies that the property is required and cannot be null
        public int UserId { get; set; }

        // Foreign key relationship with the User table
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required] // Specifies that the property is required and cannot be null
        public int CarId { get; set; }

        // Foreign key relationship with the Car table
        [ForeignKey("CarId")]
        public Car Car { get; set; }

        [Required]
        [DataType(DataType.Date)] // Ensures that the field is treated as a date
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)] // Ensures that the field is treated as a date
        public DateTime EndDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")] // Specifies the column data type in the database
        public decimal TotalAmount { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.Now; // Default booking date is the current date and time

        [StringLength(50)] // Limits the string length to 50 characters
        public string Status { get; set; } = "Pending"; // Default status is "Pending"

        // Nullable foreign key relationship with Payment table (optional)
        public int? PaymentId { get; set; }

        // Foreign key relationship with the Payment table
        [ForeignKey("PaymentId")]
        public Payment Payment { get; set; }

        // New property to store the payment mode (e.g., "Credit Card", "Cash", etc.)
        [Required]
        [StringLength(50)] // Limiting the payment mode length to 50 characters
        public string PaymentMode { get; set; } = "Pending";  // Payment Mode (e.g., Credit Card, Debit Card, Cash)
    }
}

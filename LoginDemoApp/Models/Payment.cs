using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginDemoApp.Models
{
    public class Payment
    {
        [Key]  // Marks the primary key of the entity
        public int Id { get; set; }

        [Required]  // Specifies that the property is required and cannot be null
        public int UserId { get; set; }

        // Foreign key relationship with the User table
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]  // Specifies the column data type in the database
        public decimal Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]  // Ensures that the field is treated as a date
        public DateTime PaymentDate { get; set; } = DateTime.Now;  // Default payment date is the current date and time

        [Required]
        [StringLength(50)]  // Limits the string length to 50 characters
        public string PaymentMethod { get; set; }

        [StringLength(50)]  // Limits the string length to 50 characters
        public string Status { get; set; } = "Pending";  // Default status is "Pending"

        // Additional properties or logic can be added here
    }
}

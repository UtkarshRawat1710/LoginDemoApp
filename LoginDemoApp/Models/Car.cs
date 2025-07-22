using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 namespace LoginDemoApp.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Brand is required.")]
        [StringLength(50)]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        [StringLength(50)]
        public string Model { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [Range(1990, 2100)]
        public int Year { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        [StringLength(30)]
        public string Color { get; set; }

      
        public string? ImageUrl { get; set; }


        [Required(ErrorMessage = "Booking price is required.")]
        [Range(0, double.MaxValue)]
        [Display(Name = "Booking Price (INR)")]
        public decimal BookingPrice { get; set; }
       
        [NotMapped] // Do not map this to DB
        public IFormFile? ImageFile { get; set; }
    }
}

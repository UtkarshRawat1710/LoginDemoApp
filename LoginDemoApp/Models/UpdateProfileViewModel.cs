using System.ComponentModel.DataAnnotations;
namespace LoginDemoApp.Models
{
    public class UpdateProfileViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public string Password { get; set; } // No [Required] – it's optional
        [EmailAddress]
        public string Email { get; set; } // ✅ Added to prevent model binding failure
    }


}

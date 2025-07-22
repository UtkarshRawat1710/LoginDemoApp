using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginDemoApp.Models
{
    public class Feedback
    {
        public int Id { get; set; }

       
        
        [Required(ErrorMessage = "Please enter your message.")]
        public string Message { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }

        public User?User { get; set; }  // 👈 Navigation property


    }
}

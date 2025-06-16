using System.ComponentModel.DataAnnotations;

namespace MyPortfolioWebApp.Models
{
    public class ContactModel
    {
<<<<<<< HEAD:day10/Day10Study/MyPortfolioWebApp/Models/ContactModel.cs
        [Required(ErrorMessage = "필수입니다")]
        public string Name { get; set; }

        [Required(ErrorMessage = "필수입니다")]
        public string Email { get; set; }

        [Required(ErrorMessage = "필수입니다")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "필수입니다")]
=======
        [Required(ErrorMessage ="성함은 필수애용")]
        public string Name { get; set; }

        [Required(ErrorMessage = "필수애용")]
        public string Email { get; set; }

        [Required(ErrorMessage = "필수애용")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "필수애용")]
>>>>>>> parent of bb0c90c (13):Day10Study/MyPortfolioWebApp/Models/ContactModel.cs
        public string Message { get; set; }
    }
}

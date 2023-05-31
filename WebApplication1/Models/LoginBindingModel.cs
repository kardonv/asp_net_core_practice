using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class LoginBindingModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [UIHint("Password")]
        [StringLength(15, MinimumLength = 6)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}

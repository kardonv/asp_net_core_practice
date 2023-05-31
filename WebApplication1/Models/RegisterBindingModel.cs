using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class RegisterBindingModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Login { get; set; }

        [Phone]
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [UIHint("Password")]
        [Compare("ConfirmPassword")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [UIHint("Password")]
        [Display(Name = "PaswordConfirm")]
        public string ConfirmPassword { get; set; }
    }
}

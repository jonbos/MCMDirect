using System.ComponentModel.DataAnnotations;

namespace MCMDirect.Models.ViewModels {
    public class LoginViewModel {
        [Required(ErrorMessage = "Enter your username")]
        [StringLength(255)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [StringLength(255)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}
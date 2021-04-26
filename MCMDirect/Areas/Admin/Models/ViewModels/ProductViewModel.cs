using System.ComponentModel.DataAnnotations;
using MCMDirect.Areas.Store.Models;
using Microsoft.AspNetCore.Http;

namespace MCMDirect.Areas.Admin.Models.ViewModels {
    public class ProductViewModel {
        public Product Product { get; set; }

        [Required(ErrorMessage = "You must upload an image")]
        public IFormFile Image { get; set; }
    }
}
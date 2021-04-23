using System.ComponentModel.DataAnnotations;
using MCMDirect.Areas.Store.Models;
using Microsoft.AspNetCore.Http;

namespace MCMDirect.Areas.Admin.Models.ViewModels {
    public class CategoryViewModel {
        public Category Category { get; set; }
        public IFormFile Image { get; set; }
    }
}
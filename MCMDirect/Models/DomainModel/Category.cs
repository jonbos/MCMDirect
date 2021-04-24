using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MCMDirect.Areas.Store.Models {
    public class Category {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "You must enter a category name")]
        public string CategoryName { get; set; }

        public string Image { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
using System.Collections.Generic;

namespace MCMDirect.Areas.Store.Models {
    public class Category {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public string Image { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
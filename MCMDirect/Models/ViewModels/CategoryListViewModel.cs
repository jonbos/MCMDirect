using System.Collections;
using System.Collections.Generic;
using MCMDirect.Areas.Store.Models;

namespace MCMDirect.Models.ViewModels {
    public class CategoryListViewModel {
        public Category Category { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
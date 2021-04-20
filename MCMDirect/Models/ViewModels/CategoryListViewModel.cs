using System.Collections;
using System.Collections.Generic;
using MCMDirect.Areas.Store.Models;

namespace MCMDirect.Models.ViewModels {
    public class CategoryListViewModel {
        public Category category { get; set; }
        public IEnumerable<Product> products { get; set; }
    }
}
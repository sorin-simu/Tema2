using System.Collections.Generic;

namespace Ministore.UI.Models
{
    public class ShopViewModel
    {
        public IList<ProductViewModel> Products { get; set; }
        public IList<ProductViewModel> ProductsInShoppingCart { get; set; }
        public string TotalPrice { get; set; }

        public ShopViewModel()
        {
            Products = new List<ProductViewModel>();
            ProductsInShoppingCart = new List<ProductViewModel>();
        }
    }
}
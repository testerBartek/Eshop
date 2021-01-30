using Eshop.Application.Products;
using Eshop.Database;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Eshop.UI.Pages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _ctx;

        public IndexModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<GetProducts.ProductViewModel> Products { get; set; }

        public void OnGet()
        {
            Products = new GetProducts(_ctx).Do();
        }
    }
}

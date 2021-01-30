using Eshop.Application.Cart;
using Eshop.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Eshop.UI.Pages
{
    public class CartModel : PageModel
    {
        private ApplicationDbContext _ctx;

        public CartModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<GetCart.Response> Cart { get; set; }

        public IActionResult OnGet()
        {

            Cart = new GetCart(HttpContext.Session, _ctx).Do();

            return Page();
        }
    }
}

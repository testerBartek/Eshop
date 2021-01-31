using Eshop.Application.Cart;
using Eshop.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop.UI.Pages.Checkout
{
    public class PaymentSuccessfulModel : PageModel
    {
        private ApplicationDbContext _ctx;

        public PaymentSuccessfulModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult OnGet()
        {

            var information = new GetCustomerInformation(HttpContext.Session).Do();

            if (information == null)
            {
                return RedirectToPage("/Checkout/CustomerInformation");
            }

            //TODO: Delete the cookies after purchase, but I need to think about clear the session in memory.

            Response.Cookies.Delete("Cart", new CookieOptions()
            {
                Secure = true,
            });

            return Page();
        }
    }
}



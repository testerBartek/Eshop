using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Application.Cart;
using Eshop.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop.UI.Pages.Checkout
{
    public class PaymentSuccessfulModel : PageModel
    {
        private ApplicationDbContext _ctx;
     
        public PaymentSuccessfulModel (ApplicationDbContext ctx)
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

            return Page();
        }
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Application.Cart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace Eshop.UI.Pages.Checkout
{
    public class PaymentModel : PageModel
    {


        public PaymentModel (IConfiguration config)
        {
            PublicKey = config["Stripe:PublicKey"].ToString();
        }

        public string PublicKey { get; }

        public IActionResult OnGet()
        {

            var information = new GetCustomerInformation(HttpContext.Session).Do();

            if (information == null)
            {
                return RedirectToPage("/Checkout/CustomerInformation");
            }

            return Page();
        }

        public IActionResult OnPost(string stripeEmail, string stripeToken)
        {

            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,
                Description = "Sample Charge",
                Currency = "usd",
                Customer = customer.Id
            });


            return RedirectToPage("/Index");
        }
    }
}

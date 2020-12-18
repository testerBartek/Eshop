using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Application.Products;
using Eshop.Database;

namespace Eshop.UI.Pages
{

    public class IndexModel : PageModel
    {
        private ApplicationDbContext _ctx;

        public IndexModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }


        [BindProperty]
        public ProductViewModel Product { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            await new CreateProduct(_ctx).Do(Product);

            return RedirectToPage("Index");
        }

    }
}

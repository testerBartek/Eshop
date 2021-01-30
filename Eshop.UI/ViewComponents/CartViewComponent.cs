using Eshop.Application.Cart;
using Eshop.Database;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Eshop.UI.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private ApplicationDbContext _ctx;

        public CartViewComponent(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IViewComponentResult Invoke(string view = "Default")
        {
            if (view == "Small")
            {
                var totalValue = new GetCart(HttpContext.Session, _ctx).Do().Sum(x => x.RealValue * x.Qty);
                return View(view, $"{totalValue} PLN");
            }
            return View(view, new GetCart(HttpContext.Session, _ctx).Do());
        }
    }
}

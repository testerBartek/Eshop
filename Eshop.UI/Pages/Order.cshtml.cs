using Eshop.Application.OrdersAdmin;
using Eshop.Database;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop.UI.Pages
{
    public class OrderModel : PageModel
    {
        private ApplicationDbContext _ctx;

        public OrderModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public GetOrder.Response Order { get; set; }

        public void OnGet(int id)
        {
            Order = new GetOrder(_ctx).Do(id);
        }
    }
}

using Eshop.Database;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.UI.Controllers
{
    public class ImageController : Controller
    {
        private ApplicationDbContext _ctx;

        public ImageController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
    }
}

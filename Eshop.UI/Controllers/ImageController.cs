using Eshop.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

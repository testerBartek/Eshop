﻿using Eshop.Application.Cart;
using Eshop.Database;
using EShop.Application.Cart;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eshop.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _ctx;

        public CartController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> AddOne(int stockId)
        {
            var request = new AddToCart.Request
            {
                StockId = stockId,
                Qty = 1
            };
            var addToCart = new AddToCart(HttpContext.Session, _ctx);

            var success = await addToCart.Do(request);

            if (success)
            {
                return Ok("Item added to cart");
            }
            return BadRequest("Failed to add to cart");
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> RemoveOne(int stockId)
        {
            var request = new RemoveFromCart.Request
            {
                StockId = stockId,
                Qty = 1
            };
            var addToCart = new RemoveFromCart(HttpContext.Session, _ctx);

            var success = await addToCart.Do(request);

            if (success)
            {
                return Ok("Item removed from cart");
            }

            return BadRequest("Failed to remove item from cart");
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> RemoveAll(int stockId)
        {
            var request = new RemoveFromCart.Request
            {
                StockId = stockId,
                All = true
            };
            var addToCart = new RemoveFromCart(HttpContext.Session, _ctx);

            var success = await addToCart.Do(request);

            if (success)
            {
                return Ok("Item removed all items from cart");
            }

            return BadRequest("Failed to remove all items from cart");
        }

    }
}
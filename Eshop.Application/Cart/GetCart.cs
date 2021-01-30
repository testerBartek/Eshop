using Eshop.Database;
using Eshop.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eshop.Application.Cart
{
    public class GetCart
    {
        private ISession _session;
        private ApplicationDbContext _ctx;

        public GetCart(ISession session, ApplicationDbContext ctx)
        {
            _session = session;
            _ctx = ctx;
        }

        public class Response
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public decimal RealValue { get; set; }
            public int Qty { get; set; }

            public int StockId { get; set; }
            public string ImageName { get; set; }
        }

        public IEnumerable<Response> Do()
        {
            var stringObject = _session.GetString("cart");

            if (string.IsNullOrEmpty(stringObject))
                return new List<Response>();

            var cartList = JsonConvert.DeserializeObject<List<CartProduct>>(stringObject);

            var response = _ctx.Stock
                .Include(x => x.Product).AsEnumerable()
                .Where(x => cartList.Any(y => y.StockId == x.Id))
                .Select(x => new Response
                {
                    Name = x.Product.Name,
                    Value = $"{x.Product.Value.ToString("N2")} PLN",
                    RealValue = x.Product.Value,
                    StockId = x.Id,
                    Qty = cartList.FirstOrDefault(y => y.StockId == x.Id).Qty,
                    ImageName =x.Product.ImageName,
                })
                .ToList();


            return response;
        }
    }
}

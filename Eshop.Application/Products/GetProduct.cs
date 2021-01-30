using Eshop.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Application.Products
{
    public class GetProduct
    {
        private ApplicationDbContext _ctx;

        public GetProduct(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<ProductViewModel> Do(string name)
        {
            var stocksOnHold = _ctx.StockOnHolds.Where(x => x.ExpiryDate < DateTime.Now).ToList();

            if (stocksOnHold.Count > 0)
            {
               // var stockToReturn = _ctx.Stock.Where(x => stocksOnHold.Any(y => y.StockId == x.Id)).ToList();

                var stockIds = stocksOnHold.Select(x => x.StockId).ToList();
                var stockToReturn = _ctx.Stock.Where(x => stockIds.Contains(x.Id));
                

                foreach (var stock in stockToReturn)
                {
                    stock.Qty = stock.Qty + stocksOnHold.FirstOrDefault(x => x.StockId == stock.Id).Qty;
                }

                _ctx.StockOnHolds.RemoveRange(stocksOnHold);

                await _ctx.SaveChangesAsync();
            }

            return _ctx.Products
                .Include(x => x.Stock)
                .Where(x => x.Name == name)
                .Select(x => new ProductViewModel
                {
                    Name = x.Name,
                    Description = x.Description,
                    Value = $"{x.Value.ToString("N2")} PLN", //1100.50 => 1,100.50 PLN
                    Stock = x.Stock.Select(y => new StockViewModel
                    {
                        Id = y.Id,
                        Description = y.Description,
                        Qty = y.Qty,
                    }),
                    ImageName = x.ImageName,
                })
                .FirstOrDefault();
        }

        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
            public IEnumerable<StockViewModel> Stock { get; set; }
            public string ImageName { get; set; }
        }

        public class StockViewModel
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public int Qty { get; set; }
            public string ImageName { get; set; }
        }

    }
}

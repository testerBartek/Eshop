using Eshop.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eshop.Application.Products
{
    public class GetProducts
    {
        private ApplicationDbContext _ctx;

        public GetProducts(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<ProductViewModel> Do() =>
            _ctx.Products
                .Include(x => x.Stock)
                .Select(x => new ProductViewModel
                {
                    Name = x.Name,
                    Description = x.Description,
                    Value = $"{x.Value:N2} PLN", //1100.50 => 1,100.50 PLN

                    StockCount = x.Stock.Sum(y => y.Qty),

                    ImageName = x.ImageName,
                })
                .ToList();

        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
            public int StockCount { get; set; }
            public string ImageName { get; set; }
        }
    }
}

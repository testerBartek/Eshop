using Eshop.Database;
using System.Collections.Generic;
using System.Linq;

namespace Eshop.Application.ProductsAdmin
{
    public class GetProducts
    {
        private ApplicationDbContext _ctx;

        public GetProducts(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<ProductViewModel> Do() =>
            _ctx.Products.ToList().Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Value = x.Value,
                ImageName = x.ImageName,

            });

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Value { get; set; }
            public string ImageName { get; set; }
        }
    }
}

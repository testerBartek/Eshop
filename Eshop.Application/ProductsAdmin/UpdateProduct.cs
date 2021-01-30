using Eshop.Database;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Application.ProductsAdmin
{
    public class UpdateProduct
    {
        private ApplicationDbContext _context;

        public UpdateProduct(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Do(Request request)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == request.Id);

            product.Name = request.Name;
            product.Description = request.Description;
            product.Value = request.Value;
            product.ImageName = request.ImageName;

            await _context.SaveChangesAsync();
            return new Response
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Value = product.Value,
                ImageName = product.ImageName,
            };
        }

        public class Request
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
            public string ImageName { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
            public string ImageName { get; set; }
        }
    }
}

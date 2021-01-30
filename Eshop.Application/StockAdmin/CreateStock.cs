using Eshop.Database;
using Eshop.Domain.Models;
using System.Threading.Tasks;

namespace Eshop.Application.StockAdmin
{
    public class CreateStock
    {
        private ApplicationDbContext _context;

        public CreateStock(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Do(Request request)
        {
            var stock = new Stock
            {
                Description = request.Description,
                Qty = request.Qty,
                ProductId = request.ProductId
            };

            _context.Stock.Add(stock);

            await _context.SaveChangesAsync();

            return new Response
            {
                Id = stock.Id,
                Description = stock.Description,
                Qty = stock.Qty
            };
        }
        public class Request
        {
            public int ProductId { get; set; }
            public string Description { get; set; }
            public int Qty { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public int Qty { get; set; }
        }

    }
}

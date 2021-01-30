using Eshop.Application.OrdersAdmin;
using Eshop.Application.StockAdmin;
using Eshop.Application.UsersAdmin;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection @this)
        {
            //OrdersAdmin
            @this.AddTransient<GetOrder>();
            @this.AddTransient<GetOrders>();
            @this.AddTransient<UpdateOrder>();
            @this.AddTransient<CreateUser>();

//TODO: 
     //       //Products
     //       @this.AddTransient<Eshop.Application.Products.GetProduct>();
     //       @this.AddTransient<Eshop.Application.Products.GetProducts>();
     //
     //       //ProductsAdmin
     //       @this.AddTransient<Eshop.Application.ProductsAdmin.GetProduct>();
     //       @this.AddTransient<Eshop.Application.ProductsAdmin.GetProducts>();
     //       @this.AddTransient<Eshop.Application.ProductsAdmin.UpdateProduct>();
     //       @this.AddTransient<Eshop.Application.ProductsAdmin.CreateProduct>();
     //       @this.AddTransient<Eshop.Application.ProductsAdmin.DeleteProduct>();
     //
     //       //StockAdmin
     //       @this.AddTransient<GetStock>();
     //       @this.AddTransient<UpdateStock>();
     //       @this.AddTransient<CreateStock>();
     //       @this.AddTransient<DeleteStock>();
     //
     //       //UsersAdmin
     //       @this.AddTransient<CreateUser>();

            return @this;
        }
    }
}
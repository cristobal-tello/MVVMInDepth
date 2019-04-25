using Sample.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Services
{
    public interface IOrderRepository
    {

        Task<List<Order>> GetOrdersForCustomerAsync(Guid customerId);
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> AddOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(Order order);

        Task<List<Product>> GetProductsAsync();
        Task<List<ProductOptions>> GetProductOptionsAsync();
        Task<List<ProductSize>> GetProductSizesAsync();
        Task<List<ProductStatus>> GetProductStatusesAsync();
    }
}

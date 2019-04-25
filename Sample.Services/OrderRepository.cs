using Sample.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Services
{
    public class OrderRepository : IOrderRepository
    {
        public Task<Order> AddOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrdersForCustomerAsync(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductOptions>> GetProductOptionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductSize>> GetProductSizesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductStatus>> GetProductStatusesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}

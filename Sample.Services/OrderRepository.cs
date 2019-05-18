using Sample.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> listOrderContext;
        private readonly List<Product> listProductContext;
        private readonly List<ProductOptions> listProductOptionsContext;
        private readonly List<ProductSize> listProductSizeContext;
        private readonly List<ProductStatus> listProductStatusContext;

        public OrderRepository()
        {
            listOrderContext = new List<Order>();
            listProductContext = new List<Product>();
            listProductOptionsContext = new List<ProductOptions>();
            listProductSizeContext = new List<ProductSize>();
            listProductStatusContext = new List<ProductStatus>();
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            return await Task.Run(() =>
            {
                listOrderContext.Add(order);
                return order;
            });
        }

        public async Task DeleteOrderAsync(Order order)
        {
            await Task.Run(() => listOrderContext.Remove(order));
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await Task.Run(() => listOrderContext);
        }

        public async Task<List<Order>> GetOrdersForCustomerAsync(Guid customerId)
        {
            return await Task.Run(() => listOrderContext.FindAll(c => c.CustomerId == customerId));
        }

        public async Task<List<ProductOptions>> GetProductOptionsAsync()
        {
            return await Task.Run(() => listProductOptionsContext);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await Task.Run(() => listProductContext);
        }

        public async Task<List<ProductSize>> GetProductSizesAsync()
        {
            return await Task.Run(() => listProductSizeContext);
        }

        public async Task<List<ProductStatus>> GetProductStatusesAsync()
        {
            return await Task.Run(() => listProductStatusContext);
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            return await Task.Run(() =>
            {
                var index = listOrderContext.FindIndex(c => c.Id == order.Id);
                if (index >= 0)
                {
                    listOrderContext[index] = order;
                }
                return (index >= 0) ? order : null;
            });
        }
    }
}

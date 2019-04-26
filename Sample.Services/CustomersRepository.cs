using Sample.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Services
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly List<Customer> context;

        public CustomersRepository()
        {
            context = new List<Customer>()
            {
                new Customer()
                {
                    Id = Guid.Parse("342ffcb6-211f-49ae-bae5-26cb2e1ca63b"),
                    FirstName = "Frank",
                    LastName = "Sinatra",
                    Phone = "555-124124"
                },
                new Customer()
                {
                    Id = Guid.Parse("342ffcb6-211f-49ae-bae5-26cb2e1ca64c"),
                    FirstName = "Robert",
                    LastName = "Duvall",
                    Phone = "432-678225"
                },
                new Customer()
                {
                    Id = Guid.Parse("342ffcb6-211f-49ae-bae5-26cb2e1ca65e"),
                    FirstName = "Charlton",
                    LastName = "Heston",
                    Phone = "982-976781"
                }
            };
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            return await Task.Run(() =>
            {
                context.Add(customer);
                return customer;
            });
        }

        public async Task DeleteCustomerAsync(Customer customer)
        {
            await Task.Run(() => context.Remove(customer));
        }

        public async Task<Customer> GetCustomerAsync(Guid id)
        {
            return await Task.Run(() => context.Find(c => c.Id == id));
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await Task.Run(()=> context);
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            return await Task.Run(() =>
            {
                var index = context.FindIndex(c => c.Id == customer.Id);
                if (index >= 0)
                {
                    context[index] = customer;
                }
                return (index >= 0) ? customer : null;
            });
        }
    }
}

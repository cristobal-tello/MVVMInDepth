using Sample.Data;
using Sample.Services;
using System;
using System.Collections.ObjectModel;

namespace Sample.App.MVVM.Customers.ViewModels
{
    public class CustomerListViewModel : ViewModelBase
    {
        private readonly ICustomersRepository customersRepository;

        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers
        {
            get
            {
                return customers;
            }
            set
            {
                SetProperty(ref customers, value);
            }
        }

        public RelayCommand<Customer> PlaceOrderCommand { get; private set; }
        public RelayCommand AddCustomerCommand { get; private set; }
        public RelayCommand<Customer> EditCustomerCommand { get; private set; }

        public event Action<Guid> PlaceOrderRequested = delegate { };
        public event Action<Customer> AddCustomerResquested = delegate { };
        public event Action<Customer> EditCustomerRequested = delegate { };

        public CustomerListViewModel()
        {
            customersRepository = new CustomersRepository();
            PlaceOrderCommand = new RelayCommand<Customer>(OnPlaceOrder);
            AddCustomerCommand = new RelayCommand(OnAddCustomer);
            EditCustomerCommand = new RelayCommand<Customer>(OnEditCustomer);
        }

        public void LoadCustomers()
        {
            Customers = new ObservableCollection<Customer>(customersRepository.GetCustomers());
        }

        private void OnPlaceOrder(Customer customer)
        {
            PlaceOrderRequested(customer.Id);
        }

        private void OnAddCustomer()
        {
            AddCustomerResquested(new Customer() { Id = Guid.NewGuid() });
        }

        private void OnEditCustomer(Customer customer)
        {
            EditCustomerRequested(customer);
        }
    }
}

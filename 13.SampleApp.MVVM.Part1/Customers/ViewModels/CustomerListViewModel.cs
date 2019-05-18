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

        public CustomerListViewModel()
        {
            customersRepository = new CustomersRepository();
        }

        public void LoadCustomers()
        {
            Customers = new ObservableCollection<Customer>(customersRepository.GetCustomers());
            PlaceOrderCommand = new RelayCommand<Customer>(OnPlaceOrder);
        }

        public event Action<Guid> PlaceOrderRequested = delegate { };

        private void OnPlaceOrder(Customer customer)
        {
            PlaceOrderRequested(customer.Id);
        }
    }
}

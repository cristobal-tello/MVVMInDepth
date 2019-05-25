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

        private string searchText;
        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                SetProperty(ref searchText, value);
                LoadCustomers(searchText);
            }
        }

        public RelayCommand<Customer> PlaceOrderCommand { get; private set; }
        public RelayCommand AddCustomerCommand { get; private set; }
        public RelayCommand<Customer> EditCustomerCommand { get; private set; }
        public RelayCommand ClearSearchCommand { get; private set; }

        public event Action<Guid> PlaceOrderRequested = delegate { };
        public event Action<Customer> AddCustomerResquested = delegate { };
        public event Action<Customer> EditCustomerRequested = delegate { };

        public CustomerListViewModel(ICustomersRepository customersRepo)
        {
            customersRepository = customersRepo;
            PlaceOrderCommand = new RelayCommand<Customer>(OnPlaceOrder);
            AddCustomerCommand = new RelayCommand(OnAddCustomer);
            EditCustomerCommand = new RelayCommand<Customer>(OnEditCustomer);
            ClearSearchCommand = new RelayCommand(OnClearSearch);
        }

        private void OnClearSearch()
        {
            SearchText = string.Empty;
        }

        public void LoadCustomers()
        {
            LoadCustomers(string.Empty);
            // TO-DO: On XAML, CallMethodAction doesn't allow parameters. 
            // Even If LoadCustomer(string searfhText=null), you will get a runtime crash
            // For this reason I need this method
            // Maybe I can try another way using InvokeCommandAction instead
            // With i:InvokeCommandAction  I can call a Command and use CommandParameter
        }

        private void LoadCustomers(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                Customers = new ObservableCollection<Customer>
                    (customersRepository.GetCustomers());

            }
            else
            {
                Customers = new ObservableCollection<Customer>
                    (
                        customersRepository.GetCustomers().FindAll(c => c.FirstName.ToLower().Contains(searchText.ToLower()))
                    );
            }
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
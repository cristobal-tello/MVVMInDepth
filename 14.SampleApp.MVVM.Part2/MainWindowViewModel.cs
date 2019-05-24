using System;
using Sample.App.MVVM;
using Sample.App.MVVM.Customers.ViewModels;
using Sample.App.MVVM.OrderPrep.ViewModels;
using Sample.App.MVVM.Orders.ViewModels;
using Sample.Data;
using Sample.Services;

namespace Sample.App
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly CustomerListViewModel customerListViewModel;
        private readonly OrderViewModel orderViewModel;
        private readonly OrderPrepViewModel orderPrepViewModel;
        private readonly AddEditCustomerViewModel addEditCustomerViewModel;

        public RelayCommand<string> NavigationCommand { get; private set; }

        public MainWindowViewModel()
        {
            ICustomersRepository customersRepository = new CustomersRepository();

            customerListViewModel = new CustomerListViewModel(customersRepository);
            orderViewModel = new OrderViewModel();
            orderPrepViewModel = new OrderPrepViewModel();
            addEditCustomerViewModel = new AddEditCustomerViewModel(customersRepository);

            NavigationCommand = new RelayCommand<string>(OnNavigation);

            customerListViewModel.PlaceOrderRequested += PlaceOrderRequested;
            customerListViewModel.AddCustomerResquested += AddCustomerResquested;
            customerListViewModel.EditCustomerRequested += EditCustomerRequested;
            addEditCustomerViewModel.Done += EditDoneResqueted;

            CurrentViewModel = customerListViewModel;
        }

        private void EditDoneResqueted()
        {
            CurrentViewModel = customerListViewModel;
        }

        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            set => SetProperty(ref currentViewModel, value);
        }

        private void OnNavigation(string destination)
        {
            switch (destination)
            {
                case "customers":
                    CurrentViewModel = customerListViewModel;
                    break;
                case "orderprep":
                    CurrentViewModel = orderPrepViewModel;
                    break; 
                case "orders":
                    CurrentViewModel = orderViewModel;
                    break;
            }
        }

        private void PlaceOrderRequested(Guid customerId)
        {
            orderViewModel.CustomerId = customerId;
            CurrentViewModel = orderViewModel;
        }

        private void EditCustomerRequested(Customer customer)
        {
            addEditCustomerViewModel.EditMode = true;
            addEditCustomerViewModel.SetCustomer(customer);
            CurrentViewModel = addEditCustomerViewModel;

        }

        private void AddCustomerResquested(Customer customer)
        {
            addEditCustomerViewModel.EditMode = false;
            addEditCustomerViewModel.SetCustomer(customer);
            CurrentViewModel = addEditCustomerViewModel;
        }
    }
}

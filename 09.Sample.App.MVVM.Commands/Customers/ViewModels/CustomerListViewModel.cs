using Sample.Data;
using Sample.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Sample.App.MVVM.Customers.ViewModels
{
    public class CustomerListViewModel
    {
        ICustomersRepository customerRepository = new CustomersRepository();
        public ObservableCollection<Customer> Customers { get; set; }

        public RelayCommand DeleteCommand { private get; set; }

        public Customer selectedCustomer;
        public Customer SelectedCustomer
        {
            get
            {
                return selectedCustomer;
            }
            set
            {
                selectedCustomer = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public CustomerListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                return;
            }
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            Customers = new ObservableCollection<Customer>(customerRepository.GetCustomers());
        }

        private bool CanDelete()
        {
            return SelectedCustomer != null;
        }

        private void OnDelete()
        {
            Customers.Remove(SelectedCustomer);
        }
    }
}

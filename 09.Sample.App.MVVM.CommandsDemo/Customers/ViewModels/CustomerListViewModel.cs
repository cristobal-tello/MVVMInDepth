using Sample.Data;
using Sample.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace _09.Sample.App.MVVM.CommandsDemo.Customers.ViewModels
{
    public class CustomerListViewModel
    {
        ICustomersRepository customerRepository = new CustomersRepository();
        public ObservableCollection<Customer> Customers { get; set; }

        public RelayCommand DeleteCommand { get; private set; }

        public Customer SelectedCustomer {
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
        private Customer selectedCustomer;


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

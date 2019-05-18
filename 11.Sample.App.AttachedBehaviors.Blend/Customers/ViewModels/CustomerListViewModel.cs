using Sample.Data;
using Sample.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Sample.App.MVVM.Customers.ViewModels
{
    public class CustomerListViewModel : INotifyPropertyChanged
    {
        ICustomersRepository customerRepository = new CustomersRepository();
        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers
        {
            get
            {
                return customers;
            }
            set
            {
                if (customers != value)
                {
                    customers = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Customers"));
                }
            }
        }

        public RelayCommand DeleteCommand { private get; set; }

        public Customer selectedCustomer;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

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
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        }

        public void LoadCustomers()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                return;
            }
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

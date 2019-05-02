using Sample.Data;
using Sample.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace _08.Sample.App.MVVM.ImplicitTemplates.Customers.ViewModels
{
    public class CustomerListViewModel
    {
        ICustomersRepository customerRepository = new CustomersRepository();
        public ObservableCollection<Customer> Customers { get; set; }

        public CustomerListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                return;
            }

            Customers = new ObservableCollection<Customer>(customerRepository.GetCustomers());
        }
    }
}

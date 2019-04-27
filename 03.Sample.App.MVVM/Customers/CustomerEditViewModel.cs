using Sample.Data;
using Sample.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _03.Sample.App.MVVM.Customers
{
    public class CustomerEditViewModel : INotifyPropertyChanged
    {
        private readonly ICustomersRepository customerRepository;
        private Customer customer;

        public CustomerEditViewModel()
        {
            customerRepository = new CustomersRepository();
            SaveCommand = new RelayCommand(OnSaveAsync);
        }

        public Customer Customer
        {
            get { return customer; }
            set {
                if (value!=customer)
                {
                    customer = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Customer"));
                }
            }
        }

        public Guid CustomerId { get; set; }
        public ICommand SaveCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void OnSaveAsync()
        {
            Customer = await customerRepository.UpdateCustomerAsync(customer);
        }

        public async void LoadCustomer()
        {
            Customer = await customerRepository.GetCustomerAsync(CustomerId);
        }
    }
}

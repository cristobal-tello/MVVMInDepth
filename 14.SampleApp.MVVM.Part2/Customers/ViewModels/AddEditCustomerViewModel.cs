using System;
using System.ComponentModel;
using _14.SampleApp.MVVM.Part2.Customers.Helpers;
using Sample.Data;
using Sample.Services;

namespace Sample.App.MVVM.Customers.ViewModels
{
    public class AddEditCustomerViewModel : ViewModelBase
    {
        private readonly ICustomersRepository customersRepository;

        private bool editMode;
        public bool EditMode
        {
            get
            {
                return editMode;
            }
            set
            {
                SetProperty(ref editMode, value);
            }
        }

        public void SetCustomer(Customer cust)
        {
            if (customer != null)
            {
                customer.ErrorsChanged -= RaiseCanExecutedChanged;
            }

            customer = new EditableCustomer()
            {
                Id = cust.Id,
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Phone = cust.Phone
            };

            this.customer.ErrorsChanged += RaiseCanExecutedChanged;
        }

        private void RaiseCanExecutedChanged(object sender, DataErrorsChangedEventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private EditableCustomer customer;
        public EditableCustomer Customer
        {
            get
            {
                return customer;
            }
            set
            {
                SetProperty(ref customer, value);
            }
        }

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public AddEditCustomerViewModel(ICustomersRepository customerRepo)
        {
            customersRepository = customerRepo;
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }

        public event Action Done = delegate { };

        private bool CanSave()
        {
            return !customer.HasErrors;
        }

        private void OnSave()
        {
            var cust = new Customer()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone
            };

            if (editMode)
            {
                customersRepository.UpdateCustomerAsync(cust);
            }
            else
            {
                customersRepository.AddCustomerAsync(cust);
            }

            Done();
        }

        private void OnCancel()
        {
            Done();
        }
    }
}

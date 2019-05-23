using System;
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

        private Customer customer;
        public void SetCustomer(Customer cust)
        {
            customer = cust;
            simpleEditableCustomer = new SimpleEditableCustomer()
            {
                Id = cust.Id,
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Phone = cust.Phone
            };
        }
        
        private SimpleEditableCustomer simpleEditableCustomer;
        public SimpleEditableCustomer Customer
        {
            get
            {
                return simpleEditableCustomer;
            }
            set
            {
                SetProperty(ref simpleEditableCustomer, value);
            }
        }

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public AddEditCustomerViewModel()
        {
            customer = null;
            customersRepository = new CustomersRepository();
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);

        }

        public event Action Done = delegate { };

        private bool CanSave()
        {
            return true;
        }

        private void OnSave()
        {
            Done();
        }

        private void OnCancel()
        {
            Done();
        }
    }
}

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
        }

        public RelayCommand<Customer> PlaceOrderCommand { get; private set; }

        public AddEditCustomerViewModel()
        {
            customer = null;
            customersRepository = new CustomersRepository();
        }
    }
}

using Sample.Data;
using Sample.Services;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _01.Sample.App.NoMVVM.NoBinding.Customers
{
    /// <summary>
    /// Interaction logic for CustomerEditView.xaml
    /// </summary>
    public partial class CustomerEditView : UserControl
    {
        private readonly ICustomersRepository customerRepository;
        private Customer customer;

        public CustomerEditView()
        {
            customerRepository = new CustomersRepository();
            InitializeComponent();
        }

        public Guid CustomerId
        {
            get { return (Guid)GetValue(CustomerIdProperty); }
            set { SetValue(CustomerIdProperty, value); }
        }

        public static readonly DependencyProperty CustomerIdProperty = DependencyProperty.Register("CustomerId", typeof(Guid), typeof(CustomerEditView), new PropertyMetadata(Guid.Empty));

        public async void OnSaveAsync(object sender, RoutedEventArgs e)
        {
            customer.FirstName = firstNameTextBox.Text;
            customer.LastName = lastNameTextBox.Text;
            customer.Phone = phoneTextBox.Text;
            await customerRepository.UpdateCustomerAsync(customer);
        }

        public async void OnLoadedAsync(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }
            customer = await customerRepository.GetCustomerAsync(CustomerId);
            if (customer == null)
            {
                return;
            }
            firstNameTextBox.Text = customer.FirstName;
            lastNameTextBox.Text = customer.LastName;
            phoneTextBox.Text = customer.Phone;
        }
    }
}

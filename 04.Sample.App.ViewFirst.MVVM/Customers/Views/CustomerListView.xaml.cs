using _04.Sample.App.MVVM.ViewFirst.Customers.ViewModels;
using System.Windows.Controls;

namespace _04.Sample.App.MVVM.ViewFirst.Customers.Views
{
    /// <summary>
    /// Interaction logic for CustomerListView.xaml
    /// </summary>
    public partial class CustomerListView : UserControl
    {
        public CustomerListView()
        {
            this.DataContext = new CustomerListViewModel();
            InitializeComponent();
        }
    }
}

using _06.Sample.App.MVVM.DataBindings.DataFlows.Customers.ViewModels;
using System.Windows.Controls;

namespace _06.Sample.App.MVVM.DataBindings.DataFlows.Customers.Views
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

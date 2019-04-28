using _04.Sample.App.ViewFirst.MVVM.ViewModel;
using System.Windows.Controls;

namespace _04.Sample.App.ViewFirst.MVVM.Customers
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

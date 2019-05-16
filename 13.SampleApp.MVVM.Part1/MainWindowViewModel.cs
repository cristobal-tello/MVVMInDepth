using Sample.App.MVVM;
using Sample.App.MVVM.Customers.ViewModels;
using Sample.App.MVVM.OrderPrep.ViewModels;
using Sample.App.MVVM.Orders.ViewModels;

namespace Sample.App
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly CustomerListViewModel customerListViewModel;
        private readonly OrderViewModel orderViewModel;
        private readonly OrderPrepViewModel orderPrepViewModel;

        public RelayCommand<string> NavigationCommand { get; private set; }

        public MainWindowViewModel()
        {
            customerListViewModel = new CustomerListViewModel();
            orderViewModel = new OrderViewModel();
            orderPrepViewModel = new OrderPrepViewModel();

            NavigationCommand = new RelayCommand<string>(OnNavigation);

            CurrentViewModel = customerListViewModel;
        }

        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            set => SetProperty(ref currentViewModel, value);
        }

        private void OnNavigation(string destination)
        {
            switch (destination)
            {
                case "customers":
                    CurrentViewModel = customerListViewModel;
                    break;
                case "orderprep":
                    CurrentViewModel = orderPrepViewModel;
                    break;
                case "orders":
                    CurrentViewModel = orderViewModel;
                    break;
            }
        }
    }
}

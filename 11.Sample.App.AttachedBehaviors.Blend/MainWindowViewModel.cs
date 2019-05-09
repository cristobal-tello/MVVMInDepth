using Sample.App.MVVM.Customers.ViewModels;

namespace Sample.App
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            CurrentViewModel = new CustomerListViewModel();
        }

        public object CurrentViewModel {get; set;}
    }
}

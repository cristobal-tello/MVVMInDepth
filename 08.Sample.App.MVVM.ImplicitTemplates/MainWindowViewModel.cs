using _08.Sample.App.MVVM.ImplicitTemplates.Customers.ViewModels;

namespace _08.Sample.App.MVVM.ImplicitTemplates
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

using Sample.App.MVVM.Customers.ViewModels;
using System;
using System.ComponentModel;
using System.Timers;

namespace Sample.App
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private Timer timer = new Timer(5000);


        public MainWindowViewModel()
        {
            CurrentViewModel = new CustomerListViewModel();

            timer.Elapsed += (s, e) =>
              {
                  NotificationMessage = string.Format($"At the tone the time will be : {DateTime.Now.ToLocalTime()}");
                  

              };
            timer.Start();
        }

       

        public object CurrentViewModel {get; set;}

        private string notificationMessage;
        public string NotificationMessage
        {
            get
            {
                return notificationMessage;
            }
            set
            {
                if (value != notificationMessage)
                {
                    notificationMessage = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("NotificationMessage"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}

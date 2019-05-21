using System;

namespace Sample.App.MVVM.Orders.ViewModels
{
    public class OrderViewModel : ViewModelBase
    {
        private Guid customerId;
        public Guid CustomerId
        {
            get
            {
                return customerId; ;
            }
            set
            {
                SetProperty(ref customerId, value);
            }
        }
    }
}

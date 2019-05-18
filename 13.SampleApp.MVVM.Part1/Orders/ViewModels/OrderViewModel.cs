using System;
using System.ComponentModel;

namespace Sample.App.MVVM.Orders.ViewModels
{
    public class OrderViewModel : ViewModelBase
    {
        public Guid CustomerId { get; internal set; }
    }
}

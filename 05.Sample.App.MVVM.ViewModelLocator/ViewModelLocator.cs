using System;
using System.Windows;

namespace _05.Sample.App.MVVM.ViewModelLocator
{
    public static class ViewModelLocator
    {
        public static bool GetAutoWireViewModel(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoWireViewModelProperty, value);
        }

        public static readonly DependencyProperty AutoWireViewModelProperty =
            DependencyProperty.RegisterAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), new PropertyMetadata(false, AutoWireViewModelChange));

        private static void AutoWireViewModelChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var viewType = d.GetType();

            var viewModelTypeName = string.Format($"{viewType.FullName}_").Replace("View_", "ViewModel").Replace(".Views.", ".ViewModels.");

            var viewModelType = Type.GetType(viewModelTypeName);

            var viewModel = Activator.CreateInstance(viewModelType);
            ((FrameworkElement)d).DataContext = viewModel;
        }
    }
}

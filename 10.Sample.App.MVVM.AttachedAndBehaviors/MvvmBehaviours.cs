using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sample.App.MVVM
{
    public class MvvmBehaviours
    {
        public static string GetLoadedMethodName(DependencyObject obj)
        {
            return (string) obj.GetValue(LoadedMethodNameProperty);
        }

        public static void SetLoadedMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(LoadedMethodNameProperty, value);
        }

        public static readonly DependencyProperty LoadedMethodNameProperty =
            DependencyProperty.RegisterAttached(
                "LoadedMethodName",
                typeof(string),
                typeof(MvvmBehaviours),
                new PropertyMetadata(OnLoadedMethodNameChange));

        private static void OnLoadedMethodNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as FrameworkElement;
            if (element != null)
            {
                element.Loaded += (s, ea) =>
                    {
                        var viewModel = element.DataContext;
                        if (viewModel != null)
                        {
                            var methodInfo = viewModel.GetType().GetMethod(e.NewValue.ToString());
                            methodInfo?.Invoke(viewModel, null);
                        }
                    };
            }
        }
    }
}

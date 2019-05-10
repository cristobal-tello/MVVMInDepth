using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace Sample.App
{
    public class ShowNotificationMessageBehavior : Behavior<ContentControl>
    {
        public string Message
        {
            get
            {
                return (string)GetValue(MessageProperty);
            }
            set
            {
                SetValue(MessageProperty, value);
            }
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(ShowNotificationMessageBehavior), new PropertyMetadata(null, OnMessageChanged));

        private static void OnMessageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = ((ShowNotificationMessageBehavior)d);
            behavior.AssociatedObject.Content = e.NewValue;
            behavior.AssociatedObject.Visibility = Visibility.Visible;
        }

        protected override void OnAttached()
        {
            AssociatedObject.MouseLeftButtonDown += (s, e) =>
              {
                  AssociatedObject.Visibility = Visibility.Collapsed;
              };
        }
    }
}

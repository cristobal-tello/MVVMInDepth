using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sample.App
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected virtual void SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
        {
            if (!object.Equals(member, val))
            {
                member = val;
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}


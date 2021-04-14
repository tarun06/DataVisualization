using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataVisualization
{
    public abstract class NotifyPropertyBase : INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
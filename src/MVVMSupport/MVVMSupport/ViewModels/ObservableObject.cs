using System.ComponentModel;

namespace MVVMSupport.ViewModels
{
    /// <summary>
    /// Represents an object that will notify clients when it is changed.
    /// </summary>
    public abstract class ObservableObject : INotifyPropertyChanged, INotifyPropertyChanging
    {
        /// <summary>
        /// Notifies clients that a property value has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged
        {
            add { _propertyChanged += value; }
            remove { _propertyChanged -= value; }
        }

        /// <summary>
        /// Notifies clients that a property is changing.
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanging
        {
            add { _propertyChanging += value; }
            remove { _propertyChanging -= value; }
        }

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property that was changed.</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            if (_propertyChanged != null)
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises the PropertyChanging event.
        /// </summary>
        /// <param name="propertyName">The name of the property that was changed.</param>
        protected void RaisePropertyChanging(string propertyName)
        {
            if (_propertyChanging != null)
                _propertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }

        private event PropertyChangedEventHandler _propertyChanged;
        private event PropertyChangingEventHandler _propertyChanging;
    }
}

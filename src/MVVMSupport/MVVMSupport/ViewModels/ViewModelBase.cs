using System.ComponentModel;
using System.Windows;

namespace MVVMSupport.ViewModels
{
    /// <summary>
    /// Represents a base class for view models that is observable.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets a bool value representing whether the program is operating in design mode.
        /// </summary>
        public bool IsInDesingMode
        {
            get { return is_in_design_mode; }
        }

        /// <summary>
        /// Gets a bool value representing whether the program is operating in design mode.
        /// </summary>
        public static bool IsInDesignModeStatic
        {
            get { return is_in_design_mode; }
        }

        private static readonly bool is_in_design_mode = DesignerProperties.GetIsInDesignMode(new DependencyObject());

        #region INotifyPropertyChanged members
        /// <summary>
        /// Notifies clients when a property has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged
        {
            add { _propertyChanged += value; }
            remove { _propertyChanged -= value; }
        }

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            if(_propertyChanged != null)
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private event PropertyChangedEventHandler _propertyChanged;
        #endregion
    }
}

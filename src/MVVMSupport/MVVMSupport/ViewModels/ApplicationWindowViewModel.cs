using MVVMSupport.ViewModels.ViewModelInterfaces;

namespace MVVMSupport.ViewModels
{
    /// <summary>
    /// Represnts the viewmodel for an application window.
    /// If used with an instance of ApplicationWindow, requesting hide, show, or close will call the corresponding method on the window.
    /// </summary>
    public class ApplicationWindowViewModel : ViewModelBase, IHideableViewModel, ICloseableViewModel, IShowableViewMdoel
    {
        /// <summary>
        /// Notifies clients that the viewmodel requested to hide.
        /// </summary>
        public event HideViewRequestedHandler HideViewRequested
        {
            add { _hideViewRequested += value; }
            remove { _hideViewRequested -= value; }
        }

        /// <summary>
        /// Notifies clients that the viewmodel requested to close.
        /// </summary>
        public event CloseViewRequestedHandler CloseViewRequested
        {
            add { _closeViewRequested += value; }
            remove { _closeViewRequested -= value; }
        }

        /// <summary>
        /// Notifies clients that the viewmodel requested to show.
        /// </summary>
        public event ShowViewRequestedHandler ShowViewRequested
        {
            add { _showViewRequested += value; }
            remove { _showViewRequested -= value; }
        }

        /// <summary>
        /// Request to close the view for this viewmodel.
        /// </summary>
        protected void RequestCloseView()
        {
            if (_closeViewRequested != null)
                _closeViewRequested(this);
        }

        /// <summary>
        /// Request to show the view for this viewmodel.
        /// </summary>
        protected void RequestShowView()
        {
            if (_showViewRequested != null)
                _showViewRequested(this);
        }

        /// <summary>
        /// Request to hide the view for this viewmodel.
        /// </summary>
        protected void RequestHideView()
        {
            if (_hideViewRequested != null)
                _hideViewRequested(this);
        }

        private event HideViewRequestedHandler _hideViewRequested;
        private event CloseViewRequestedHandler _closeViewRequested;
        private event ShowViewRequestedHandler _showViewRequested;
    }
}

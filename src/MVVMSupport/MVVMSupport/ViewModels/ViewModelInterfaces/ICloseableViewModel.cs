namespace MVVMSupport.ViewModels.ViewModelInterfaces
{
    /// <summary>
    /// Represents a viewmodel whose view can be closed.
    /// </summary>
    public interface ICloseableViewModel
    {
        /// <summary>
        /// Notifies clients that the viewmodel requested to close.
        /// </summary>
        event CloseViewRequestedHandler CloseViewRequested;
    }

    /// <summary>
    /// Represnts the method that will handle the CloseViewRequested event raised when a viewmodel requests to close.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    public delegate void CloseViewRequestedHandler(object sender);
}

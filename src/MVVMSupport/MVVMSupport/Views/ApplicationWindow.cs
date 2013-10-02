using MVVMSupport.ViewModels;
using System.Windows;

namespace MVVMSupport.Views
{
    /// <summary>
    /// Represnts an Window which has a viewmodel that needs to be able to control its show, hide, and close methods.
    /// </summary>
    public abstract class ApplicationWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of ApplicationWindow.
        /// </summary>
        public ApplicationWindow()
        {
            DataContextChanged += OnDataContextChanged;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(e.NewValue is ApplicationWindowViewModel)
            {
                ApplicationWindowViewModel vm = e.NewValue as ApplicationWindowViewModel;
                vm.HideViewRequested += (s) => Hide();
                vm.CloseViewRequested += (s) => Close();
                vm.ShowViewRequested += (s) => Show();
            }
        }
    }
}

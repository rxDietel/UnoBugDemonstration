using System.Threading.Tasks;
using BugDemonstration.Shell;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BugDemonstration
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShellPage : Page
    {
        #region Constructors

        public ShellPage(ShellViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }

        #endregion

        #region Methods

        private void NavigationView_OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var item = args.InvokedItem as IShellMenuItem;
            item ??= args.InvokedItemContainer?.DataContext as IShellMenuItem;

            if (args.InvokedItem is FrameworkElement element) item ??= element.DataContext as IShellMenuItem;

            if (item != null)
                if (item.Command?.CanExecute(null) ?? false)
                    item.Command.Execute(null);
        }

        private void NavigationView_OnSelectionChanged(NavigationView sender,
            NavigationViewSelectionChangedEventArgs args)
        {
            var item = args.SelectedItem as IShellContentItem;
            item ??= args.SelectedItemContainer?.DataContext as IShellContentItem;

            if (args.SelectedItem is FrameworkElement element) item ??= element.DataContext as IShellContentItem;
#if HAS_UNO
            if (args.SelectedItem is IShellMenuItem menuItem)
            {
                if (menuItem?.Command?.CanExecute(null) ?? false)
                {
                    Task.Run(() => menuItem.Command.Execute(null));
                }
            }
            else
            {
                Nav.Content = item?.ContentControl;
            }
#else
            Nav.Content = item?.ContentControl;
#endif
        }

        #endregion
    }
}
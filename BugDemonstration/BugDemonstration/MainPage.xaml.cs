using System.Collections.ObjectModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BugDemonstration
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            items.Add(Model.Instance);
            items.Add(Model.Instance);
            this.InitializeComponent();

            myComboBox.SelectedIndex = 0;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Model.Instance.Count++;
        }

        private ObservableCollection<Model> items { get; set; } = new ObservableCollection<Model>();
    }
}

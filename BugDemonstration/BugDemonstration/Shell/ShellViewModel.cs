using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;

namespace BugDemonstration.Shell;

public partial class ShellViewModel : ObservableObject
{
    #region Constructors

    public ShellViewModel()
    {
        Dispatcher = DispatcherQueue.GetForCurrentThread();

        ShellItems.Add(_floorPlanRoot);
        _addFloorPlanEditor.Command = AddEditorCommand;
        ShellItems.Add(_addFloorPlanEditor);

        FooterItems.Add(new ShellContentItem
        {
            Title = "Settings Page",
            ContentControl = new MainPage()
        });
        FooterItems.Add(new ShellMenuItem
        {
            Title = "Logout",
            Command = LogoutCommand
        });

        ShowFirstPage();
    }

    #endregion

    #region Fields

    // ReSharper disable once NotAccessedField.Local
    private readonly ShellItem _floorPlanRoot = new()
        { Title = "floorplans" };

    private readonly ShellMenuItem _addFloorPlanEditor = new()
    {
        Title = "Add Editor"
    };

    [ObservableProperty] [NotifyPropertyChangedFor(nameof(CurrentPageTitle))]
    private IShellItem? _selectedItem;

    [ObservableProperty] private ObservableCollection<IShellItem> _footerItems = new();

    [ObservableProperty] private ObservableCollection<IShellItem> _shellItems = new();

    #endregion

    #region Properties

    public string CurrentPageTitle => SelectedItem?.Title ?? "";

    private DispatcherQueue Dispatcher { get; }

    #endregion

    #region Methods

    [RelayCommand]
    private void Logout()
    {
        Application.Current.Exit();
    }

    [RelayCommand]
    private async Task AddEditor()
    {
        var index = _floorPlanRoot.Children!.Count + 1;

        await Task.Run(() =>
        {
            Dispatcher.TryEnqueue(() =>
            {
                _floorPlanRoot.Children.Add(new ShellContentItem
                {
                    Title = $"MenuItem {index}",
                    ContentControl = new MainPage()
                });
                ShowFirstPage(_floorPlanRoot.Children.Reverse());
            });
        });
    }

    private void ShowFirstPage()
    {
        if (!ShowFirstPage(ShellItems)) ShowFirstPage(FooterItems);
    }

    private bool ShowFirstPage(IEnumerable<IShellItem>? items)
    {
        if (items == null) return false;

        foreach (var item in items)
        {
            if (item is IShellContentItem contentItem)
                if (contentItem.ContentControl != null)
                {
                    SelectedItem = contentItem;
                    return true;
                }

            if (ShowFirstPage(item.Children)) return true;
        }

        return false;
    }

    #endregion
}
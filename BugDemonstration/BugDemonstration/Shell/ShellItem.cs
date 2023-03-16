using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;

namespace BugDemonstration.Shell;

public partial class ShellItem : ObservableObject, IShellItem
{
    #region Constructors

    #endregion

    #region Fields

    [ObservableProperty] private string _title = "Title not Set.";

    [ObservableProperty] private Visibility _visibility = Visibility.Visible;

    [ObservableProperty] private bool _isSelected;
    [ObservableProperty] private bool _isChildSelected;

    #endregion

    #region Properties

    public virtual ObservableCollection<IShellItem>? Children { get; } = new();
    public virtual bool IsSelectable => false;

    #endregion

    #region Methods

    #endregion
}
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;

namespace BugDemonstration.Shell;

public partial class ShellContentItem : ShellItem, IShellContentItem
{
    #region Fields

    [ObservableProperty] private Control? _contentControl;

    #endregion

    #region Properties

    public override bool IsSelectable => true;
    public override ObservableCollection<IShellItem>? Children => null;

    #endregion
}
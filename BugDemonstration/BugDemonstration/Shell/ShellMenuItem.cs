using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BugDemonstration.Shell;

public partial class ShellMenuItem : ShellItem, IShellMenuItem
{
    #region Fields

    [ObservableProperty] private ICommand? _command;

    #endregion

    #region Properties

    public override ObservableCollection<IShellItem>? Children => null;

    #endregion
}
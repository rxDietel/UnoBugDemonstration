using System.Windows.Input;

namespace BugDemonstration.Shell;

public interface IShellMenuItem : IShellItem
{
    #region Properties

    ICommand? Command { get; }

    #endregion
}
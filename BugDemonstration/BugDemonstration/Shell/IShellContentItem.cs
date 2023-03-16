using Microsoft.UI.Xaml.Controls;

namespace BugDemonstration.Shell;

public interface IShellContentItem : IShellItem
{
    #region Properties

    Control? ContentControl { get; }

    #endregion
}
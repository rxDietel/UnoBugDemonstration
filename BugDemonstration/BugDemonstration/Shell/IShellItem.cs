using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.UI.Xaml;

namespace BugDemonstration.Shell;

public interface IShellItem : INotifyPropertyChanged
{
    #region Properties

    public string Title { get; }

    public bool IsSelectable { get; }

    public ObservableCollection<IShellItem>? Children { get; }

    public Visibility Visibility { get; }

    public bool IsSelected { get; set; }

    public bool IsChildSelected { get; set; }

    #endregion
}
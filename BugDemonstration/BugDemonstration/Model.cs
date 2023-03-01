using CommunityToolkit.Mvvm.ComponentModel;

namespace BugDemonstration;

public partial class Model : ObservableObject
{
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(Value))]
    private int _count;

    private Model()
    {
    }

    public string Value => $"Button clicked {Count} times.";

    public static Model Instance { get; } = new();
}
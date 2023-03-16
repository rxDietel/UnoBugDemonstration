using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Markup;

namespace BugDemonstration;

[MarkupExtensionReturnType(ReturnType = typeof(Binding))]
public class MyExtension : MarkupExtension
{
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once UnusedMember.Global
    public string? _PositionalParameters { get; set; }

    protected override object ProvideValue()
    {

        return new Binding
        {
            Source = Model.Instance,
            Path = new PropertyPath(nameof(Model.Value)),
            Mode = BindingMode.OneWay
        };
    }
}
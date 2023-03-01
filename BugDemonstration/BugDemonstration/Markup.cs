using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Markup;

namespace BugDemonstration;

[MarkupExtensionReturnType(ReturnType = typeof(Binding))]
public class MyExtension : MarkupExtension
{
    public string _PositionalParameters { get; set; }

    protected override object ProvideValue()
    {

        return new Binding
        {
            Source = BugDemonstration.Model.Instance,
            Path = new PropertyPath(nameof(BugDemonstration.Model.Value)),
            Mode = BindingMode.OneWay
        };
    }
}
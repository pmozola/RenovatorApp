using Syncfusion.Maui.Toolkit.Charts;

namespace RenovatorApp.UI.Pages.Controls;

public class LegendExt : ChartLegend
{
    protected override double GetMaximumSizeCoefficient()
    {
        return 0.5;
    }
}
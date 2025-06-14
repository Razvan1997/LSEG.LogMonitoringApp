using LSEG.LogMonitoring.Core.Modules.UIRegions;
using System.Windows.Controls;

namespace LSEG.LogMonitoring.Modules.LogAnalyzer.Views
{
    /// <summary>
    /// Interaction logic for LogAnalyzerView.xaml.
    /// This view displays job execution data and defines an internal region ("StatsRegion")
    /// for displaying additional views such as statistics or summaries
    /// </summary>
    public partial class LogAnalyzerView : UserControl
    {
        public LogAnalyzerView(IRegionManager regionManager)
        {
            InitializeComponent();
            // Register the internal region so other modules can inject content below the DataGrid
            regionManager.RegisterRegion("StatsRegion", StatsRegion);
        }
    }
}

using LSEG.LogMonitoring.Core.Modules.UIRegions;
using System.Windows;

namespace LSEG.LogMonitoringApp
{
    /// <summary>
    /// The main shell window of the application.
    /// Hosts the primary UI region ("MainRegion") used by modules to inject views.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// Registers the "MainRegion" so that modules can inject their views into this area.
        /// </summary>
        /// <param name="regionManager">The region manager used for registering regions.</param>
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();

            // Register the ContentControl named "MainRegion" for module view injection
            regionManager.RegisterRegion("MainRegion", MainRegion);
        }
    }
}
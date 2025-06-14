using System.Configuration;
using System.Data;
using System.Windows;

namespace LSEG.LogMonitoringApp
{
    /// <summary>
    /// The entry point for the WPF application.
    /// Initializes the modular infrastructure and starts the main window.
    /// </summary>
    public partial class App : Application
    {
        private Bootstrapper _bootstrapper;
        /// <summary>
        /// Called when the application starts.
        /// Sets up the bootstrapper, registers modules, 
        /// and shows the main window.
        /// </summary>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialize application infrastructure
            _bootstrapper = new Bootstrapper();
            _bootstrapper.RegisterModules();

            // Create and show main window
            var mainWindow = new MainWindow(_bootstrapper.GetRegionManager());
            mainWindow.Show();

            // Initialize module views and logic
            _bootstrapper.InitializeModules();
        }
    }

}

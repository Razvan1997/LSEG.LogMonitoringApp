
using LSEG.LogMonitoring.Core.Modules.EventAggregator;
using LSEG.LogMonitoring.Core.Modules.UIRegions;
using LSEG.LogMonitoring.Core2.Modules;
using LSEG.LogMonitoring.Modules.LogAnalyzer.ViewModels;
using LSEG.LogMonitoring.Modules.LogAnalyzer.Views;

namespace LSEG.LogMonitoring.Modules
{
    /// <summary>
    /// Represents the log analyzer module that initializes the view and 
    /// registers it into the main region. It also uses an event aggregator 
    /// for cross-module communication
    /// </summary>
    public class LogAnalyzerModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;

        /// <summary>
        /// Initializes a new instance of the LogAnalyzerModule class.
        /// </summary>
        /// <param name="regionManager">The region manager used to register views into UI regions.</param>
        /// <param name="eventAggregator">The event aggregator used to publish and subscribe to application-wide messages</param>
        public LogAnalyzerModule(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
        }

        /// <summary>
        /// Initializes the module by creating its view and view model,
        /// setting up data context, and registering the view in the main UI region
        /// </summary>
        public void Initialize()
        {
            var viewModel = new LogAnalyzerViewModel(_eventAggregator);

            var view = new LogAnalyzerView(_regionManager)
            {
                DataContext = viewModel
            };

            _regionManager.RegisterView("MainRegion", view);
        }
    }
}

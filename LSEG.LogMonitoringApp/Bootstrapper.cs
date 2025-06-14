using LSEG.LogMonitoring.Core.Modules.EventAggregator;
using LSEG.LogMonitoring.Core.Modules.UIRegions;
using LSEG.LogMonitoring.Core2.Modules;
using LSEG.LogMonitoring.Module.Stats;
using LSEG.LogMonitoring.Modules;

namespace LSEG.LogMonitoringApp
{
    /// <summary>
    /// Responsible for configuring and initializing application modules.
    /// Handles region registration and sets up event-based communication between modules.
    /// </summary>
    public class Bootstrapper
    {
        private readonly List<IModule> _modules = new();
        private readonly RegionManager _regionManager = new();
        private readonly IEventAggregator _eventAggregator = new EventAggregator();

        /// <summary>
        /// Provides access to the event aggregator instance used across modules.
        /// </summary>
        public IEventAggregator GetEventAggregator() => _eventAggregator;

        /// <summary>
        /// Manually registers all modules in the application.
        /// Each module receives shared services like region manager and event aggregator.
        /// </summary>
        public void RegisterModules()
        {
            var logAnalyzer = new LogAnalyzerModule(_regionManager, _eventAggregator);
            var logStats = new LogStatsModule(_regionManager, _eventAggregator);

            _modules.Add(logAnalyzer);
            _modules.Add(logStats);
        }

        /// <summary>
        /// Initializes all registered modules by calling their Initialize method.
        /// This loads their views and registers them into defined regions.
        /// </summary>
        public void InitializeModules()
        {
            foreach (var module in _modules)
                module.Initialize();
        }

        /// <summary>
        /// Returns the instance of the region manager used to register UI regions.
        /// </summary>
        public RegionManager GetRegionManager() => _regionManager;
    }
}

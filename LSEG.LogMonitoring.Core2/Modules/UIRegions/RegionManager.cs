using System.Windows.Controls;

namespace LSEG.LogMonitoring.Core.Modules.UIRegions
{
    /// <summary>
    /// A simple region manager that allows views to be registered
    /// into named WPF ContentControls at runtime, enabling modular UI composition
    /// </summary>
    public class RegionManager : IRegionManager
    {
        private readonly Dictionary<string, ContentControl> _regions = new();

        /// <summary>
        /// Registers a WPF ContentControl as a region by name.
        /// </summary>
        /// <param name="name">The name of the region (e.g., "MainRegion")</param>
        /// <param name="control">The ContentControl that represents the region</param>
        public void RegisterRegion(string name, object control)
        {
            if (control is ContentControl contentControl && !_regions.ContainsKey(name))
            {
                _regions.Add(name, contentControl);
            }
        }

        /// <summary>
        /// Injects a view into a previously registered region by name
        /// </summary>
        /// <param name="regionName">The name of the region to inject into</param>
        /// <param name="view">The view (UserControl) to display in the region</param>
        public void RegisterView(string regionName, object view)
        {
            if (_regions.TryGetValue(regionName, out var region))
            {
                region.Content = view;
            }
        }
    }
}

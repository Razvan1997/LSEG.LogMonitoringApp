namespace LSEG.LogMonitoring.Core.Modules.UIRegions
{
    public interface IRegionManager
    {
        void RegisterRegion(string regionName, object regionControl);
        void RegisterView(string regionName, object view);
    }
}

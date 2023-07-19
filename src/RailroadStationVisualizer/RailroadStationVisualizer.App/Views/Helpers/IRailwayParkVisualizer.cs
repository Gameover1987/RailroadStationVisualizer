using RailroadStationVisualizer.App.Model;

namespace RailroadStationVisualizer.App.Views.Helpers
{
    public interface IRailwayParkVisualizer
    {
        RailwayPoint[] GetParkPoints(string park, RailwaySection[] sections);
    }
}
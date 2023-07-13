using RailroadStationVisualizer.Model;

namespace RailroadStationVisualizer.App.Model
{
    public interface IStationSchemaProvider
    {
        StationSchema GetStationSchema();
    }
}
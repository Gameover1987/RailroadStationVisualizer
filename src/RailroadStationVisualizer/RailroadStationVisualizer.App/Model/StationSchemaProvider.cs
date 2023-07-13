using RailroadStationVisualizer.Model;

namespace RailroadStationVisualizer.App.Model
{
    public class StationSchemaProvider : IStationSchemaProvider
    {
        public StationSchema GetStationSchema() {
            return new StationSchema();
        }
    }
}

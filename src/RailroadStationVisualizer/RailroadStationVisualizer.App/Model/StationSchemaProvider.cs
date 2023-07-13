using RailroadStationVisualizer.Model;

namespace RailroadStationVisualizer.App.Model
{
    public class StationSchemaProvider : IStationSchemaProvider
    {
        public StationSchema GetStationSchema() {
            var parks = new[] {
                new RailwayPark {Name = "Парк 1"},
                new RailwayPark {Name = "Парк 2"},
                new RailwayPark {Name = "Парк 3"},
            };

            return new StationSchema { StationName = "Кукуево", Parks = parks };
        }
    }
}

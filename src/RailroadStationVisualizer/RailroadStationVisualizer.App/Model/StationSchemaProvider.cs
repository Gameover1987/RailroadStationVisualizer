using System.Windows;

namespace RailroadStationVisualizer.App.Model
{
    public class StationSchemaProvider : IStationSchemaProvider
    {
        public StationSchema GetStationSchema() {
            var parks = new[] {
                GetPark1(),
                //new RailwayPark {Name = "Парк 2"},
                //new RailwayPark {Name = "Парк 3"},
            };

            return new StationSchema { StationName = "Кукуево", Parks = parks };
        }

        private static RailwayPark GetPark1() {

            var tracks = new RailwayTrack[] {
                new RailwayTrack {
                    Name = "1 - Верхний короткий",
                    Sections = new[] {
                        new RailwaySection {
                            Start = new Point(160, 119),
                            End = new Point(233, 119)
                        },
                        new RailwaySection {
                            Start = new Point(233, 119),
                            End = new Point(299, 119)
                        },
                        new RailwaySection {
                            Start = new Point(299, 119),
                            End = new Point(317, 106)
                        }
                    }
                },
            };

            var park = new RailwayPark { Name = "Парк 1", Tracks = tracks };
            return park;
        }
    }
}

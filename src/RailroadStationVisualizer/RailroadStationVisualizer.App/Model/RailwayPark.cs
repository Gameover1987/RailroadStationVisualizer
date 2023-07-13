namespace RailroadStationVisualizer.App.Model
{
    /// <summary>
    /// ЖД парк
    /// </summary>
    public class RailwayPark
    {
        public RailwayPark() {
            Tracks = new RailwayTrack[0];
        }

        public string Name { get; set; }

        public RailwayTrack[] Tracks { get; set; }
    }
}
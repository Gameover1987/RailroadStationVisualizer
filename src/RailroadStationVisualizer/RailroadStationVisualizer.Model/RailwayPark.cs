namespace RailroadStationVisualizer.Model
{
    /// <summary>
    /// ЖД парк
    /// </summary>
    public class RailwayPark
    {
        public string Name { get; set; }

        public RailwayTrack[] Tracks { get; set; }
    }
}
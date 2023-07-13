namespace RailroadStationVisualizer.App.Model
{
    /// <summary>
    /// ЖД путь
    /// </summary>
    public class RailwayTrack
    {
        public RailwayTrack() {
            Sections = new RailwaySection[0];
        }

        public string Name { get; set; }

        public RailwaySection[] Sections { get; set; }
    }
}
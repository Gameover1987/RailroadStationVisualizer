namespace RailroadStationVisualizer.App.Model
{
    /// <summary>
    /// ЖД путь
    /// </summary>
    public class RailwayTrack
    {
        public RailwayTrack(RailwaySection[] sections, string park = "") {
            Sections = sections;
            foreach (var section in sections) {
                section.Track = this;
            }

            Park = park;
        }

        /// <summary>
        /// Парк
        /// </summary>
        public string Park { get; set; }

        /// <summary>
        /// Набор отрезков составляющих путь
        /// </summary>
        public RailwaySection[] Sections { get; set; }
    }
}
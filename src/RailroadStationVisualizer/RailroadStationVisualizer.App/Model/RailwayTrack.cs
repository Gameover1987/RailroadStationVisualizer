using System.Collections.Generic;

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

        public string Park { get; set; }

        public RailwaySection[] Sections { get; set; }
    }
}
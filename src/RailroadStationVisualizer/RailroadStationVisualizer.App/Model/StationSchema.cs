namespace RailroadStationVisualizer.App.Model
{
    /// <summary>
    /// Схема ЖД станции
    /// </summary>
    public class StationSchema
    {
        /// <summary>
        /// Название ЖД станции
        /// </summary>
        public string StationName { get; set; }

        /// <summary>
        /// Список путей ЖД станции
        /// </summary>
        public RailwayTrack[] Tracks { get; set; }
    }
}

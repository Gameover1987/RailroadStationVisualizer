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
        /// Список участков ЖД станции
        /// </summary>
        public RailwaySection[] Sections { get; set; }
    }
}

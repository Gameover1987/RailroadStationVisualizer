namespace RailroadStationVisualizer.Model
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
        /// Список парков ЖД станции
        /// </summary>
        public RailwayPark[] Parks { get; set; }
    }
}

namespace RailroadStationVisualizer.App.Model
{
    /// <summary>
    /// Поставщик схемы ЖД станции
    /// </summary>
    public interface IStationSchemaProvider
    {
        /// <summary>
        /// Возвращает схему станции
        /// </summary>
        /// <returns></returns>
        StationSchema GetStationSchema();
    }
}
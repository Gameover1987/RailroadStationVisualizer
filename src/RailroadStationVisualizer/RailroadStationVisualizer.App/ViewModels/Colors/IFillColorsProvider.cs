namespace RailroadStationVisualizer.App.ViewModels.Colors
{
    /// <summary>
    /// Поставщик цветов для заливки
    /// </summary>
    public interface IFillColorsProvider
    {
        /// <summary>
        /// Возвращает коллекцию цветов для заливки
        /// </summary>
        /// <returns></returns>
        ColorViewModel[] GetColors();
    }
}
